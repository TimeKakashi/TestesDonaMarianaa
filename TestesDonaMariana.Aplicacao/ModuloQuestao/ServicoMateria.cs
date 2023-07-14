using TestesDonaMariana.Aplicacao.Compartilhado;
using TestesDonaMariana.Dominio.Compartilhado;
using TestesDonaMariana.Dominio.ModuloMateria;

namespace TestesDonaMariana.Aplicacao.ModuloQuestao
{
    public class ServicoMateria : ServicoBase<Materia>
    {
        private IRepositorioMateria repositorioMateria;
        public override IRepositorioBase<Materia> repositorio => repositorioMateria;

        public ServicoMateria(IRepositorioMateria repositorioMateria)
        {
            this.repositorioMateria = repositorioMateria;
        }

        public override List<string> ValidarEntidade(Materia item)
        {
            List<String> erros = new List<string>();

            if (repositorioMateria.SelecionarTodos().Any(q => q.nome == item.nome && q.id != item.id))
                erros.Add($"Este nome '{item.nome}' já está sendo utilizado na aplicação");

            return erros;
        }
    }
}
