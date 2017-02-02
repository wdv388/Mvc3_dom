CREATE TABLE [dbo].[ElectricityНабор] (
    [ID]        INT          IDENTITY (1, 1) NOT NULL,
    [EC]        INT          NOT NULL,
    [EP]        INT          NOT NULL,
    [ED]        INT          NOT NULL,
    [Privelege] INT          NOT NULL,
    [toLim]     INT          NOT NULL,
    [fromLim]   INT          NOT NULL,
    [overLim]   INT          NULL,
    [SumP]      DECIMAL (18,6) NOT NULL,
    [SumT]      DECIMAL (18,6) NOT NULL,
    [SumF]      DECIMAL (18,6) NOT NULL,
    [Sum]       DECIMAL (18,6) NOT NULL,
    [SumO]      DECIMAL (18,6) NULL,
    [Data]      DATETIME     NOT NULL,
    [HomID]     INT          NOT NULL,
    CONSTRAINT [PK_ElectricityНабор] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_HomElectricity] FOREIGN KEY ([HomID]) REFERENCES [dbo].[HomItems] ([ID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_FK_HomElectricity]
    ON [dbo].[ElectricityНабор]([HomID] ASC);

