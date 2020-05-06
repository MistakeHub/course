
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/06/2020 21:38:33
-- Generated from EDMX file: D:\CourseRepos\Course\Course\Model\ModelMail.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_PostManDBRegionDB]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RegionDBSet] DROP CONSTRAINT [FK_PostManDBRegionDB];
GO
IF OBJECT_ID(N'[dbo].[FK_RegionDBPostManDB]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PostManDBSet] DROP CONSTRAINT [FK_RegionDBPostManDB];
GO
IF OBJECT_ID(N'[dbo].[FK_RegionDBSubscriberDB]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SubscriberDBSet] DROP CONSTRAINT [FK_RegionDBSubscriberDB];
GO
IF OBJECT_ID(N'[dbo].[FK_SubscriberDBSubEditionDB]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SubEditionDBSet] DROP CONSTRAINT [FK_SubscriberDBSubEditionDB];
GO
IF OBJECT_ID(N'[dbo].[FK_PostalOfficeDBSubEditionDB]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SubEditionDBSet] DROP CONSTRAINT [FK_PostalOfficeDBSubEditionDB];
GO
IF OBJECT_ID(N'[dbo].[FK_PostalOfficeDBPostManDB]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PostManDBSet] DROP CONSTRAINT [FK_PostalOfficeDBPostManDB];
GO
IF OBJECT_ID(N'[dbo].[FK_PostalOfficeDBRegionDB]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RegionDBSet] DROP CONSTRAINT [FK_PostalOfficeDBRegionDB];
GO
IF OBJECT_ID(N'[dbo].[FK_PostalOfficeDBSubscriberDB]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SubscriberDBSet] DROP CONSTRAINT [FK_PostalOfficeDBSubscriberDB];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[RegionDBSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RegionDBSet];
GO
IF OBJECT_ID(N'[dbo].[PostManDBSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PostManDBSet];
GO
IF OBJECT_ID(N'[dbo].[SubEditionDBSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SubEditionDBSet];
GO
IF OBJECT_ID(N'[dbo].[SubscriberDBSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SubscriberDBSet];
GO
IF OBJECT_ID(N'[dbo].[PostalOfficeDBSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PostalOfficeDBSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'RegionDBSet'
CREATE TABLE [dbo].[RegionDBSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TitleReg] nvarchar(max)  NOT NULL,
    [PostManDB_Id] int  NOT NULL,
    [PostalOfficeDB_Id] int  NOT NULL
);
GO

-- Creating table 'PostManDBSet'
CREATE TABLE [dbo].[PostManDBSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Surname] nvarchar(max)  NOT NULL,
    [RegionDB1_Id] int  NOT NULL,
    [PostalOfficeDB_Id] int  NOT NULL
);
GO

-- Creating table 'SubEditionDBSet'
CREATE TABLE [dbo].[SubEditionDBSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Price] float  NOT NULL,
    [SubscriberDB_Id] int  NOT NULL,
    [PostalOfficeDB_Id] int  NOT NULL
);
GO

-- Creating table 'SubscriberDBSet'
CREATE TABLE [dbo].[SubscriberDBSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SurnameNpSub] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NOT NULL,
    [DateStart] datetime  NOT NULL,
    [DateEnd] datetime  NOT NULL,
    [Term] float  NOT NULL,
    [RegionDB_Id] int  NOT NULL,
    [PostalOfficeDB_Id] int  NOT NULL
);
GO

-- Creating table 'PostalOfficeDBSet'
CREATE TABLE [dbo].[PostalOfficeDBSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TitlePostal] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'RegionDBSet'
ALTER TABLE [dbo].[RegionDBSet]
ADD CONSTRAINT [PK_RegionDBSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PostManDBSet'
ALTER TABLE [dbo].[PostManDBSet]
ADD CONSTRAINT [PK_PostManDBSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SubEditionDBSet'
ALTER TABLE [dbo].[SubEditionDBSet]
ADD CONSTRAINT [PK_SubEditionDBSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SubscriberDBSet'
ALTER TABLE [dbo].[SubscriberDBSet]
ADD CONSTRAINT [PK_SubscriberDBSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PostalOfficeDBSet'
ALTER TABLE [dbo].[PostalOfficeDBSet]
ADD CONSTRAINT [PK_PostalOfficeDBSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [PostManDB_Id] in table 'RegionDBSet'
ALTER TABLE [dbo].[RegionDBSet]
ADD CONSTRAINT [FK_PostManDBRegionDB]
    FOREIGN KEY ([PostManDB_Id])
    REFERENCES [dbo].[PostManDBSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PostManDBRegionDB'
CREATE INDEX [IX_FK_PostManDBRegionDB]
ON [dbo].[RegionDBSet]
    ([PostManDB_Id]);
GO

-- Creating foreign key on [RegionDB1_Id] in table 'PostManDBSet'
ALTER TABLE [dbo].[PostManDBSet]
ADD CONSTRAINT [FK_RegionDBPostManDB]
    FOREIGN KEY ([RegionDB1_Id])
    REFERENCES [dbo].[RegionDBSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RegionDBPostManDB'
CREATE INDEX [IX_FK_RegionDBPostManDB]
ON [dbo].[PostManDBSet]
    ([RegionDB1_Id]);
GO

-- Creating foreign key on [RegionDB_Id] in table 'SubscriberDBSet'
ALTER TABLE [dbo].[SubscriberDBSet]
ADD CONSTRAINT [FK_RegionDBSubscriberDB]
    FOREIGN KEY ([RegionDB_Id])
    REFERENCES [dbo].[RegionDBSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RegionDBSubscriberDB'
CREATE INDEX [IX_FK_RegionDBSubscriberDB]
ON [dbo].[SubscriberDBSet]
    ([RegionDB_Id]);
GO

-- Creating foreign key on [SubscriberDB_Id] in table 'SubEditionDBSet'
ALTER TABLE [dbo].[SubEditionDBSet]
ADD CONSTRAINT [FK_SubscriberDBSubEditionDB]
    FOREIGN KEY ([SubscriberDB_Id])
    REFERENCES [dbo].[SubscriberDBSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SubscriberDBSubEditionDB'
CREATE INDEX [IX_FK_SubscriberDBSubEditionDB]
ON [dbo].[SubEditionDBSet]
    ([SubscriberDB_Id]);
GO

-- Creating foreign key on [PostalOfficeDB_Id] in table 'SubEditionDBSet'
ALTER TABLE [dbo].[SubEditionDBSet]
ADD CONSTRAINT [FK_PostalOfficeDBSubEditionDB]
    FOREIGN KEY ([PostalOfficeDB_Id])
    REFERENCES [dbo].[PostalOfficeDBSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PostalOfficeDBSubEditionDB'
CREATE INDEX [IX_FK_PostalOfficeDBSubEditionDB]
ON [dbo].[SubEditionDBSet]
    ([PostalOfficeDB_Id]);
GO

-- Creating foreign key on [PostalOfficeDB_Id] in table 'PostManDBSet'
ALTER TABLE [dbo].[PostManDBSet]
ADD CONSTRAINT [FK_PostalOfficeDBPostManDB]
    FOREIGN KEY ([PostalOfficeDB_Id])
    REFERENCES [dbo].[PostalOfficeDBSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PostalOfficeDBPostManDB'
CREATE INDEX [IX_FK_PostalOfficeDBPostManDB]
ON [dbo].[PostManDBSet]
    ([PostalOfficeDB_Id]);
GO

-- Creating foreign key on [PostalOfficeDB_Id] in table 'RegionDBSet'
ALTER TABLE [dbo].[RegionDBSet]
ADD CONSTRAINT [FK_PostalOfficeDBRegionDB]
    FOREIGN KEY ([PostalOfficeDB_Id])
    REFERENCES [dbo].[PostalOfficeDBSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PostalOfficeDBRegionDB'
CREATE INDEX [IX_FK_PostalOfficeDBRegionDB]
ON [dbo].[RegionDBSet]
    ([PostalOfficeDB_Id]);
GO

-- Creating foreign key on [PostalOfficeDB_Id] in table 'SubscriberDBSet'
ALTER TABLE [dbo].[SubscriberDBSet]
ADD CONSTRAINT [FK_PostalOfficeDBSubscriberDB]
    FOREIGN KEY ([PostalOfficeDB_Id])
    REFERENCES [dbo].[PostalOfficeDBSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PostalOfficeDBSubscriberDB'
CREATE INDEX [IX_FK_PostalOfficeDBSubscriberDB]
ON [dbo].[SubscriberDBSet]
    ([PostalOfficeDB_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------