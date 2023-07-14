using TestesDonaMariana.Dominio.Compartilhado;
using TestesDonaMariana.Dominio.ModuloMateria;

namespace TestesDonaMariana.Dominio.ModuloDisciplina
{
    public class Disciplina : EntidadeBase<Disciplina>
    {

        public string nome;
        public List<Materia> listaMateria { get; set; } = new List<Materia>();

        public Disciplina(string nome, int id)
        {
            this.nome = nome;
            this.id = id;
        }
        public Disciplina(string nome)
        {
            this.nome = nome;

        }

        public Disciplina()
        {
        }

        public override void AtualizarInformacoes(Disciplina registroAtualizado)
        {
            throw new NotImplementedException();
        }

        public override string[] Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(nome))
                erros.Add("Campo nome esta invalido!");

            else if (nome.Length < 5)
                erros.Add("Campo nome esta invalido, deve possuir mais que quatro letras");

            return erros.ToArray();
        }

        public override string ToString()
        {
            return nome;
        }
    }
}
