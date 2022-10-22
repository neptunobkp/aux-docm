IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Aplicaciones] (
    [Id] int NOT NULL IDENTITY,
    [Nombre] nvarchar(max) NULL,
    CONSTRAINT [PK_Aplicaciones] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Archivos] (
    [Id] int NOT NULL IDENTITY,
    [ArchivoBytes] varbinary(max) NULL,
    [NombreArchivo] nvarchar(max) NULL,
    [Extension] nvarchar(max) NULL,
    [InstanciaId] int NULL,
    CONSTRAINT [PK_Archivos] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [EmailTemplateDataVersion] (
    [Id] int NOT NULL IDENTITY,
    [Body] nvarchar(max) NULL,
    [Draft] bit NOT NULL,
    CONSTRAINT [PK_EmailTemplateDataVersion] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [MasterTemplateData] (
    [Id] int NOT NULL IDENTITY,
    [Body] nvarchar(max) NULL,
    [Codigo] nvarchar(max) NULL,
    CONSTRAINT [PK_MasterTemplateData] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [PdfTemplateDataVersion] (
    [Id] int NOT NULL IDENTITY,
    [Body] nvarchar(max) NULL,
    [Draft] bit NOT NULL,
    CONSTRAINT [PK_PdfTemplateDataVersion] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Grupos] (
    [Id] int NOT NULL IDENTITY,
    [AplicacionId] int NOT NULL,
    [Nombre] nvarchar(max) NULL,
    [Codigo] nvarchar(max) NULL,
    CONSTRAINT [PK_Grupos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Grupos_Aplicaciones_AplicacionId] FOREIGN KEY ([AplicacionId]) REFERENCES [Aplicaciones] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [EmailTemplates] (
    [Id] int NOT NULL IDENTITY,
    [Codigo] nvarchar(max) NULL,
    [GrupoId] int NOT NULL,
    [Para] nvarchar(max) NULL,
    [ConCopia] nvarchar(max) NULL,
    [ConCopiaOculta] nvarchar(max) NULL,
    CONSTRAINT [PK_EmailTemplates] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_EmailTemplates_Grupos_GrupoId] FOREIGN KEY ([GrupoId]) REFERENCES [Grupos] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [PdfTemplates] (
    [Id] int NOT NULL IDENTITY,
    [GrupoId] int NOT NULL,
    [Codigo] nvarchar(max) NULL,
    CONSTRAINT [PK_PdfTemplates] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_PdfTemplates_Grupos_GrupoId] FOREIGN KEY ([GrupoId]) REFERENCES [Grupos] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [EmailInstances] (
    [Id] int NOT NULL IDENTITY,
    [EmailTemplateId] int NULL,
    [EmailTemplateDataVersionId] int NULL,
    [Para] nvarchar(max) NULL,
    [ConCopia] nvarchar(max) NULL,
    [ConCopiaOculta] nvarchar(max) NULL,
    [Asunto] nvarchar(max) NULL,
    [Payload] nvarchar(max) NULL,
    [Requester] nvarchar(max) NULL,
    [Body] nvarchar(max) NULL,
    [ExternalKey1] nvarchar(max) NULL,
    [ExternalKey2] nvarchar(max) NULL,
    [ExternalKey3] int NULL,
    [Fecha] datetime2 NOT NULL,
    [Idioma] int NOT NULL,
    CONSTRAINT [PK_EmailInstances] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_EmailInstances_EmailTemplateDataVersion_EmailTemplateDataVersionId] FOREIGN KEY ([EmailTemplateDataVersionId]) REFERENCES [EmailTemplateDataVersion] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_EmailInstances_EmailTemplates_EmailTemplateId] FOREIGN KEY ([EmailTemplateId]) REFERENCES [EmailTemplates] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [EmailTemplateData] (
    [Id] int NOT NULL IDENTITY,
    [Idioma] int NOT NULL,
    [Cuerpo] nvarchar(max) NULL,
    [Asunto] nvarchar(max) NULL,
    [EmailTemplateId] int NOT NULL,
    [EmailTemplateDataVersionId] int NOT NULL,
    [MasterTemplateDataId] int NOT NULL,
    CONSTRAINT [PK_EmailTemplateData] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_EmailTemplateData_EmailTemplateDataVersion_EmailTemplateDataVersionId] FOREIGN KEY ([EmailTemplateDataVersionId]) REFERENCES [EmailTemplateDataVersion] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_EmailTemplateData_EmailTemplates_EmailTemplateId] FOREIGN KEY ([EmailTemplateId]) REFERENCES [EmailTemplates] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_EmailTemplateData_MasterTemplateData_MasterTemplateDataId] FOREIGN KEY ([MasterTemplateDataId]) REFERENCES [MasterTemplateData] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [EmailPdfTemplate] (
    [EmailTemplateId] int NOT NULL,
    [PdfTemplateId] int NOT NULL,
    CONSTRAINT [PK_EmailPdfTemplate] PRIMARY KEY ([EmailTemplateId], [PdfTemplateId]),
    CONSTRAINT [FK_EmailPdfTemplate_EmailTemplates_EmailTemplateId] FOREIGN KEY ([EmailTemplateId]) REFERENCES [EmailTemplates] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_EmailPdfTemplate_PdfTemplates_PdfTemplateId] FOREIGN KEY ([PdfTemplateId]) REFERENCES [PdfTemplates] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [PdfInstances] (
    [Id] int NOT NULL IDENTITY,
    [PdfTemplateId] int NULL,
    [PdfTemplateDataVersionId] int NULL,
    [Payload] nvarchar(max) NULL,
    [Body] nvarchar(max) NULL,
    [Requester] nvarchar(max) NULL,
    [ExternalKey1] nvarchar(max) NULL,
    [ExternalKey2] nvarchar(max) NULL,
    [ExternalKey3] int NULL,
    [Fecha] datetime2 NOT NULL,
    CONSTRAINT [PK_PdfInstances] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_PdfInstances_PdfTemplateDataVersion_PdfTemplateDataVersionId] FOREIGN KEY ([PdfTemplateDataVersionId]) REFERENCES [PdfTemplateDataVersion] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_PdfInstances_PdfTemplates_PdfTemplateId] FOREIGN KEY ([PdfTemplateId]) REFERENCES [PdfTemplates] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [PdfTemplateData] (
    [Id] int NOT NULL IDENTITY,
    [Body] nvarchar(max) NULL,
    [Idioma] int NOT NULL,
    [PdfTemplateId] int NOT NULL,
    [PdfTemplateDataVersionId] int NOT NULL,
    [MasterTemplateDataId] int NOT NULL,
    CONSTRAINT [PK_PdfTemplateData] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_PdfTemplateData_MasterTemplateData_MasterTemplateDataId] FOREIGN KEY ([MasterTemplateDataId]) REFERENCES [MasterTemplateData] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_PdfTemplateData_PdfTemplateDataVersion_PdfTemplateDataVersionId] FOREIGN KEY ([PdfTemplateDataVersionId]) REFERENCES [PdfTemplateDataVersion] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_PdfTemplateData_PdfTemplates_PdfTemplateId] FOREIGN KEY ([PdfTemplateId]) REFERENCES [PdfTemplates] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [EmailArchivo] (
    [EmailInstanceId] int NOT NULL,
    [ArchivoId] int NOT NULL,
    CONSTRAINT [PK_EmailArchivo] PRIMARY KEY ([EmailInstanceId], [ArchivoId]),
    CONSTRAINT [FK_EmailArchivo_Archivos_ArchivoId] FOREIGN KEY ([ArchivoId]) REFERENCES [Archivos] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_EmailArchivo_EmailInstances_EmailInstanceId] FOREIGN KEY ([EmailInstanceId]) REFERENCES [EmailInstances] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_EmailArchivo_ArchivoId] ON [EmailArchivo] ([ArchivoId]);

