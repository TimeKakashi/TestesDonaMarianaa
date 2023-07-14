using TestesDonaMariana.Aplicacao.Compartilhado;
using TestesDonaMariana.Dominio.Compartilhado;
using TestesDonaMariana.Dominio.ModuloTeste;

namespace TestesDonaMariana.Aplicacao.ModuloQuestao
{
    public class ServicoTeste : ServicoBase<Teste>
    {
        private IRepositorioTeste repositorioTeste;

        public ServicoTeste(IRepositorioTeste repositorioTeste)
        {
            this.repositorioTeste = repositorioTeste;
        }

        public override IRepositorioBase<Teste> repositorio => repositorioTeste;

        public override List<string> ValidarEntidade(Teste item)
        {
            List<string> erros = new List<string>();

            if (repositorioTeste.SelecionarTodos().Any(t => t.titulo == item.titulo))
                erros.Add($"Este titulo '{item.titulo}' já está sendo utilizado na aplicação");

            return erros;
        }
    }
}
