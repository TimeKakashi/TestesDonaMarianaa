CREATE TABLE [dbo].[TBTeste] (
    [Id]             INT          IDENTITY (1, 1) NOT NULL,
    [Id_Materia]     INT          NULL,
    [NumeroQuestoes] INT          NOT NULL,
    [Data]           BIGINT       NOT NULL,
    [Id_disciplina]  INT          NOT NULL,
    [Titulo]         VARCHAR (50) NOT NULL,
    [Recuperacao]    BIT          NOT NULL,
    CONSTRAINT [PK_TBTeste] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TBTeste_TB_Materia] FOREIGN KEY ([Id_Materia]) REFERENCES [dbo].[TB_Materia] ([Id])
);







