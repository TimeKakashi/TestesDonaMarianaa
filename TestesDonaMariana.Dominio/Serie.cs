using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDonaMariana.Dominio.Compartilhado;

namespace TestesDonaMariana.Dominio
{
    public class Serie : EntidadeBase<Serie>
    {
        public string nome { get; set; }
        public Serie(string? nomeSerie, int idSerie)
        {
            nome = nomeSerie;
            id = idSerie;
        }

        public Serie()
        {
        }

        public override void AtualizarInformacoes(Serie registroAtualizado)
        {
            throw new NotImplementedException();
        }

        public override string[] Validar()
        {
            throw new NotImplementedException();
        }
    }
}
