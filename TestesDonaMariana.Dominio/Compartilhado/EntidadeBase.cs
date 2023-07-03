using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesDonaMariana.Dominio.Compartilhado
{
    public abstract class EntidadeBase<T>
    {
        public int id;

        public abstract void AtualizarInformacoes(T registroAtualizado);

        public abstract string[] Validar();
    }
}
