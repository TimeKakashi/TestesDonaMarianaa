﻿using TestesDonaMariana.Dominio.Compartilhado;
using TestesDonaMariana.Dominio.ModuloDisciplina;
using TestesDonaMariana.Dominio.ModuloQuestoes;

namespace TestesDonaMariana.Dominio.ModuloMateria
{
    public interface IRepositorioMateria : IRepositorioBase<Materia>
    {
        void Inserir(Materia novaMateria);
        void Editar(int id, Materia materiaSelecionada);
        void Excluir(Materia materiaSelecionada);
        List<Materia> SelecionarTodos();
        Materia SelecionarPorId(int id);
        List<Questao> SelecionarQuestoesMateria(Materia materia);
        List<Materia> SelecionarMateriasDaDisciplina(Disciplina? disciplina);
        void InserirSeries();
        Serie SelecionarSerieNome(string nome);
    }
}
