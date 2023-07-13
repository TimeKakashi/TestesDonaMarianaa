using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDonaMariana.Dominio.Compartilhado;
using TestesDonaMariana.Dominio.ModuloQuestoes;
using TestesDonaMariana.Dominio.ModuloTeste;

namespace TestesDonaMariana.Dominio.ModuloDisciplina
{
    public interface IRepositorioDisciplina : IRepositorioBase<Disciplina>
    {
        void Inserir(Disciplina disciplina);
        void Editar(int id, Disciplina disciplina);
        void Excluir(Disciplina disciplinaSelecionado);
        List<Disciplina> SelecionarTodos();
        Disciplina SelecionarPorId(int id);
        List<Disciplina> VerificarTestesNaDisciplina(Disciplina disciplina);
        List<Disciplina> VerificarMateriasNaDisciplina(Disciplina disciplina);
    }
}

