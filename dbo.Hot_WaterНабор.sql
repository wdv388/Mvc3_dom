CREATE TABLE [dbo].[Hot_WaterНабор] (
    [ID]    INT          IDENTITY (1, 1) NOT NULL,
    [HW1]   INT          NOT NULL,
    [HW0]   INT          NOT NULL,
    [HWT]   INT          NOT NULL,
    [HWP]   INT          NOT NULL,
    [HWD]   INT          NOT NULL,
    [Sum]   DECIMAL (18,6) NOT NULL,
    [HomID] INT          NOT NULL,
    [Data]  DATETIME     NOT NULL,
    CONSTRAINT [PK_Hot_WaterНабор] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_HomHot_Water] FOREIGN KEY ([HomID]) REFERENCES [dbo].[HomItems] ([ID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_FK_HomHot_Water]
    ON [dbo].[Hot_WaterНабор]([HomID] ASC);

