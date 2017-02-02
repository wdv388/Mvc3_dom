CREATE TABLE [dbo].[Benefit] (
    [ID]        INT          IDENTITY (1, 1) NOT NULL,
    [Privilege] SMALLINT     NOT NULL,
    [Persons]   SMALLINT     NOT NULL,
    [E]         DECIMAL (18,6) NOT NULL,
    [CW]        DECIMAL (18,6) NOT NULL,
    [HW]        DECIMAL (18,6) NOT NULL,
    [S]         DECIMAL (18,6) NOT NULL,
    [HomID]     INT          NOT NULL,
    CONSTRAINT [PK_Benefit] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_HomBenefit] FOREIGN KEY ([HomID]) REFERENCES [dbo].[HomItems] ([ID])
);


GO
CREATE NONCLUSTERED INDEX [IX_FK_HomBenefit]
    ON [dbo].[Benefit]([HomID] ASC);

