﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pulse.Documentos.Migrator;

namespace Pulse.Documentos.Migrator.Migrations
{
    [DbContext(typeof(ProxyDbContext))]
    partial class ProxyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Pulse.Documentos.Domain.Model.Aplicacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre");

                    b.HasKey("Id");

                    b.ToTable("Aplicaciones");
                });

            modelBuilder.Entity("Pulse.Documentos.Domain.Model.Archivo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("ArchivoBytes");

                    b.Property<string>("Extension");

                    b.Property<int?>("InstanciaId");

                    b.Property<string>("NombreArchivo");

                    b.HasKey("Id");

                    b.ToTable("Archivos");
                });

            modelBuilder.Entity("Pulse.Documentos.Domain.Model.EmailArchivo", b =>
                {
                    b.Property<int>("EmailInstanceId");

                    b.Property<int>("ArchivoId");

                    b.HasKey("EmailInstanceId", "ArchivoId");

                    b.HasIndex("ArchivoId");

                    b.ToTable("EmailArchivo");
                });

            modelBuilder.Entity("Pulse.Documentos.Domain.Model.EmailPdfTemplate", b =>
                {
                    b.Property<int>("EmailTemplateId");

                    b.Property<int>("PdfTemplateId");

                    b.HasKey("EmailTemplateId", "PdfTemplateId");

                    b.HasIndex("PdfTemplateId");

                    b.ToTable("EmailPdfTemplate");
                });

            modelBuilder.Entity("Pulse.Documentos.Domain.Model.EmailTemplate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo");

                    b.Property<string>("ConCopia");

                    b.Property<string>("ConCopiaOculta");

                    b.Property<int>("GrupoId");

                    b.Property<string>("Para");

                    b.HasKey("Id");

                    b.HasIndex("GrupoId");

                    b.ToTable("EmailTemplates");
                });

            modelBuilder.Entity("Pulse.Documentos.Domain.Model.EmailTemplateData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Asunto");

                    b.Property<string>("Cuerpo");

                    b.Property<int>("EmailTemplateDataVersionId");

                    b.Property<int>("EmailTemplateId");

                    b.Property<int>("Idioma");

                    b.Property<int>("MasterTemplateDataId");

                    b.HasKey("Id");

                    b.HasIndex("EmailTemplateDataVersionId");

                    b.HasIndex("EmailTemplateId");

                    b.HasIndex("MasterTemplateDataId");

                    b.ToTable("EmailTemplateData");
                });

            modelBuilder.Entity("Pulse.Documentos.Domain.Model.Grupo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AplicacionId");

                    b.Property<string>("Codigo");

                    b.Property<string>("Nombre");

                    b.HasKey("Id");

                    b.HasIndex("AplicacionId");

                    b.ToTable("Grupos");
                });

            modelBuilder.Entity("Pulse.Documentos.Domain.Model.Instances.EmailInstance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Asunto");

                    b.Property<string>("Body");

                    b.Property<string>("ConCopia");

                    b.Property<string>("ConCopiaOculta");

                    b.Property<int?>("EmailTemplateDataVersionId");

                    b.Property<int?>("EmailTemplateId");

                    b.Property<string>("ExternalKey1");

                    b.Property<string>("ExternalKey2");

                    b.Property<int?>("ExternalKey3");

                    b.Property<DateTime>("Fecha");

                    b.Property<int>("Idioma");

                    b.Property<string>("Para");

                    b.Property<string>("Payload");

                    b.Property<string>("Requester");

                    b.HasKey("Id");

                    b.HasIndex("EmailTemplateDataVersionId");

                    b.HasIndex("EmailTemplateId");

                    b.ToTable("EmailInstances");
                });

            modelBuilder.Entity("Pulse.Documentos.Domain.Model.Instances.PdfInstance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Body");

                    b.Property<string>("ExternalKey1");

                    b.Property<string>("ExternalKey2");

                    b.Property<int?>("ExternalKey3");

                    b.Property<DateTime>("Fecha");

                    b.Property<string>("Payload");

                    b.Property<int?>("PdfTemplateDataVersionId");

                    b.Property<int?>("PdfTemplateId");

                    b.Property<string>("Requester");

                    b.HasKey("Id");

                    b.HasIndex("PdfTemplateDataVersionId");

                    b.HasIndex("PdfTemplateId");

                    b.ToTable("PdfInstances");
                });

            modelBuilder.Entity("Pulse.Documentos.Domain.Model.Masters.MasterTemplateData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Body");

                    b.Property<string>("Codigo");

                    b.HasKey("Id");

                    b.ToTable("MasterTemplateData");
                });

            modelBuilder.Entity("Pulse.Documentos.Domain.Model.PdfTemplate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo");

                    b.Property<int>("GrupoId");

                    b.HasKey("Id");

                    b.HasIndex("GrupoId");

                    b.ToTable("PdfTemplates");
                });

            modelBuilder.Entity("Pulse.Documentos.Domain.Model.PdfTemplateData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Body");

                    b.Property<int>("Idioma");

                    b.Property<int>("MasterTemplateDataId");

                    b.Property<int>("PdfTemplateDataVersionId");

                    b.Property<int>("PdfTemplateId");

                    b.HasKey("Id");

                    b.HasIndex("MasterTemplateDataId");

                    b.HasIndex("PdfTemplateDataVersionId");

                    b.HasIndex("PdfTemplateId");

                    b.ToTable("PdfTemplateData");
                });

            modelBuilder.Entity("Pulse.Documentos.Domain.Model.Versions.EmailTemplateDataVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Body");

                    b.Property<bool>("Draft");

                    b.HasKey("Id");

                    b.ToTable("EmailTemplateDataVersion");
                });

            modelBuilder.Entity("Pulse.Documentos.Domain.Model.Versions.PdfTemplateDataVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Body");

                    b.Property<bool>("Draft");

                    b.HasKey("Id");

                    b.ToTable("PdfTemplateDataVersion");
                });

            modelBuilder.Entity("Pulse.Documentos.Domain.Model.EmailArchivo", b =>
                {
                    b.HasOne("Pulse.Documentos.Domain.Model.Archivo", "Archivo")
                        .WithMany()
                        .HasForeignKey("ArchivoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Pulse.Documentos.Domain.Model.Instances.EmailInstance")
                        .WithMany("EmailArchivos")
                        .HasForeignKey("EmailInstanceId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Pulse.Documentos.Domain.Model.EmailPdfTemplate", b =>
                {
                    b.HasOne("Pulse.Documentos.Domain.Model.EmailTemplate", "EmailTemplate")
                        .WithMany("PdfTemplates")
                        .HasForeignKey("EmailTemplateId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Pulse.Documentos.Domain.Model.PdfTemplate", "PdfTemplate")
                        .WithMany("EmailTemplates")
                        .HasForeignKey("PdfTemplateId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Pulse.Documentos.Domain.Model.EmailTemplate", b =>
                {
                    b.HasOne("Pulse.Documentos.Domain.Model.Grupo", "Grupo")
                        .WithMany()
                        .HasForeignKey("GrupoId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Pulse.Documentos.Domain.Model.EmailTemplateData", b =>
                {
                    b.HasOne("Pulse.Documentos.Domain.Model.Versions.EmailTemplateDataVersion", "EmailTemplateDataVersion")
                        .WithMany()
                        .HasForeignKey("EmailTemplateDataVersionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Pulse.Documentos.Domain.Model.EmailTemplate", "EmailTemplate")
                        .WithMany("Templates")
                        .HasForeignKey("EmailTemplateId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Pulse.Documentos.Domain.Model.Masters.MasterTemplateData", "MasterTemplateData")
                        .WithMany()
                        .HasForeignKey("MasterTemplateDataId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Pulse.Documentos.Domain.Model.Grupo", b =>
                {
                    b.HasOne("Pulse.Documentos.Domain.Model.Aplicacion", "Aplicacion")
                        .WithMany("Grupos")
                        .HasForeignKey("AplicacionId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Pulse.Documentos.Domain.Model.Instances.EmailInstance", b =>
                {
                    b.HasOne("Pulse.Documentos.Domain.Model.Versions.EmailTemplateDataVersion", "EmailTemplateDataVersion")
                        .WithMany()
                        .HasForeignKey("EmailTemplateDataVersionId");

                    b.HasOne("Pulse.Documentos.Domain.Model.EmailTemplate", "EmailTemplate")
                        .WithMany()
                        .HasForeignKey("EmailTemplateId");
                });

            modelBuilder.Entity("Pulse.Documentos.Domain.Model.Instances.PdfInstance", b =>
                {
                    b.HasOne("Pulse.Documentos.Domain.Model.Versions.PdfTemplateDataVersion", "PdfTemplateDataVersion")
                        .WithMany()
                        .HasForeignKey("PdfTemplateDataVersionId");

                    b.HasOne("Pulse.Documentos.Domain.Model.PdfTemplate", "PdfTemplate")
                        .WithMany()
                        .HasForeignKey("PdfTemplateId");
                });

            modelBuilder.Entity("Pulse.Documentos.Domain.Model.PdfTemplate", b =>
                {
                    b.HasOne("Pulse.Documentos.Domain.Model.Grupo", "Grupo")
                        .WithMany()
                        .HasForeignKey("GrupoId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Pulse.Documentos.Domain.Model.PdfTemplateData", b =>
                {
                    b.HasOne("Pulse.Documentos.Domain.Model.Masters.MasterTemplateData", "MasterTemplateData")
                        .WithMany()
                        .HasForeignKey("MasterTemplateDataId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Pulse.Documentos.Domain.Model.Versions.PdfTemplateDataVersion", "PdfTemplateDataVersion")
                        .WithMany()
                        .HasForeignKey("PdfTemplateDataVersionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Pulse.Documentos.Domain.Model.PdfTemplate", "PdfTemplate")
                        .WithMany("Templates")
                        .HasForeignKey("PdfTemplateId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}