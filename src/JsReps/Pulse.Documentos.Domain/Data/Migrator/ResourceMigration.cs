using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Pulse.Documentos.Domain.Data.Migrator {
    internal class ResourceMigration : Migration {
        public ResourceMigration(Assembly assembly, string resourceName, long version) {
            if (assembly == null) {
                throw new ArgumentNullException(nameof(assembly));
            }

            Assembly = assembly;
            ResourceName = resourceName;
            Version = version;
        }

        public Assembly Assembly { get; }
        public string ResourceName { get; }
        public override long Version { get; }

        public override void Execute(MigratorDatabase migratorDatabase) {
            foreach (var commandText in ParseCommands()) {
                try
                {
                    using (var command = migratorDatabase.CreateCommand())
                    {
                        command.CommandText = commandText;
                        command.CommandTimeout = 0;
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private IEnumerable<string> ParseCommands() {
            using (var streamReader = new StreamReader(Assembly.GetManifestResourceStream(ResourceName))) {
                var commandText = streamReader.ReadToEnd();
                return Regex.Split(commandText, @"\sGO\s").Where(x => !string.IsNullOrEmpty(x) && x.Length > 2);//TODO valida que esto lo arregla porfa, en el sgte migration deja el mismo go y no deberia fallar porfa
            }
        }
    }
}
