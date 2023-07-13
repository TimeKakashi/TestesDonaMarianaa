using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesDonaMariana.Dominio.Compartilhado
{
    public interface IRepositorioBase<T> where T : EntidadeBase<T>
    {
        void Inserir(T novoRegistro);

        void Editar(int id, T registro);

        void Excluir(T registro);

        List<T> SelecionarTodos();

        T SelecionarPorId(int id);
    }
    
}
