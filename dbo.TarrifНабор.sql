CREATE TABLE [dbo].[TarrifНабор] (
    [ID]    INT          IDENTITY (1, 1) NOT NULL,
    [CW]    DECIMAL (18,6) NOT NULL,
    [HW]    DECIMAL (18,6) NOT NULL,
    [S]     DECIMAL (18,6) NOT NULL,
    [E_T]   DECIMAL (18,6) NOT NULL,
    [E_F]   DECIMAL (18,6) NOT NULL,
    [E_O]   DECIMAL (18,6) NULL,
    [HomID] INT          NOT NULL,
    [Gas]   DECIMAL (18,6) NOT NULL,
    CONSTRAINT [PK_TarrifНабор] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_HomTarrif] FOREIGN KEY ([HomID]) REFERENCES [dbo].[HomItems] ([ID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_FK_HomTarrif]
    ON [dbo].[TarrifНабор]([HomID] ASC);

