using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDonaMariana.Dominio.Compartilhado;
using TestesDonaMariana.Dominio.ModuloDisciplina;
using TestesDonaMariana.Dominio.ModuloMateria;
using TestesDonaMariana.Dominio.ModuloQuestoes;

namespace TestesDonaMariana.Dominio.ModuloTeste
{
    public class Teste : EntidadeBase<Teste>, ICloneable
    {

        public Materia materia { get; set; }
        public Disciplina disciplina { get; set; }
        public int numeroQuestoes { get; set; }
        public DateTime dataCriacao { get; set; }
        public string serie { get; set; }
        public List<Questao> questoes { get; set; } = new List<Questao>();

        public Teste(Materia materia, Disciplina disciplina, int numeroQuestoes, string serie)
        {
            this.numeroQuestoes = numeroQuestoes;
            this.materia = materia;
            this.disciplina = disciplina;
            this.serie = serie;
            this.dataCriacao = DateTime.Now.Date;

        }

        public Teste(Materia materia, Disciplina disciplina, int numeroQuestoes, string serie, int id)
        {
            this.numeroQuestoes = numeroQuestoes;
            this.materia = materia;
            this.disciplina = disciplina;
            this.serie = serie;
            this.dataCriacao = DateTime.Now.Date;
            this.id = id;
        }

        public Teste(Materia materia, Disciplina disciplina, int numeroQuestoes, string serie, List<Questao> questoes)
        {
            this.numeroQuestoes = numeroQuestoes;
            this.materia = materia;
            this.disciplina = disciplina;
            this.serie = serie;
            this.dataCriacao = DateTime.Now.Date;
            this.questoes = questoes;
        }

        public Teste()
        {
            
        }

        public override void AtualizarInformacoes(Teste registroAtualizado)
        {
            this.materia = registroAtualizado.materia;
            this.disciplina = registroAtualizado.disciplina;
            this.numeroQuestoes = registroAtualizado.numeroQuestoes;
            this.serie = registroAtualizado.serie;
        }

        public override string[] Validar()
        {
            throw new NotImplementedException();
        }
        public object Clone()
        {
            Teste clone = new Teste
            {
                materia = this.materia,
                disciplina = this.disciplina,
                numeroQuestoes = this.numeroQuestoes,
                dataCriacao = this.dataCriacao,
                serie = this.serie,
                questoes = new List<Questao>(this.questoes.Count)
            };

            foreach (Questao questao in this.questoes)
            {
                clone.questoes.Add(questao.Clone() as Questao);
            }

            return clone;
        }

    }
}
