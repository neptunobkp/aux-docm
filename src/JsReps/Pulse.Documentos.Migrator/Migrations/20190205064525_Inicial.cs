using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pulse.Documentos.Migrator.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aplicaciones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aplicaciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Archivos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArchivoBytes = table.Column<byte[]>(nullable: true),
                    NombreArchivo = table.Column<string>(nullable: true),
                    Extension = table.Column<string>(nullable: true),
                    InstanciaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Archivos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailTemplateDataVersion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Body = table.Column<string>(nullable: true),
                    Draft = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailTemplateDataVersion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MasterTemplateData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Body = table.Column<string>(nullable: true),
                    Codigo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterTemplateData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PdfTemplateDataVersion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Body = table.Column<string>(nullable: true),
                    Draft = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PdfTemplateDataVersion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grupos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AplicacionId = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Codigo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grupos_Aplicaciones_AplicacionId",
                        column: x => x.AplicacionId,
                        principalTable: "Aplicaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmailTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<string>(nullable: true),
                    GrupoId = table.Column<int>(nullable: false),
                    Para = table.Column<string>(nullable: true),
                    ConCopia = table.Column<string>(nullable: true),
                    ConCopiaOculta = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailTemplates_Grupos_GrupoId",
                        column: x => x.GrupoId,
                        principalTable: "Grupos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PdfTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GrupoId = table.Column<int>(nullable: false),
                    Codigo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PdfTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PdfTemplates_Grupos_GrupoId",
                        column: x => x.GrupoId,
                        principalTable: "Grupos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmailInstances",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmailTemplateId = table.Column<int>(nullable: true),
                    EmailTemplateDataVersionId = table.Column<int>(nullable: true),
                    Para = table.Column<string>(nullable: true),
                    ConCopia = table.Column<string>(nullable: true),
                    ConCopiaOculta = table.Column<string>(nullable: true),
                    Asunto = table.Column<string>(nullable: true),
                    Payload = table.Column<string>(nullable: true),
                    Requester = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true),
                    ExternalKey1 = table.Column<string>(nullable: true),
                    ExternalKey2 = table.Column<string>(nullable: true),
                    ExternalKey3 = table.Column<int>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Idioma = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailInstances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailInstances_EmailTemplateDataVersion_EmailTemplateDataVersionId",
                        column: x => x.EmailTemplateDataVersionId,
                        principalTable: "EmailTemplateDataVersion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmailInstances_EmailTemplates_EmailTemplateId",
                        column: x => x.EmailTemplateId,
                        principalTable: "EmailTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmailTemplateData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Idioma = table.Column<int>(nullable: false),
                    Cuerpo = table.Column<string>(nullable: true),
                    Asunto = table.Column<string>(nullable: true),
                    EmailTemplateId = table.Column<int>(nullable: false),
                    EmailTemplateDataVersionId = table.Column<int>(nullable: false),
                    MasterTemplateDataId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailTemplateData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailTemplateData_EmailTemplateDataVersion_EmailTemplateDataVersionId",
                        column: x => x.EmailTemplateDataVersionId,
                        principalTable: "EmailTemplateDataVersion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmailTemplateData_EmailTemplates_EmailTemplateId",
                        column: x => x.EmailTemplateId,
                        principalTable: "EmailTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmailTemplateData_MasterTemplateData_MasterTemplateDataId",
                        column: x => x.MasterTemplateDataId,
                        principalTable: "MasterTemplateData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmailPdfTemplate",
                columns: table => new
                {
                    EmailTemplateId = table.Column<int>(nullable: false),
                    PdfTemplateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailPdfTemplate", x => new { x.EmailTemplateId, x.PdfTemplateId });
                    table.ForeignKey(
                        name: "FK_EmailPdfTemplate_EmailTemplates_EmailTemplateId",
                        column: x => x.EmailTemplateId,
                        principalTable: "EmailTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmailPdfTemplate_PdfTemplates_PdfTemplateId",
                        column: x => x.PdfTemplateId,
                        principalTable: "PdfTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PdfInstances",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PdfTemplateId = table.Column<int>(nullable: true),
                    PdfTemplateDataVersionId = table.Column<int>(nullable: true),
                    Payload = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true),
                    Requester = table.Column<string>(nullable: true),
                    ExternalKey1 = table.Column<string>(nullable: true),
                    ExternalKey2 = table.Column<string>(nullable: true),
                    ExternalKey3 = table.Column<int>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PdfInstances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PdfInstances_PdfTemplateDataVersion_PdfTemplateDataVersionId",
                        column: x => x.PdfTemplateDataVersionId,
                        principalTable: "PdfTemplateDataVersion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PdfInstances_PdfTemplates_PdfTemplateId",
                        column: x => x.PdfTemplateId,
                        principalTable: "PdfTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PdfTemplateData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Body = table.Column<string>(nullable: true),
                    Idioma = table.Column<int>(nullable: false),
                    PdfTemplateId = table.Column<int>(nullable: false),
                    PdfTemplateDataVersionId = table.Column<int>(nullable: false),
                    MasterTemplateDataId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PdfTemplateData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PdfTemplateData_MasterTemplateData_MasterTemplateDataId",
                        column: x => x.MasterTemplateDataId,
                        principalTable: "MasterTemplateData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PdfTemplateData_PdfTemplateDataVersion_PdfTemplateDataVersionId",
                        column: x => x.PdfTemplateDataVersionId,
                        principalTable: "PdfTemplateDataVersion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PdfTemplateData_PdfTemplates_PdfTemplateId",
                        column: x => x.PdfTemplateId,
                        principalTable: "PdfTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmailArchivo",
                columns: table => new
                {
                    EmailInstanceId = table.Column<int>(nullable: false),
                    ArchivoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailArchivo", x => new { x.EmailInstanceId, x.ArchivoId });
                    table.ForeignKey(
                        name: "FK_EmailArchivo_Archivos_ArchivoId",
                        column: x => x.ArchivoId,
                        principalTable: "Archivos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmailArchivo_EmailInstances_EmailInstanceId",
                        column: x => x.EmailInstanceId,
                        principalTable: "EmailInstances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmailArchivo_ArchivoId",
                table: "EmailArchivo",
                column: "ArchivoId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailInstances_EmailTemplateDataVersionId",
                table: "EmailInstances",
                column: "EmailTemplateDataVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailInstances_EmailTemplateId",
                table: "EmailInstances",
                column: "EmailTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailPdfTemplate_PdfTemplateId",
                table: "EmailPdfTemplate",
                column: "PdfTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailTemplateData_EmailTemplateDataVersionId",
                table: "EmailTemplateData",
                column: "EmailTemplateDataVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailTemplateData_EmailTemplateId",
                table: "EmailTemplateData",
                column: "EmailTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailTemplateData_MasterTemplateDataId",
                table: "EmailTemplateData",
                column: "MasterTemplateDataId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailTemplates_GrupoId",
                table: "EmailTemplates",
                column: "GrupoId");

            migrationBuilder.CreateIndex(
                name: "IX_Grupos_AplicacionId",
                table: "Grupos",
                column: "AplicacionId");

            migrationBuilder.CreateIndex(
                name: "IX_PdfInstances_PdfTemplateDataVersionId",
                table: "PdfInstances",
                column: "PdfTemplateDataVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_PdfInstances_PdfTemplateId",
                table: "PdfInstances",
                column: "PdfTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_PdfTemplateData_MasterTemplateDataId",
                table: "PdfTemplateData",
                column: "MasterTemplateDataId");

            migrationBuilder.CreateIndex(
                name: "IX_PdfTemplateData_PdfTemplateDataVersionId",
                table: "PdfTemplateData",
                column: "PdfTemplateDataVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_PdfTemplateData_PdfTemplateId",
                table: "PdfTemplateData",
                column: "PdfTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_PdfTemplates_GrupoId",
                table: "PdfTemplates",
                column: "GrupoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailArchivo");

            migrationBuilder.DropTable(
                name: "EmailPdfTemplate");

            migrationBuilder.DropTable(
                name: "EmailTemplateData");

            migrationBuilder.DropTable(
                name: "PdfInstances");

            migrationBuilder.DropTable(
                name: "PdfTemplateData");

            migrationBuilder.DropTable(
                name: "Archivos");

            migrationBuilder.DropTable(
                name: "EmailInstances");

            migrationBuilder.DropTable(
                name: "MasterTemplateData");

            migrationBuilder.DropTable(
                name: "PdfTemplateDataVersion");

            migrationBuilder.DropTable(
                name: "PdfTemplates");

            migrationBuilder.DropTable(
                name: "EmailTemplateDataVersion");

            migrationBuilder.DropTable(
                name: "EmailTemplates");

            migrationBuilder.DropTable(
                name: "Grupos");

            migrationBuilder.DropTable(
                name: "Aplicaciones");
        }
    }
}
