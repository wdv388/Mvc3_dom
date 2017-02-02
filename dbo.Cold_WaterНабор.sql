CREATE TABLE [dbo].[Cold_WaterНабор] (
    [ID]    INT          IDENTITY (1, 1) NOT NULL,
    [CW1]   INT          NOT NULL,
    [CW0]   INT          NOT NULL,
    [CWT]   INT          NOT NULL,
    [CWP]   INT          NOT NULL,
    [CWD]   INT          NOT NULL,
    [Sum]   DECIMAL (18,6) NOT NULL,
    [HomID] INT          NOT NULL,
    [Data]  DATETIME     NOT NULL,
    CONSTRAINT [PK_Cold_WaterНабор] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_HomCold_Water] FOREIGN KEY ([HomID]) REFERENCES [dbo].[HomItems] ([ID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_FK_HomCold_Water]
    ON [dbo].[Cold_WaterНабор]([HomID] ASC);

