﻿using TestesDonaMariana.Dominio.Compartilhado;
using TestesDonaMariana.Dominio.ModuloDisciplina;
using TestesDonaMariana.Dominio.ModuloMateria;
using TestesDonaMariana.Dominio.ModuloQuestoes;

namespace TestesDonaMariana.Dominio.ModuloTeste
{
    public class Teste : EntidadeBase<Teste>, ICloneable
    {
        public string titulo { get; set; }
        public Materia materia { get; set; }
        public Disciplina disciplina { get; set; }
        public int numeroQuestoes { get; set; }
        public DateTime dataCriacao { get; set; }
        public string serie { get; set; }
        public bool recuperacao { get; set; } = false;
        public List<Questao> questoes { get; set; } = new List<Questao>();

        public Teste(Materia materia, Disciplina disciplina, int numeroQuestoes, string serie, int id, string titulo, bool recuperacao)
        {
            this.numeroQuestoes = numeroQuestoes;
            this.materia = materia;
            this.disciplina = disciplina;
            this.serie = serie;
            this.dataCriacao = DateTime.Now.Date;
            this.id = id;
            this.recuperacao = recuperacao;
            this.titulo = titulo;
        }

        public Teste(Materia materia, Disciplina disciplina, int numeroQuestoes, string serie, List<Questao> questoes, string titulo, bool recuperacao)
        {
            this.numeroQuestoes = numeroQuestoes;
            this.materia = materia;
            this.disciplina = disciplina;
            this.serie = serie;
            this.dataCriacao = DateTime.Now.Date;
            this.questoes = questoes;
            this.titulo = titulo;
            this.recuperacao = recuperacao;
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
            this.titulo = registroAtualizado.titulo;
        }

        public override string[] Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(titulo))
                erros.Add("O campo 'Titulo' eh obrigatorio!");

            else if (titulo.Length < 5)
                erros.Add("O campo 'Titulo' necessita ter mais que cinco caracteres!");

            else if (string.IsNullOrEmpty(serie))
                erros.Add("O campo 'Serie' eh obrigatorio!");

            else if (disciplina == null)
                erros.Add("O campo 'Disciplina' eh obrigatorio!");

            else if (numeroQuestoes == 0)
                erros.Add("Nao pode ser feito um teste com 0 questoes!");

            else if (questoes.Count == 0)
                erros.Add("Eh necessario gerar questões!");

            if (recuperacao == false)
            {
                if (materia == null)
                    erros.Add("Caso nao seja uma prova de recuperacao, eh necessario selecionar uma materia");
            }

            return erros.ToArray();
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
                questoes = new List<Questao>(this.questoes),
                titulo = this.titulo
            };

            foreach (Questao questao in this.questoes)
            {
                clone.questoes.Add(questao.Clone() as Questao);
            }

            return clone;
        }

    }
}
