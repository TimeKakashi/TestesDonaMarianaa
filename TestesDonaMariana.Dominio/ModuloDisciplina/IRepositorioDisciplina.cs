using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDonaMariana.Dominio.ModuloTeste;

namespace TestesDonaMariana.Dominio.ModuloDisciplina
{
    public interface IRepositorioDisciplina
    {
        void Inserir(Disciplina disciplina);
        void Editar(int id, Disciplina disciplinaSelecionada);
        void Excluir(Disciplina disciplinaSelecionada);
        List<Disciplina> SelecionarTodos();
        Disciplina SelecionarPorId(int id);
    }
}
