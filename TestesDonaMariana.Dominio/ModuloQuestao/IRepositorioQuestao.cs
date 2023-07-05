using TestesDonaMariana.Dominio.Compartilhado;

namespace TestesDonaMariana.Dominio.ModuloQuestoes
{
    public interface IRepositorioQuestoes : IRepositorioBase
    {
        void Inserir(Questao novaQuestao);
        void Editar(int id, Questao questao);
        void Excluir(Questao questaoSelecionada);
        List<Questao> SelecionarTodos();
        Questao SelecionarPorId(int id);

        public List<string> SelecionarAlternativas(Questao questao);
        public void InserirAlternativa(List<string> alternativas, Questao questao);
    }
}
