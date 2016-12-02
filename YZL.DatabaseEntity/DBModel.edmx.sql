
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/30/2016 20:33:49
-- Generated from EDMX file: D:\网站\Project\YZL_2016_11_30\YZL\YZL.DatabaseEntity\DBModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Test];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[StudentsSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StudentsSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'StudentsSet'
CREATE TABLE [dbo].[StudentsSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'SClassSet'
CREATE TABLE [dbo].[SClassSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CName] nvarchar(max)  NOT NULL,
    [Students_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'StudentsSet'
ALTER TABLE [dbo].[StudentsSet]
ADD CONSTRAINT [PK_StudentsSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SClassSet'
ALTER TABLE [dbo].[SClassSet]
ADD CONSTRAINT [PK_SClassSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Students_Id] in table 'SClassSet'
ALTER TABLE [dbo].[SClassSet]
ADD CONSTRAINT [FK_StudentsSClass]
    FOREIGN KEY ([Students_Id])
    REFERENCES [dbo].[StudentsSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentsSClass'
CREATE INDEX [IX_FK_StudentsSClass]
ON [dbo].[SClassSet]
    ([Students_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------