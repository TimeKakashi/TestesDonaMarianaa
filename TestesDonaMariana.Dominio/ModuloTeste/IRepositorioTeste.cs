﻿using TestesDonaMariana.Dominio.ModuloQuestoes;

namespace TestesDonaMariana.Dominio.ModuloTeste
{
    public interface IRepositorioTeste
    {
        void Inserir(Teste teste, List<Questao> questoes);
        void Editar(int id, Teste teste);
        void Excluir(Teste testeSelecionado);
        List<Teste> SelecionarTodos();
        Teste SelecionarPorId(int id);
        List<Questao> SelecionarQuestoes(Teste teste1);
    }
}
