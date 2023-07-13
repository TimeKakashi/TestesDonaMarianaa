using TestesDonaMariana.Dominio.Compartilhado;
using TestesDonaMariana.Dominio.ModuloQuestoes;

namespace TestesDonaMariana.Dominio.ModuloTeste
{
    public interface IRepositorioTeste : IRepositorioBase<Teste>
    {
        void Inserir(Teste teste, List<Questao> questoes);
        void Editar(int id, Teste teste);
        void Excluir(Teste testeSelecionado);
        List<Teste> SelecionarTodos();
        Teste SelecionarPorId(int id);
        List<Questao> SelecionarQuestoesPorMateria(Teste teste);
        List<Questao> SelecionarQuestoesTeste(Teste teste);
        bool TituloExistente(string titulo);
    }

}
