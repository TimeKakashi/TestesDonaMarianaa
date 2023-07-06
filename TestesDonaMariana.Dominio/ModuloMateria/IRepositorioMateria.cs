using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDonaMariana.Dominio.ModuloQuestoes;

namespace TestesDonaMariana.Dominio.ModuloMateria
{
    public interface IRepositorioMateria
    {
        void Inserir(Materia novaMateria);
        void Editar(int id, Materia materiaSelecionada);
        void Excluir(Materia materiaSelecionada);
        List<Materia> SelecionarTodos();
        Materia SelecionarPorId(int id);
    }
}
