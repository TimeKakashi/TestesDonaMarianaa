using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDonaMariana.Dominio.Compartilhado;

namespace TestesDonaMariana.Dominio.ModuloTeste
{
    public class Teste : EntidadeBase<Teste>
    {
        public override void AtualizarInformacoes(Teste registroAtualizado)
        {
            throw new NotImplementedException();
        }

        public override string[] Validar()
        {
            throw new NotImplementedException();
        }
    }
}