GO

CREATE INDEX [IX_EmailInstances_EmailTemplateDataVersionId] ON [EmailInstances] ([EmailTemplateDataVersionId]);

GO

CREATE INDEX [IX_EmailInstances_EmailTemplateId] ON [EmailInstances] ([EmailTemplateId]);

GO

CREATE INDEX [IX_EmailPdfTemplate_PdfTemplateId] ON [EmailPdfTemplate] ([PdfTemplateId]);

GO

CREATE INDEX [IX_EmailTemplateData_EmailTemplateDataVersionId] ON [EmailTemplateData] ([EmailTemplateDataVersionId]);

GO

CREATE INDEX [IX_EmailTemplateData_EmailTemplateId] ON [EmailTemplateData] ([EmailTemplateId]);

GO

CREATE INDEX [IX_EmailTemplateData_MasterTemplateDataId] ON [EmailTemplateData] ([MasterTemplateDataId]);

GO

CREATE INDEX [IX_EmailTemplates_GrupoId] ON [EmailTemplates] ([GrupoId]);

GO

CREATE INDEX [IX_Grupos_AplicacionId] ON [Grupos] ([AplicacionId]);

GO

CREATE INDEX [IX_PdfInstances_PdfTemplateDataVersionId] ON [PdfInstances] ([PdfTemplateDataVersionId]);

GO

CREATE INDEX [IX_PdfInstances_PdfTemplateId] ON [PdfInstances] ([PdfTemplateId]);

GO

CREATE INDEX [IX_PdfTemplateData_MasterTemplateDataId] ON [PdfTemplateData] ([MasterTemplateDataId]);

GO

CREATE INDEX [IX_PdfTemplateData_PdfTemplateDataVersionId] ON [PdfTemplateData] ([PdfTemplateDataVersionId]);

GO

CREATE INDEX [IX_PdfTemplateData_PdfTemplateId] ON [PdfTemplateData] ([PdfTemplateId]);

GO

CREATE INDEX [IX_PdfTemplates_GrupoId] ON [PdfTemplates] ([GrupoId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190205064525_Inicial', N'2.1.3-rtm-32065');

GO

