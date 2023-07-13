using FluentResults;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client.Kerberos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDonaMariana.Aplicacao.Compartilhado;
using TestesDonaMariana.Dominio.Compartilhado;
using TestesDonaMariana.Dominio.ModuloDisciplina;
using TestesDonaMariana.Dominio.ModuloQuestao;
using TestesDonaMariana.Dominio.ModuloQuestoes;
using TestesDonaMariana.Infra.Dados.Sql.Compatilhado;
using TestesDonaMariana.Infra.Dados.Sql.ModuloQuestaoSql;

namespace TestesDonaMariana.Aplicacao.ModuloQuestao
{
    public class ServicoQuestao : ServicoBase<Questao>
    {
        private IRepositorioQuestoes repositorioQuestao;

        public override IRepositorioBase<Questao> repositorio => repositorioQuestao;

        public ServicoQuestao(IRepositorioQuestoes repositorioQuestoes)
        {
            this.repositorioQuestao = repositorioQuestoes;
        }

        public override Result Editar(Questao questao)
        {
            Result result = base.Editar(questao);

            return result;
        }

        public override void EditarAlternativas(Questao questaoAtualizada)
        {
            int contador = 0;

            List<Alternativa> alternativasIdCorreto = repositorioQuestao.SelecionarAlternativas(questaoAtualizada);

            foreach (Alternativa item in questaoAtualizada.alternativas)
            {
                item.id = alternativasIdCorreto[contador].id;
                contador++;
            }

            repositorioQuestao.EditarAlternativas(questaoAtualizada);
        }

        public override void InserirAlternativas(Questao q)
        {
            repositorioQuestao.InserirAlternativa(q);
        }

        public Result Inserir(Questao questao)
        {
           Result resultado = base.Inserir(questao);

            return resultado;
        }

        public Result Excluir(Questao questao)
        {
            Result resultado = base.Excluir(questao);

            return resultado;
        }

        public override List<string> ValidarEntidade(Questao item)
        {
            List<string> erros = new List<string>(item.Validar());

            if (repositorioQuestao.SelecionarTodos().Any(q => q.titulo == item.titulo && q.id != item.id))
                erros.Add($"Este nome '{item.titulo}' já está sendo utilizado na aplicação");

            return erros;
        }
    }
}
