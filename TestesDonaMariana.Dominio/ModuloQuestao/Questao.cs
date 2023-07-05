using System;

using TestesDonaMariana.Dominio.Compartilhado;
using TestesDonaMariana.Dominio.ModuloMateria;
using TestesDonaMariana.Dominio.ModuloQuestao;
using TestesDonaMariana.WinForm.ModuloQuestao;

namespace TestesDonaMariana.Dominio.ModuloQuestoes
{
    public class Questao : EntidadeBase<Questao>
    {
        public EnumAlternativaCorreta alternativaCorretaENUM { get; set; }
        public string titulo { get; set; }
        public List<Alternativa> alternativas { get; set; } = new List<Alternativa>();
        public string alternativaCorreta { get; set; }
        public Materia materia { get; set; }

        public Questao(string titulo, List<Alternativa> alternativas, EnumAlternativaCorreta alternativaCorrea, Materia materia)
        {
            this.titulo = titulo;
            this.alternativas = alternativas;
            this.alternativaCorretaENUM = alternativaCorrea;
            this.materia = materia;
        }

        public Questao(int idQuestao,string titulo,Materia materia, EnumAlternativaCorreta alternativaCorreta)
        {
            this.titulo = titulo;
            this.alternativaCorretaENUM = alternativaCorreta;
            this.materia = materia;
            this.id = idQuestao;
        }

        public override void AtualizarInformacoes(Questao registroAtualizado)
        {
            this.titulo = registroAtualizado.titulo;
            this.alternativas = registroAtualizado.alternativas;
            this.alternativaCorreta = registroAtualizado.alternativaCorreta;
            this.materia = registroAtualizado.materia;
        }

        public override string[] Validar()
        {
            List<string> erros = new List<string>();

            if (titulo.Length < 5)
                erros.Add("O Titulo deve ter mais que 5 letras");

            else if (alternativas.Count < 2)
                erros.Add("O numero minimo de 'alternativas' eh 2");

            else if (alternativaCorreta == null)
                erros.Add("O campo 'alternativa correta' eh obrigatorio!");

            else if (materia == null)
                erros.Add("O campo 'materia' eh obrigatorio");

            return erros.ToArray();
        }
    }
}
