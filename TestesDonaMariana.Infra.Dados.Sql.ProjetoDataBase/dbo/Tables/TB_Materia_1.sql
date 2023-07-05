CREATE TABLE [dbo].[TB_Materia] (
    [Id]            INT          IDENTITY (1, 1) NOT NULL,
    [Id_Disciplina] INT          NOT NULL,
    [Nome]          VARCHAR (50) NOT NULL,
    [Id_Serie]      INT          NOT NULL,
    CONSTRAINT [PK_TB_Materia] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TB_Materia_TB_Disciplina] FOREIGN KEY ([Id_Disciplina]) REFERENCES [dbo].[TB_Disciplina] ([Id]),
    CONSTRAINT [FK_TB_Materia_TB_Serie] FOREIGN KEY ([Id_Serie]) REFERENCES [dbo].[TB_Serie] ([Id])
);



