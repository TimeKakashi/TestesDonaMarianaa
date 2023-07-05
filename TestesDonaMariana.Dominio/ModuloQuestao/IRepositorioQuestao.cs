using TestesDonaMariana.Dominio.Compartilhado;
using TestesDonaMariana.Dominio.ModuloQuestao;

namespace TestesDonaMariana.Dominio.ModuloQuestoes
{
    public interface IRepositorioQuestoes : IRepositorioBase
    {
        void Inserir(Questao novaQuestao);
        void Editar(int id, Questao questao);
        void Excluir(Questao questaoSelecionada);
        List<Questao> SelecionarTodos();
        Questao SelecionarPorId(int id);

        public List<Alternativa> SelecionarAlternativas(Questao questao);
        public void InserirAlternativa(List<Alternativa> alternativas, Questao questao);

        public void EditarAlternativas(Questao questao);
    }
}
