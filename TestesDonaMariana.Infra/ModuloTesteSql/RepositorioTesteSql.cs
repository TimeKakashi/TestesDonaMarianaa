using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDonaMariana.Dominio.ModuloQuestoes;
using TestesDonaMariana.Dominio.ModuloTeste;
using TestesDonaMariana.Infra.Dados.Sql.Compatilhado;

namespace TestesDonaMariana.Infra.Dados.Sql.ModuloTesteSql
{
    public class RepositorioTesteSql : RepositorioEmSqlBase<Teste, MapeadorTeste>, IRepositorioTeste
    {
        protected override string sqlInserir => @"INSERT INTO [TBTeste]
												(
													[Id_disciplina],
													[Id_Materia],
													[Data],
													[NumeroQuestoes]
												)
												VALUES
												(
													@ID_DISCIPLINA,
													@ID_MATERIA,
													@DATA,
													@NUMERO_QUESTAO
												)
												SELECT SCOPE_IDENTITY();";

		private const string AdicionarQuestoesTeste = @"INSERT INTO [TB_QUESTAO_TB_TESTE]
													(
														[ID_QUESTAO],
														[ID_TESTE]
													)
													VALUES
													(
														@ID_QUESTAO,
														@ID_TESTE
													)
													";

		private const string RemoverQuestao = @"DELETE FROM 
													[TB_QUESTAO_TB_TESTE]
												WHERE 
													[ID_QUESTAO] = @ID_QUESTAO
													AND
													[ID_TESTE] = @ID_TESTE";
        protected override string sqlEditar => throw new NotImplementedException();

        protected override string sqlExcluir => throw new NotImplementedException();

        protected override string sqlSelecionarTodos => @"SELECT 
	
															T.[Data]				DATA_CRIACAO,
															T.[Id_disciplina]		ID_DISCIPLINA,
															T.[Id_Materia]			ID_MATERIA,
															T.[NumeroQuestoes]		NUMERO_QUESTAO,
															T.[Id]					ID_TESTE,

															D.Nome					NOME_DISCIPLINA,

															M.Nome					NOME_MATERIA,
															M.Id_Serie				ID_SERIE,

															S.serie					SERIE

														FROM
															[TBTeste] as T
														inner join
															[TB_Disciplina] as D
														ON
															T.[Id_disciplina] = D.[Id]
														inner join	
															[TB_Materia] as M
														ON
															M.Id = T.Id_Materia
														inner join	
															[TB_Serie] as S
														ON
															S.Id = M.Id_Serie

														";

		protected override string sqlSelecionarPorId => @"SELECT 
	
															T.[Data]				DATA_CRIACAO,
															T.[Id_disciplina]		ID_DISCIPLINA,
															T.[Id_Materia]			ID_MATERIA,
															T.[NumeroQuestoes]		NUMERO_QUESTAO,
															T.[Id]					ID_TESTE,

															D.Nome					NOME_DISCIPLINA,

															M.Nome					NOME_MATERIA,
															M.Id_Serie				ID_SERIE,

															S.serie					SERIE

														FROM
															[TBTeste] as T
														inner join
															[TB_Disciplina] as D
														ON
															T.[Id_disciplina] = D.[Id]
														inner join	
															[TB_Materia] as M
														ON
															M.Id = T.Id_Materia
														inner join	
															[TB_Serie] as S
														ON
															S.Id = M.Id_Serie
														WHERE
															T.[ID] = @ID"
                                                        ;

        public void Inserir(Teste novoRegistro, List<Questao> questoes)
        {
			base.Inserir(novoRegistro);

			foreach(Questao questao in novoRegistro.questoes)
			{
				AdicionarQuestoes(novoRegistro, questao);
			}
        }

        private void AdicionarQuestoes(Teste teste, Questao questao)
		{
            SqlConnection conexaoBanco = new SqlConnection(enderecoBanco);
            conexaoBanco.Open();

            SqlCommand adicionarItem = conexaoBanco.CreateCommand();
            adicionarItem.CommandText = AdicionarQuestoesTeste;

            adicionarItem.Parameters.AddWithValue("ID_QUESTAO", questao.id);
            adicionarItem.Parameters.AddWithValue("ID_TESTE", teste.id);

            adicionarItem.ExecuteNonQuery();

            conexaoBanco.Close();
        }
    }
}
