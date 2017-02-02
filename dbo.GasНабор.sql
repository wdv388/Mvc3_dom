CREATE TABLE [dbo].[GasНабор] (
    [ID]        INT          IDENTITY (1, 1) NOT NULL,
    [GC]        INT          NOT NULL,
    [GP]        INT          NOT NULL,
    [GD]        INT          NOT NULL,
    [Privelege] INT          NULL,
    [Sum]       DECIMAL (18,6) NOT NULL,
    [Data]      DATETIME     NOT NULL,
    [HomID]     INT          NOT NULL,
    CONSTRAINT [PK_GasНабор] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_HomGas] FOREIGN KEY ([HomID]) REFERENCES [dbo].[HomItems] ([ID])
);


GO
CREATE NONCLUSTERED INDEX [IX_FK_HomGas]
    ON [dbo].[GasНабор]([HomID] ASC);

