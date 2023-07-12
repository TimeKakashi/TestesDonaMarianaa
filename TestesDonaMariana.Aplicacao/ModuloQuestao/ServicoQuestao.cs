using FluentResults;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client.Kerberos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDonaMariana.Dominio.ModuloDisciplina;
using TestesDonaMariana.Dominio.ModuloQuestao;
using TestesDonaMariana.Dominio.ModuloQuestoes;

namespace TestesDonaMariana.Aplicacao.ModuloQuestao
{
    public class ServicoQuestao
    {
        private IRepositorioQuestoes repositorioQuestao;

        public ServicoQuestao(IRepositorioQuestoes repositorioQuestoes)
        {
            this.repositorioQuestao = repositorioQuestoes;
        }

        public Result Editar(Questao questao)
        {
            List<string> erros = ValidarQuestao(questao);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            repositorioQuestao.Editar(questao.id, questao);
            EditarAlternativas(questao);

            return Result.Ok();
        }

        private void EditarAlternativas(Questao questaoAtualizada)
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

        public Result Inserir(Questao questao)
        {
            List<string> erros = ValidarQuestao(questao);

            if(erros.Count() > 0)
                return Result.Fail(erros);

            repositorioQuestao.Inserir(questao);
            repositorioQuestao.InserirAlternativa(questao.alternativas, questao);

            return Result.Ok();
        }

        private List<string> ValidarQuestao(Questao questao)
        {
            List<string> erros = new List<string>(questao.Validar());

            if (repositorioQuestao.SelecionarTodos().Any(q => q.titulo == questao.titulo && q.id != questao.id))
                    erros.Add($"Este nome '{questao.titulo}' já está sendo utilizado na aplicação");

            return erros;
        }

        public Result Excluir(Questao questao)
        {
            List<string> erros = new List<string>();

            try
            {
                repositorioQuestao.Excluir(questao);

                return Result.Ok();

            }catch(SqlException ex)
            {
                if (ex.Message.Contains("FK_TB_Questao_TB_Teste_TB_Questao"))
                    erros.Add("Essa questao esta relacionada com um Teste, n eh possivel exclui-la");

                    return Result.Fail(erros);
            }
        }
    }
}
