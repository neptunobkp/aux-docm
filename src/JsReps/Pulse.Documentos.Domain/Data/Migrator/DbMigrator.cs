using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Pulse.Documentos.Domain.Data.Migrator
{
    public class DbMigrator
    {
        private readonly Regex _versionNumberRegex = new Regex(@"(?'version'\d+).*\.sql");

        public DbMigrator(Assembly assembly, string schemaName, string manifestPath)
        {
            SchemaName = schemaName;
            Migrations = assembly
                .GetManifestResourceNames()
                .Where(x => x.IndexOf(manifestPath, StringComparison.OrdinalIgnoreCase) > -1
                         && x.EndsWith(".sql", StringComparison.OrdinalIgnoreCase))
                .Select(x => new ResourceMigration(assembly, x, GetFileVersion(x)) as Migration)
                .OrderBy(x => x.Version)
                .ToList();

            var codeMigrations = assembly
                            .GetTypes()
                            .Where(x => typeof(Migration).IsAssignableFrom(x) && x.Namespace.ToLower().Contains(manifestPath.ToLower()))
                            .Select(Activator.CreateInstance)
                            .Cast<Migration>();

            foreach (var migration in codeMigrations)
            {
                Migrations.Add(migration);
            }

            Migrations = Migrations
                .OrderBy(x => x.Version)
                .ToList();

            VersionTable = new CachedDatabaseVersionTable(new DatabaseVersionTable(SchemaName));
            LatestSchemaVersion = Migrations.Any() ? Migrations.Max(x => x.Version) : 0;
        }

        public CachedDatabaseVersionTable VersionTable { get; }
        public string SchemaName { get; }
        private long LatestSchemaVersion { get; }
        private IList<Migration> Migrations { get; }

        public void LoadVersionInfo(IDbConnection connection)
        {
            var database = new MigratorDatabase(connection);

            if (VersionTable.Exists(database))
            {
                VersionTable.GetCurrentVersion(database);
            }
        }

        public void Migrate(string connectionString)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                Migrate(connection);
            }
        }

        public void Migrate(IDbConnection connection)
        {
            if (connection == null)
            {
                throw new ArgumentNullException(nameof(connection));
            }

            var database = new MigratorDatabase(connection);
            var dbVersion = GetDbVersion(database);

            Migrate(dbVersion, database);
            //FullTextIndexMigrator.Migrate(connection);
        }

        private void Migrate(long dbVersion, MigratorDatabase database)
        {
            if (dbVersion >= LatestSchemaVersion)
            {
                return;
            }

            using (var transaction = database.BeginTransaction())
            {
                dbVersion = VersionTable.GetCurrentVersionWithLock(database);

                if (dbVersion >= LatestSchemaVersion)
                {
                    return;
                }

                var migrations = Migrations.Where(x => x.Version > dbVersion);

                foreach (var migration in migrations)
                {
                    if (migration.Version <= dbVersion)
                    {
                        continue;
                    }

                    migration.Execute(database);

                    dbVersion = VersionTable.GetCurrentVersionWithLock(database);

                    if (migration.Version > dbVersion)
                    {
                        VersionTable.SetVersion(database, migration.Version);
                    }
                }
                transaction.Commit();
            }
        }

        private long GetDbVersion(MigratorDatabase database)
        {
            VersionTable.CreateIfNotExisting(database);
            return VersionTable.GetCurrentVersion(database);
        }

        private long GetFileVersion(string name)
        {
            return long.Parse(_versionNumberRegex.Match(name).Groups["version"].Value);
        }
    }

    public class FullTextIndexMigrator
    {
        private static object _lock = new object();
        private static bool _hasBeenExecuted;

        public static void Migrate(IDbConnection connection)
        {
            if (_hasBeenExecuted)
            {
                return;
            }

            lock (_lock)
            {
                if (_hasBeenExecuted)
                {
                    return;
                }

                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                using (var command = connection.CreateCommand())
                {
                    command.CommandText =
                        @"IF NOT EXISTS(SELECT 1 FROM sys.fulltext_catalogs WHERE name = 'FullTextIndexCatalog')
                                        BEGIN
	                                        CREATE FULLTEXT CATALOG FullTextIndexCatalog AS DEFAULT; 
                                        END

                                        IF NOT EXISTS(SELECT 1 FROM sys.columns c INNER JOIN sys.fulltext_index_columns fic ON c.object_id = fic.object_id AND c.column_id = fic.column_id
                                        WHERE c.object_id = OBJECT_ID('ResumenesEvento'))
                                        BEGIN 
	                                        CREATE FULLTEXT INDEX ON ResumenesEvento(Metadata)   
		                                        KEY INDEX IX_ResumenesEvento_EventoId   
		                                        WITH STOPLIST = OFF;  

	                                        ALTER FULLTEXT INDEX ON ResumenesEvento SET CHANGE_TRACKING AUTO;  
                                        END";
                    command.ExecuteNonQuery();

                    _hasBeenExecuted = true;
                }
            }
        }
    }
}
