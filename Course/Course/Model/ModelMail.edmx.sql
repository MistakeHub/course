
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/05/2020 20:25:53
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


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'RegionDBSet'
CREATE TABLE [dbo].[RegionDBSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TitleReg] nvarchar(max)  NOT NULL,
    [PostManDB_Id] int  NOT NULL
);
GO

-- Creating table 'PostManDBSet'
CREATE TABLE [dbo].[PostManDBSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Surname] nvarchar(max)  NOT NULL,
    [RegionDB1_Id] int  NOT NULL
);
GO

-- Creating table 'SubEditionDBSet'
CREATE TABLE [dbo].[SubEditionDBSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Price] float  NOT NULL
);
GO

-- Creating table 'SubscriberDBSet'
CREATE TABLE [dbo].[SubscriberDBSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SurnameNpSub] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NOT NULL,
    [DateStart] datetime  NOT NULL,
    [DateEnd] datetime  NOT NULL,
    [RegionDB_Id] int  NOT NULL,
    [SubEditionDB_Id] int  NOT NULL
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

-- Creating foreign key on [SubEditionDB_Id] in table 'SubscriberDBSet'
ALTER TABLE [dbo].[SubscriberDBSet]
ADD CONSTRAINT [FK_SubEditionDBSubscriberDB]
    FOREIGN KEY ([SubEditionDB_Id])
    REFERENCES [dbo].[SubEditionDBSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SubEditionDBSubscriberDB'
CREATE INDEX [IX_FK_SubEditionDBSubscriberDB]
ON [dbo].[SubscriberDBSet]
    ([SubEditionDB_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------