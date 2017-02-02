CREATE TABLE [dbo].[SewageНабор] (
    [ID]    INT          IDENTITY (1, 1) NOT NULL,
    [S1]    INT          NOT NULL,
    [S0]    INT          NOT NULL,
    [ST]    INT          NOT NULL,
    [SP]    INT          NOT NULL,
    [SD]    INT          NOT NULL,
    [Sum]   DECIMAL (18,6) NOT NULL,
    [Data]  DATETIME     NOT NULL,
    [HomID] INT          NOT NULL,
    CONSTRAINT [PK_SewageНабор] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_HomSewage] FOREIGN KEY ([HomID]) REFERENCES [dbo].[HomItems] ([ID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_FK_HomSewage]
    ON [dbo].[SewageНабор]([HomID] ASC);

