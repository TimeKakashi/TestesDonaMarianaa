using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDonaMariana.Dominio.ModuloMateria;
using TestesDonaMariana.Dominio.ModuloQuestao;
using TestesDonaMariana.Dominio.ModuloQuestoes;
using TestesDonaMariana.Dominio.ModuloTeste;
using TestesDonaMariana.Infra.Dados.Sql.Compatilhado;
using TestesDonaMariana.Infra.Dados.Sql.ModuloMateriaSql;
using TestesDonaMariana.Infra.Dados.Sql.ModuloQuestaoSql;
using static System.Net.Mime.MediaTypeNames;

namespace TestesDonaMariana.Infra.Dados.Sql.ModuloTesteSql
{
    public class RepositorioTesteSql : RepositorioEmSqlBase<Teste, MapeadorTeste>, IRepositorioTeste
    {
        protected override string sqlInserir => @"INSERT INTO [TBTeste]
												(
													[Id_disciplina],
													[Id_Materia],
													[Data],
													[NumeroQuestoes],
													[Titulo],
													[Recuperacao]
												)
												VALUES
												(
													@ID_DISCIPLINA,
													@ID_MATERIA,
													@DATA,
													@NUMERO_QUESTAO,
													@TITULO_TESTE,
													@RECUPERACAO
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

		protected override string sqlExcluir => @"DELETE FROM TBTeste WHERE TBTeste.Id = @ID";

        protected override string sqlSelecionarTodos => @"SELECT 
	
															T.[Data]				DATA_CRIACAO,
															T.[Id_disciplina]		ID_DISCIPLINA,
															T.[Id_Materia]			ID_MATERIA,
															T.[NumeroQuestoes]		NUMERO_QUESTAO,
															T.[Id]					ID_TESTE,
															T.[Titulo]				TITULO_TESTE,
															T.[Recuperacao]			RECUPERACAO,

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
														left join
															[TB_Materia] as M
														ON
															M.Id = T.Id_Materia
														left join	
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
															T.[Titulo]				TITULO_TESTE,
															T.[Recuperacao]			RECUPERACAO,

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
														left join	
															[TB_Materia] as M
														ON
															M.Id = T.Id_Materia
														left join	
															[TB_Serie] as S
														ON
															S.Id = M.Id_Serie
														WHERE
															T.[ID] = @ID"
                                                        ;

		private const string sqlSelecionarQuestoesPorMateria = @"SELECT 
																	Q.[Id]					ID_QUESTAO,
																	Q.[Titulo]				TITULO_QUESTAO,
																	Q.[AlternativaCorreta]	ALTERNATIVA_CORRETA,
																	Q.[Id_Materia]			QUESTAO_ID_MATERIA,

																	M.[Nome]				NOME_MATERIA,
																	M.[Id_Disciplina]		MATERIA_ID_DISCIPLINA,
																	M.[Id_Serie]			MATERIA_ID_SERIE,
		
																	D.[Nome]				NOME_DISCIPLINA,

																	S.[serie]				SERIE_NOME,
																	S.[ID]					ID_SERIE
				

																	FROM 
																		[TB_Questao] as Q
																	Inner Join 
																		[TB_Materia] as M 
																	ON 
																		Q.Id_Materia = M.Id
																	Inner Join
																		[TB_Disciplina] as D
																	ON
																		M.Id_Disciplina = D.Id
																	Inner Join
																		[TB_Serie] as S
																	ON
																		M.Id_Serie = S.Id
																	Inner Join 
																		TB_Questao_TB_Teste as QT
																	ON 
																		QT.Id_Questao = Q.Id
																	Inner Join 
																		TBTeste as T
																	ON 
																		T.Id_Materia = M.Id
																	where 
																		T.id = @ID_TESTE";

		private const string sqlSelecionarQuestoesTeste = @"SELECT 
																		Q.[Id]					ID_QUESTAO,
																		Q.[Titulo]				TITULO_QUESTAO,
																		Q.[AlternativaCorreta]	ALTERNATIVA_CORRETA,
																		Q.[Id_Materia]			QUESTAO_ID_MATERIA,

																		M.[Nome]				NOME_MATERIA,
																		M.[Id_Disciplina]		MATERIA_ID_DISCIPLINA,
																		M.[Id_Serie]			MATERIA_ID_SERIE,
		
																		D.[Nome]				NOME_DISCIPLINA,

																		S.[serie]				SERIE_NOME,
																		S.[ID]					ID_SERIE
				

																		FROM 
																			[TB_Questao] as Q
																		left Join 
																			[TB_Materia] as M 
																		ON 
																			Q.Id_Materia = M.Id
																		Inner Join
																			[TB_Disciplina] as D
																		ON
																			M.Id_Disciplina = D.Id
																		left Join
																			[TB_Serie] as S
																		ON
																			M.Id_Serie = S.Id
																		Inner Join 
																			TB_Questao_TB_Teste as QT
																		ON 
																			QT.Id_Questao = Q.Id
																		Inner Join 
																			TBTeste as T
																		ON 
																			QT.Id_Teste = T.Id
																		where 
																			T.id = @ID_TESTE";

		

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

        public override void Excluir(Teste registroSelecionado)
        {
			foreach (Questao item in registroSelecionado.questoes)
			{
				ExcluirQuestao(item, registroSelecionado);
			}

            base.Excluir(registroSelecionado);
        }

        private void ExcluirQuestao(Questao questao, Teste teste)
        {
            SqlConnection conexaoBanco = new SqlConnection(enderecoBanco);
            conexaoBanco.Open();

            SqlCommand adicionarItem = conexaoBanco.CreateCommand();
            adicionarItem.CommandText = RemoverQuestao;

            adicionarItem.Parameters.AddWithValue("ID_QUESTAO", questao.id);
            adicionarItem.Parameters.AddWithValue("ID_TESTE", teste.id);

            adicionarItem.ExecuteNonQuery();

            conexaoBanco.Close();
        }

        public List<Questao> SelecionarQuestoesPorMateria(Teste teste1)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            SqlCommand comandoSelecionarQuestoesTeste = conexaoComBanco.CreateCommand();
            comandoSelecionarQuestoesTeste.CommandText = sqlSelecionarQuestoesPorMateria;

            comandoSelecionarQuestoesTeste.Parameters.AddWithValue("ID_TESTE", teste1.id);

            SqlDataReader leitorItem = comandoSelecionarQuestoesTeste.ExecuteReader();

            List<Questao> questoes = new List<Questao>();

            while (leitorItem.Read())
            {
                Questao alternativa = new MapeadorQuestao().ConverterRegistro(leitorItem);

                questoes.Add(alternativa);
            }

            conexaoComBanco.Close();

            return questoes;
        }

        public List<Questao> SelecionarQuestoesTeste(Teste teste1)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            SqlCommand comandoSelecionarQuestoesTeste = conexaoComBanco.CreateCommand();
            comandoSelecionarQuestoesTeste.CommandText = sqlSelecionarQuestoesTeste;

            comandoSelecionarQuestoesTeste.Parameters.AddWithValue("ID_TESTE", teste1.id);

            SqlDataReader leitorItem = comandoSelecionarQuestoesTeste.ExecuteReader();

            List<Questao> questoes = new List<Questao>();

            while (leitorItem.Read())
            {
                Questao alternativa = new MapeadorQuestao().ConverterRegistro(leitorItem);

                questoes.Add(alternativa);
            }

            conexaoComBanco.Close();

            return questoes;
        }
    }

}
