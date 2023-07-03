CREATE TABLE [dbo].[TB_Alternativa] (
    [Id]          INT          IDENTITY (1, 1) NOT NULL,
    [Alternativa] VARCHAR (30) NOT NULL,
    [Id_Questao]  INT          NOT NULL,
    CONSTRAINT [PK__TBAltern__3214EC07FFC3ACDB] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TBAlternativas_DBQuestao] FOREIGN KEY ([Id_Questao]) REFERENCES [dbo].[TB_Questao] ([Id])
);

