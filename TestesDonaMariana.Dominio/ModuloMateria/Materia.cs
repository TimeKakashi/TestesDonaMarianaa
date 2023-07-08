using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public Disciplina disciplina { get; set; }
        public Serie serie { get; set; }

        public List<Questao> questoes { get; set; } = new List<Questao>();

  
        public Materia(string nome, Disciplina Disciplina, Serie serie) 
        {
            this.nome = nome;
            this.disciplina = Disciplina;
            this.serie = serie;
        }
        public Materia(int idMateria, string nome, Serie serie, Disciplina disciplina)
        {
            this.id = idMateria;
            this.nome = nome;
            this.serie = serie;
            this.disciplina = disciplina;
        }
        public override void AtualizarInformacoes(Materia registroAtualizado)
        {
            this.id = registroAtualizado.id;
            this.nome = registroAtualizado.nome;
            this.serie = registroAtualizado.serie;
        }

        public override string ToString()
        {
            return $"{nome}";
        }

        public override string[] Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(nome))
                erros.Add("O campo 'Nome' é obrigatório");

            else if (nome.Length < 4)
                erros.Add("O campo 'Nome' deve conter no mínimo 4 caracteres");

            else if (disciplina == null)
                erros.Add("O campo 'Disciplina' eh obrigatorio!");

            else if (serie == null)
                erros.Add("O campo 'Serie' eh obrigatorio!");

            return erros.ToArray();
        }
    }
}
