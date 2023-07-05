using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDonaMariana.Dominio.ModuloMateria;

namespace TestesDonaMariana.Dominio.ModuloTeste
{
    public interface IRepositorioTeste
    {
        void Inserir(Teste teste);
        void Editar(int id, Teste teste);
        void Excluir(Teste testeSelecionado);
        List<Teste> SelecionarTodos();
        Teste SelecionarPorId(int id);
    }
}
