
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/27/2020 18:51:47
-- Generated from EDMX file: C:\Users\Prime\Documents\Visual Studio 2012\Projects\Mvc3_dom\MvcHOME\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [C:\Users\Prime\Documents\Visual Studio 2012\Projects\Mvc3_dom\MvcHOME\App_Data\Database_baseDOM.mdf];
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
IF OBJECT_ID(N'[dbo].[FK_HomBenefit]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Benefit] DROP CONSTRAINT [FK_HomBenefit];
GO
IF OBJECT_ID(N'[dbo].[FK_HomGas]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GasНабор] DROP CONSTRAINT [FK_HomGas];
GO
IF OBJECT_ID(N'[dbo].[FK_HomLimits]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LimitsНабор] DROP CONSTRAINT [FK_HomLimits];
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
IF OBJECT_ID(N'[dbo].[Benefit]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Benefit];
GO
IF OBJECT_ID(N'[dbo].[GasНабор]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GasНабор];
GO
IF OBJECT_ID(N'[dbo].[LimitsНабор]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LimitsНабор];
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
    [Sum] decimal(18,0)  NOT NULL,
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
    [Sum] decimal(18,0)  NOT NULL,
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
    [Privelege] int  NOT NULL,
    [toLim] int  NOT NULL,
    [fromLim] int  NOT NULL,
    [overLim] int  NULL,
    [SumP] decimal(18,0)  NOT NULL,
    [SumT] decimal(18,0)  NOT NULL,
    [SumF] decimal(18,0)  NOT NULL,
    [Sum] decimal(18,0)  NOT NULL,
    [SumO] decimal(18,0)  NULL,
    [Data] datetime  NOT NULL,
    [HomID] int  NOT NULL
);
GO

-- Creating table 'TarrifНабор'
CREATE TABLE [dbo].[TarrifНабор] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [CW] decimal(18,0)  NOT NULL,
    [HW] decimal(18,0)  NOT NULL,
    [S] decimal(18,0)  NOT NULL,
    [E_T] decimal(18,0)  NOT NULL,
    [E_F] decimal(18,0)  NOT NULL,
    [E_O] decimal(18,0)  NULL,
    [HomID] int  NOT NULL,
    [Gas] decimal(18,0)  NOT NULL
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
    [Sum] decimal(18,0)  NOT NULL,
    [Data] datetime  NOT NULL,
    [HomID] int  NOT NULL
);
GO

-- Creating table 'Benefit'
CREATE TABLE [dbo].[Benefit] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Privilege] smallint  NOT NULL,
    [Persons] smallint  NOT NULL,
    [E] decimal(18,0)  NOT NULL,
    [CW] decimal(18,0)  NOT NULL,
    [HW] decimal(18,0)  NOT NULL,
    [S] decimal(18,0)  NOT NULL,
    [HomID] int  NOT NULL
);
GO

-- Creating table 'GasНабор'
CREATE TABLE [dbo].[GasНабор] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [GC] int  NOT NULL,
    [GP] int  NOT NULL,
    [GD] int  NOT NULL,
    [Privelege] int  NULL,
    [Sum] decimal(18,0)  NOT NULL,
    [Data] datetime  NOT NULL,
    [HomID] int  NOT NULL
);
GO

-- Creating table 'LimitsНабор'
CREATE TABLE [dbo].[LimitsНабор] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [E_L1] int  NOT NULL,
    [E_L2] int  NOT NULL,
    [E_L3] int  NOT NULL,
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

-- Creating primary key on [ID] in table 'Benefit'
ALTER TABLE [dbo].[Benefit]
ADD CONSTRAINT [PK_Benefit]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'GasНабор'
ALTER TABLE [dbo].[GasНабор]
ADD CONSTRAINT [PK_GasНабор]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'LimitsНабор'
ALTER TABLE [dbo].[LimitsНабор]
ADD CONSTRAINT [PK_LimitsНабор]
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
GO

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
GO

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
GO

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
GO

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
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HomSewage'
CREATE INDEX [IX_FK_HomSewage]
ON [dbo].[SewageНабор]
    ([HomID]);
GO

-- Creating foreign key on [HomID] in table 'Benefit'
ALTER TABLE [dbo].[Benefit]
ADD CONSTRAINT [FK_HomBenefit]
    FOREIGN KEY ([HomID])
    REFERENCES [dbo].[HomItems]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HomBenefit'
CREATE INDEX [IX_FK_HomBenefit]
ON [dbo].[Benefit]
    ([HomID]);
GO

-- Creating foreign key on [HomID] in table 'GasНабор'
ALTER TABLE [dbo].[GasНабор]
ADD CONSTRAINT [FK_HomGas]
    FOREIGN KEY ([HomID])
    REFERENCES [dbo].[HomItems]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HomGas'
CREATE INDEX [IX_FK_HomGas]
ON [dbo].[GasНабор]
    ([HomID]);
GO

-- Creating foreign key on [HomID] in table 'LimitsНабор'
ALTER TABLE [dbo].[LimitsНабор]
ADD CONSTRAINT [FK_HomLimits]
    FOREIGN KEY ([HomID])
    REFERENCES [dbo].[HomItems]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HomLimits'
CREATE INDEX [IX_FK_HomLimits]
ON [dbo].[LimitsНабор]
    ([HomID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------