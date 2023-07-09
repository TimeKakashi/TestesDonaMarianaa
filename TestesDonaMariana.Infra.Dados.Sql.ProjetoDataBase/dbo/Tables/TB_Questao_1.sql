CREATE TABLE [dbo].[TB_Questao] (
    [Id]                 INT           IDENTITY (1, 1) NOT NULL,
    [Titulo]             VARCHAR (300) NOT NULL,
    [Id_Materia]         INT           NOT NULL,
    [AlternativaCorreta] INT           NOT NULL,
    CONSTRAINT [PK__DBQuesta__3214EC07F9D13C1C] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TB_Questao_TB_Materia] FOREIGN KEY ([Id_Materia]) REFERENCES [dbo].[TB_Materia] ([Id])
);





