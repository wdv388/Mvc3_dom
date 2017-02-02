
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 09/19/2014 13:23:36
-- Generated from EDMX file: C:\Users\max\Documents\Visual Studio 2012\Projects\Mvc3_dom\MvcDOM\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [C:\USERS\MAX\DOCUMENTS\VISUAL STUDIO 2012\PROJECTS\MVC3_DOM\MVCDOM\APP_DATA\DATABASE_BASEDOM.MDF];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_HomCold_Water]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cold_WaterНабор] DROP CONSTRAINT [FK_HomCold_Water];
GO
IF OBJECT_ID(N'[dbo].[FK_HomHot_Water]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Hot_WaterНабор] DROP CONSTRAINT [FK_HomHot_Water];
GO
IF OBJECT_ID(N'[dbo].[FK_HomElectricity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ElectricityНабор] DROP CONSTRAINT [FK_HomElectricity];
GO
IF OBJECT_ID(N'[dbo].[FK_HomTarrif]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TarrifНабор] DROP CONSTRAINT [FK_HomTarrif];
GO
IF OBJECT_ID(N'[dbo].[FK_HomSewage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SewageНабор] DROP CONSTRAINT [FK_HomSewage];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[HomItems]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HomItems];
GO
IF OBJECT_ID(N'[dbo].[Cold_WaterНабор]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cold_WaterНабор];
GO
IF OBJECT_ID(N'[dbo].[Hot_WaterНабор]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Hot_WaterНабор];
GO
IF OBJECT_ID(N'[dbo].[ElectricityНабор]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ElectricityНабор];
GO
IF OBJECT_ID(N'[dbo].[TarrifНабор]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TarrifНабор];
GO
IF OBJECT_ID(N'[dbo].[SewageНабор]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SewageНабор];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'HomItems'
CREATE TABLE [dbo].[HomItems] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Apartament_naber] int  NOT NULL,
    [Benefit] bit  NOT NULL,
    [Gas] bit  NOT NULL
);
GO

-- Creating table 'Cold_WaterНабор'
CREATE TABLE [dbo].[Cold_WaterНабор] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [CW1] int  NOT NULL,
    [CW0] int  NOT NULL,
    [CWT] int  NOT NULL,
    [CWP] int  NOT NULL,
    [CWD] int  NOT NULL,
    [Sum] decimal(18,4)  NOT NULL,
    [HomID] int  NOT NULL,
    [Data] datetime  NOT NULL
);
GO

-- Creating table 'Hot_WaterНабор'
CREATE TABLE [dbo].[Hot_WaterНабор] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [HW1] int  NOT NULL,
    [HW0] int  NOT NULL,
    [HWT] int  NOT NULL,
    [HWP] int  NOT NULL,
    [HWD] int  NOT NULL,
    [Sum] decimal(18,4)  NOT NULL,
    [HomID] int  NOT NULL,
    [Data] datetime  NOT NULL
);
GO

-- Creating table 'ElectricityНабор'
CREATE TABLE [dbo].[ElectricityНабор] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [EC] int  NOT NULL,
    [EP] int  NOT NULL,
    [ED] int  NOT NULL,
    [L150_250] int  NOT NULL,
    [upL150_250] int  NOT NULL,
    [Sum] decimal(18,4)  NOT NULL,
    [HomID] int  NOT NULL,
    [Data] datetime  NOT NULL
);
GO

-- Creating table 'TarrifНабор'
CREATE TABLE [dbo].[TarrifНабор] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [CW] decimal(18,4)  NOT NULL,
    [HW] decimal(18,4)  NOT NULL,
    [E] decimal(18,4)  NOT NULL,
    [HomID] int  NOT NULL,
    [upEL150_250] decimal(18,4)  NOT NULL,
    [S] decimal(18,4)  NOT NULL
);
GO

-- Creating table 'SewageНабор'
CREATE TABLE [dbo].[SewageНабор] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [S1] int  NOT NULL,
    [S0] int  NOT NULL,
    [ST] int  NOT NULL,
    [SP] int  NOT NULL,
    [SD] int  NOT NULL,
    [Sum] decimal(18,4)  NOT NULL,
    [Data] datetime  NOT NULL,
    [HomID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'HomItems'
ALTER TABLE [dbo].[HomItems]
ADD CONSTRAINT [PK_HomItems]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Cold_WaterНабор'
ALTER TABLE [dbo].[Cold_WaterНабор]
ADD CONSTRAINT [PK_Cold_WaterНабор]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Hot_WaterНабор'
ALTER TABLE [dbo].[Hot_WaterНабор]
ADD CONSTRAINT [PK_Hot_WaterНабор]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'ElectricityНабор'
ALTER TABLE [dbo].[ElectricityНабор]
ADD CONSTRAINT [PK_ElectricityНабор]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'TarrifНабор'
ALTER TABLE [dbo].[TarrifНабор]
ADD CONSTRAINT [PK_TarrifНабор]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'SewageНабор'
ALTER TABLE [dbo].[SewageНабор]
ADD CONSTRAINT [PK_SewageНабор]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [HomID] in table 'Cold_WaterНабор'
ALTER TABLE [dbo].[Cold_WaterНабор]
ADD CONSTRAINT [FK_HomCold_Water]
    FOREIGN KEY ([HomID])
    REFERENCES [dbo].[HomItems]
        ([ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_HomCold_Water'
CREATE INDEX [IX_FK_HomCold_Water]
ON [dbo].[Cold_WaterНабор]
    ([HomID]);
GO

-- Creating foreign key on [HomID] in table 'Hot_WaterНабор'
ALTER TABLE [dbo].[Hot_WaterНабор]
ADD CONSTRAINT [FK_HomHot_Water]
    FOREIGN KEY ([HomID])
    REFERENCES [dbo].[HomItems]
        ([ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_HomHot_Water'
CREATE INDEX [IX_FK_HomHot_Water]
ON [dbo].[Hot_WaterНабор]
    ([HomID]);
GO

-- Creating foreign key on [HomID] in table 'ElectricityНабор'
ALTER TABLE [dbo].[ElectricityНабор]
ADD CONSTRAINT [FK_HomElectricity]
    FOREIGN KEY ([HomID])
    REFERENCES [dbo].[HomItems]
        ([ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_HomElectricity'
CREATE INDEX [IX_FK_HomElectricity]
ON [dbo].[ElectricityНабор]
    ([HomID]);
GO

-- Creating foreign key on [HomID] in table 'TarrifНабор'
ALTER TABLE [dbo].[TarrifНабор]
ADD CONSTRAINT [FK_HomTarrif]
    FOREIGN KEY ([HomID])
    REFERENCES [dbo].[HomItems]
        ([ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_HomTarrif'
CREATE INDEX [IX_FK_HomTarrif]
ON [dbo].[TarrifНабор]
    ([HomID]);
GO

-- Creating foreign key on [HomID] in table 'SewageНабор'
ALTER TABLE [dbo].[SewageНабор]
ADD CONSTRAINT [FK_HomSewage]
    FOREIGN KEY ([HomID])
    REFERENCES [dbo].[HomItems]
        ([ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_HomSewage'
CREATE INDEX [IX_FK_HomSewage]
ON [dbo].[SewageНабор]
    ([HomID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------