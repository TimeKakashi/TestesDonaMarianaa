using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDonaMariana.Dominio.Compartilhado;
using TestesDonaMariana.Dominio.ModuloDisciplina;
using TestesDonaMariana.Dominio.ModuloQuestoes;

namespace TestesDonaMariana.Dominio.ModuloMateria
{
    public class Materia : EntidadeBase<Materia>
    {
        public string nome { get; set; }
        public string serie { get; set; }
        public Disciplina disciplina { get; set; }

        public List<Questao> questoes = new List<Questao>(); 

        public Materia(int idMateria, string? nomeMateria, string? nomeSerie, Disciplina disciplina)
        {
            this.id = idMateria;
            this.nome = nomeMateria;
            this.serie = nomeSerie;
            this.disciplina = disciplina;
        }

        public override void AtualizarInformacoes(Materia registroAtualizado)
        {
            throw new NotImplementedException();
        }

        public override string[] Validar()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return this.nome;
        }
    }
}
