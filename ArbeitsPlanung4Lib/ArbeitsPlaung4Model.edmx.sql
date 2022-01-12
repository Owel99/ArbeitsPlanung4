
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/12/2022 18:39:20
-- Generated from EDMX file: C:\Users\Ole Weber\source\repos\ArbeitsPlanung4\ArbeitsPlanung4Lib\ArbeitsPlaung4Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ArrbeitsPlanung4];
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

-- Creating table 'BenutzerSet'
CREATE TABLE [dbo].[BenutzerSet] (
    [BenutzerId] int IDENTITY(1,1) NOT NULL,
    [Vorname] nvarchar(max)  NOT NULL,
    [Nachname] nvarchar(max)  NOT NULL,
    [istAdmin] bit  NOT NULL,
    [istBenutzer] bit  NOT NULL
);
GO

-- Creating table 'FlugzeugSet'
CREATE TABLE [dbo].[FlugzeugSet] (
    [FlugzeugId] int IDENTITY(1,1) NOT NULL,
    [Kennzeichen] nvarchar(max)  NOT NULL,
    [Typ] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ArbeitSet'
CREATE TABLE [dbo].[ArbeitSet] (
    [ArbeitId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'FlugzeugArbeit'
CREATE TABLE [dbo].[FlugzeugArbeit] (
    [istAnwendbar_FlugzeugId] int  NOT NULL,
    [hatArbeit_ArbeitId] int  NOT NULL
);
GO

-- Creating table 'kannMachen'
CREATE TABLE [dbo].[kannMachen] (
    [kannGemachtWerden_BenutzerId] int  NOT NULL,
    [kannMachen_ArbeitId] int  NOT NULL
);
GO

-- Creating table 'darfMachen'
CREATE TABLE [dbo].[darfMachen] (
    [darfGemachtWerden_BenutzerId] int  NOT NULL,
    [darfMachen_ArbeitId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [BenutzerId] in table 'BenutzerSet'
ALTER TABLE [dbo].[BenutzerSet]
ADD CONSTRAINT [PK_BenutzerSet]
    PRIMARY KEY CLUSTERED ([BenutzerId] ASC);
GO

-- Creating primary key on [FlugzeugId] in table 'FlugzeugSet'
ALTER TABLE [dbo].[FlugzeugSet]
ADD CONSTRAINT [PK_FlugzeugSet]
    PRIMARY KEY CLUSTERED ([FlugzeugId] ASC);
GO

-- Creating primary key on [ArbeitId] in table 'ArbeitSet'
ALTER TABLE [dbo].[ArbeitSet]
ADD CONSTRAINT [PK_ArbeitSet]
    PRIMARY KEY CLUSTERED ([ArbeitId] ASC);
GO

-- Creating primary key on [istAnwendbar_FlugzeugId], [hatArbeit_ArbeitId] in table 'FlugzeugArbeit'
ALTER TABLE [dbo].[FlugzeugArbeit]
ADD CONSTRAINT [PK_FlugzeugArbeit]
    PRIMARY KEY CLUSTERED ([istAnwendbar_FlugzeugId], [hatArbeit_ArbeitId] ASC);
GO

-- Creating primary key on [kannGemachtWerden_BenutzerId], [kannMachen_ArbeitId] in table 'kannMachen'
ALTER TABLE [dbo].[kannMachen]
ADD CONSTRAINT [PK_kannMachen]
    PRIMARY KEY CLUSTERED ([kannGemachtWerden_BenutzerId], [kannMachen_ArbeitId] ASC);
GO

-- Creating primary key on [darfGemachtWerden_BenutzerId], [darfMachen_ArbeitId] in table 'darfMachen'
ALTER TABLE [dbo].[darfMachen]
ADD CONSTRAINT [PK_darfMachen]
    PRIMARY KEY CLUSTERED ([darfGemachtWerden_BenutzerId], [darfMachen_ArbeitId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [istAnwendbar_FlugzeugId] in table 'FlugzeugArbeit'
ALTER TABLE [dbo].[FlugzeugArbeit]
ADD CONSTRAINT [FK_FlugzeugArbeit_Flugzeug]
    FOREIGN KEY ([istAnwendbar_FlugzeugId])
    REFERENCES [dbo].[FlugzeugSet]
        ([FlugzeugId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [hatArbeit_ArbeitId] in table 'FlugzeugArbeit'
ALTER TABLE [dbo].[FlugzeugArbeit]
ADD CONSTRAINT [FK_FlugzeugArbeit_Arbeit]
    FOREIGN KEY ([hatArbeit_ArbeitId])
    REFERENCES [dbo].[ArbeitSet]
        ([ArbeitId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FlugzeugArbeit_Arbeit'
CREATE INDEX [IX_FK_FlugzeugArbeit_Arbeit]
ON [dbo].[FlugzeugArbeit]
    ([hatArbeit_ArbeitId]);
GO

-- Creating foreign key on [kannGemachtWerden_BenutzerId] in table 'kannMachen'
ALTER TABLE [dbo].[kannMachen]
ADD CONSTRAINT [FK_kannMachen_Benutzer]
    FOREIGN KEY ([kannGemachtWerden_BenutzerId])
    REFERENCES [dbo].[BenutzerSet]
        ([BenutzerId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [kannMachen_ArbeitId] in table 'kannMachen'
ALTER TABLE [dbo].[kannMachen]
ADD CONSTRAINT [FK_kannMachen_Arbeit]
    FOREIGN KEY ([kannMachen_ArbeitId])
    REFERENCES [dbo].[ArbeitSet]
        ([ArbeitId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_kannMachen_Arbeit'
CREATE INDEX [IX_FK_kannMachen_Arbeit]
ON [dbo].[kannMachen]
    ([kannMachen_ArbeitId]);
GO

-- Creating foreign key on [darfGemachtWerden_BenutzerId] in table 'darfMachen'
ALTER TABLE [dbo].[darfMachen]
ADD CONSTRAINT [FK_darfMachen_Benutzer]
    FOREIGN KEY ([darfGemachtWerden_BenutzerId])
    REFERENCES [dbo].[BenutzerSet]
        ([BenutzerId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [darfMachen_ArbeitId] in table 'darfMachen'
ALTER TABLE [dbo].[darfMachen]
ADD CONSTRAINT [FK_darfMachen_Arbeit]
    FOREIGN KEY ([darfMachen_ArbeitId])
    REFERENCES [dbo].[ArbeitSet]
        ([ArbeitId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_darfMachen_Arbeit'
CREATE INDEX [IX_FK_darfMachen_Arbeit]
ON [dbo].[darfMachen]
    ([darfMachen_ArbeitId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------