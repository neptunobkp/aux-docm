using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Pulse.Documentos.Domain.Data.Migrator;
using Pulse.Documentos.Domain.Model;
using Pulse.Documentos.Domain.Model.Instances;

namespace Pulse.Documentos.Domain.Data
{
    public class DocumentosDbContext : DbContext
    {
        public DbSet<Aplicacion> Aplicaciones { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<EmailTemplate> EmailTemplates { get; set; }
        public DbSet<PdfTemplate> PdfTemplates { get; set; }
        public DbSet<PdfTemplateData> PdfTemplateData { get; set; }
        public DbSet<EmailTemplateData> EmailTemplateData { get; set; }

        public DbSet<Archivo> Archivos { get; set; }

        public DbSet<EmailInstance> EmailInstances { get; set; }
        public DbSet<PdfInstance> PdfInstances { get; set; }


        public DocumentosDbContext(DbContextOptions<DocumentosDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes().SelectMany(t => t.GetForeignKeys()).Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);
            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;


            modelBuilder.Entity<EmailPdfTemplate>().HasKey(bc => new { bc.EmailTemplateId, bc.PdfTemplateId });
            modelBuilder.Entity<EmailPdfTemplate>()
                .HasOne(bc => bc.EmailTemplate)
                .WithMany(b => b.PdfTemplates)
                .HasForeignKey(bc => bc.EmailTemplateId);
            modelBuilder.Entity<EmailPdfTemplate>()
                .HasOne(bc => bc.PdfTemplate)
                .WithMany(c => c.EmailTemplates)
                .HasForeignKey(bc => bc.PdfTemplateId);


            modelBuilder.Entity<EmailArchivo>().HasKey(bc => new { bc.EmailInstanceId, bc.ArchivoId });
           
        }
        private static readonly DbMigrator Migrator = new DbMigrator(typeof(DbMigrator).GetTypeInfo().Assembly, "dbo", "Pulse.Documentos.Domain.Data.Migrations");
        public void RunMigration()
        {
            Migrator.Migrate(Database.GetDbConnection());
        }
    }
}
