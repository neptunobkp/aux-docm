using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Pulse.Documentos.Domain.Data;

namespace Pulse.Documentos.Migrator
{
    public class ProxyDbContext : DocumentosDbContext
    {
        public ProxyDbContext(DbContextOptions<DocumentosDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Database=DBDocumentos;Server=localhost;User=docu_user;Password=docu_user;");
        }
    }

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ProxyDbContext>
    {
        public ProxyDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .Build();

            var builder = new DbContextOptionsBuilder<DocumentosDbContext>();

            var connectionString = @"Database=DBDocumentos;Server=localhost;User=docu_user;Password=docu_user;";

            builder.UseSqlServer(connectionString);

            return new ProxyDbContext(builder.Options);
        }
    }
}
