using FluentResults;
using Microsoft.Data.SqlClient;
using TestesDonaMariana.Dominio.Compartilhado;
using TestesDonaMariana.Dominio.ModuloQuestoes;
using TestesDonaMariana.Infra.Dados.Sql.Compatilhado;
using TestesDonaMariana.Infra.Dados.Sql.ModuloQuestaoSql;

namespace TestesDonaMariana.Aplicacao.Compartilhado
{
    public abstract class ServicoBase<T> where T : EntidadeBase<T>
    {
        public abstract IRepositorioBase<T> repositorio { get; }

        public virtual void InserirAlternativas(T questao) { }

        public virtual void EditarAlternativas(T questao) { }
        public virtual Result Inserir(T item)
        {
            List<string> erros = ValidarEntidade(item);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            repositorio.Inserir(item);

            if(repositorio.GetType() == typeof(RepositorioQuestaoSql))
                InserirAlternativas(item);

            return Result.Ok();
        }

        public virtual Result Editar(T item)
        {
            List<string> erros = ValidarEntidade(item);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            repositorio.Editar(item.id, item);

            if (repositorio.GetType() == typeof(RepositorioQuestaoSql))
                EditarAlternativas(item);

            return Result.Ok();
        }

        public Result Excluir(T item)
        {
            List<string> erros = new List<string>();

            try
            {
                repositorio.Excluir(item);

                return Result.Ok();

            }
            catch (SqlException ex)
            {
                 erros.Add("Nao eh possivel excluir esse item!");

                return Result.Fail(erros);
            }
        }

        public abstract List<string> ValidarEntidade(T item);
    }
}
