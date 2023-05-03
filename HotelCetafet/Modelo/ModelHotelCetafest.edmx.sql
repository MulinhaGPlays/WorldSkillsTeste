
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/03/2023 10:17:19
-- Generated from EDMX file: C:\Users\android\Documents\GitHub\WorldSkillsTeste\HotelCetafet\Modelo\ModelHotelCetafest.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[fk_clientePais]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cliente] DROP CONSTRAINT [fk_clientePais];
GO
IF OBJECT_ID(N'[dbo].[fk_clienteProfissao]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cliente] DROP CONSTRAINT [fk_clienteProfissao];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Cliente]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cliente];
GO
IF OBJECT_ID(N'[dbo].[Pais]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pais];
GO
IF OBJECT_ID(N'[dbo].[Profissao]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Profissao];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Cliente'
CREATE TABLE [dbo].[Cliente] (
    [codigo] int IDENTITY(1,1) NOT NULL,
    [codigoPais] int  NOT NULL,
    [codigoProfissao] int  NOT NULL,
    [nome] varchar(100)  NULL,
    [Rua] varchar(100)  NULL,
    [bairro] varchar(100)  NULL,
    [cep] varchar(10)  NULL,
    [NumeroCasa] int  NULL,
    [TipoDocumento] char(1)  NOT NULL,
    [NumeroDocumento] varchar(50)  NULL,
    [TipoPessoa] bit  NOT NULL,
    [Sexo] char(1)  NULL,
    [DataNascimento] datetime  NULL,
    [Telefone] varchar(10)  NULL,
    [Celular] varchar(10)  NULL
);
GO

-- Creating table 'Pais'
CREATE TABLE [dbo].[Pais] (
    [codigo] int IDENTITY(1,1) NOT NULL,
    [nome] varchar(100)  NOT NULL,
    [sigla] char(3)  NULL,
    [Populacao] int  NULL
);
GO

-- Creating table 'Profissao'
CREATE TABLE [dbo].[Profissao] (
    [codigo] int IDENTITY(1,1) NOT NULL,
    [descricao] varchar(100)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [codigo] in table 'Cliente'
ALTER TABLE [dbo].[Cliente]
ADD CONSTRAINT [PK_Cliente]
    PRIMARY KEY CLUSTERED ([codigo] ASC);
GO

-- Creating primary key on [codigo] in table 'Pais'
ALTER TABLE [dbo].[Pais]
ADD CONSTRAINT [PK_Pais]
    PRIMARY KEY CLUSTERED ([codigo] ASC);
GO

-- Creating primary key on [codigo] in table 'Profissao'
ALTER TABLE [dbo].[Profissao]
ADD CONSTRAINT [PK_Profissao]
    PRIMARY KEY CLUSTERED ([codigo] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [codigoPais] in table 'Cliente'
ALTER TABLE [dbo].[Cliente]
ADD CONSTRAINT [fk_clientePais]
    FOREIGN KEY ([codigoPais])
    REFERENCES [dbo].[Pais]
        ([codigo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_clientePais'
CREATE INDEX [IX_fk_clientePais]
ON [dbo].[Cliente]
    ([codigoPais]);
GO

-- Creating foreign key on [codigoProfissao] in table 'Cliente'
ALTER TABLE [dbo].[Cliente]
ADD CONSTRAINT [fk_clienteProfissao]
    FOREIGN KEY ([codigoProfissao])
    REFERENCES [dbo].[Profissao]
        ([codigo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_clienteProfissao'
CREATE INDEX [IX_fk_clienteProfissao]
ON [dbo].[Cliente]
    ([codigoProfissao]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------