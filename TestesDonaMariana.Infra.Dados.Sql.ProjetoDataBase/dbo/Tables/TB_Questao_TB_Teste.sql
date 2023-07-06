CREATE TABLE [dbo].[TB_Questao_TB_Teste] (
    [Id_Questao] INT NOT NULL,
    [Id_Teste]   INT NOT NULL,
    CONSTRAINT [FK_TB_Questao_TB_Teste_TB_Questao] FOREIGN KEY ([Id_Questao]) REFERENCES [dbo].[TB_Questao] ([Id]),
    CONSTRAINT [FK_TB_Questao_TB_Teste_TBTeste] FOREIGN KEY ([Id_Teste]) REFERENCES [dbo].[TBTeste] ([Id])
);

