using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDonaMariana.Dominio.ModuloQuestao;
using TestesDonaMariana.Dominio.ModuloQuestoes;
using TestesDonaMariana.Infra.Dados.Sql.Compatilhado;

namespace TestesDonaMariana.Infra.Dados.Sql.ModuloQuestaoSql
{
    public class RepositorioQuestaoSql : RepositorioEmSqlBase<Questao, MapeadorQuestao>, IRepositorioQuestoes
    {
        protected override string sqlInserir =>
            @"INSERT INTO [TB_Questao]
	                (
		                [Titulo],
		                [Id_Materia],
						[AlternativaCorreta]
	                )
                VALUES
	                (
		                @TITULO,
		                @ID_MATERIA,
						@ALTERNATIVA_CORRETA
	                )
                SELECT SCOPE_IDENTITY();";

        private const string sqlInserirAlternativas =
            @"INSERT INTO [TB_Alternativa]
					(
						[Alternativa],
						[Id_Questao]
					)
				VALUES
					(
						@ALTERNATIVA,
						@ID_QUESTAO
					)
				SELECT SCOPE_IDENTITY();";


		protected override string sqlEditar =>
            @"UPDATE [TB_Questao]
				SET 
					[Id_Materia] = @ID_MATERIA,
					[Titulo] = @TITULO

				WHERE [Id] = @ID_QUESTAO";



		private const string sqlEditarAlternativas =

            @"UPDATE [TB_ALTERNATIVA]
				SET 
					[ALTERNATIVA] = @ALTERNATIVA

				WHERE
					[Id_Questao] = @ID_QUESTAO and [TB_ALTERNATIVA].ID = @ID_ALTERNATIVA";


        protected override string sqlExcluir =>
            @"DELETE FROM 
					[TB_Questao]
				WHERE 
					[Id] = @ID_QUESTAO";
		protected override string sqlSelecionarTodos =>
            @"SELECT 
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
";

        protected override string sqlSelecionarPorId =>
            @" SELECT 
				Q.[Id]					ID_QUESTAO,
				Q.[Titulo]				TITULO_QUESTAO,
				Q.[AlternativaCorreta]	ALTERNATIVA_CORRETA,
				Q.[Id_Materia]			QUESTAO_ID_MATERIA,

				M.[Nome]				NOME_MATERIA,
				M.[Id_Disciplina]		MATERIA_ID_DISCIPLINA,
				M.[Id_Serie]			MATERIA_ID_SERIE,
		
				D.[Nome]				NOME_DISCIPLINA,

				S.[serie]				SERIE_NOME,
				S.[Id]					ID_SERIE
				

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
				WHERE 
					Q.[Id] = @ID
				";

		public const string sqlCarregarAlternativas =
            @"SELECT 
					A.[ALTERNATIVA],
					A.[ID]
				FROM
					[TB_ALTERNATIVA] AS A 
				INNER JOIN
					[TB_QUESTAO] AS Q
				ON
					A.ID_QUESTAO = Q.[ID]
					where q.id = @ID_QUESTAO";

		public const string sqlExcluirAlternativas =
            @"delete from [TB_Alternativa] where Id_Questao = @id";

        public override void Excluir(Questao registroSelecionado)
        {
			ExcluirAlternativas(registroSelecionado);

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            SqlCommand comandoExcluir = conexaoComBanco.CreateCommand();
            comandoExcluir.CommandText = sqlExcluir;

            comandoExcluir.Parameters.AddWithValue("ID_QUESTAO", registroSelecionado.id);

            comandoExcluir.ExecuteNonQuery();

            conexaoComBanco.Close();
        }

        public void ExcluirAlternativas(Questao questao)
		{
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            SqlCommand comandoExcluir = conexaoComBanco.CreateCommand();
            comandoExcluir.CommandText = sqlExcluirAlternativas;

            comandoExcluir.Parameters.AddWithValue("ID", questao.id);

            comandoExcluir.ExecuteNonQuery();

            conexaoComBanco.Close();
        }

        public void InserirAlternativa(List<Alternativa> alternativas, Questao questao)
        {
            //obter a conexão com o banco e abrir ela
            

            foreach (Alternativa item in alternativas)
            {
                SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
                conexaoComBanco.Open();

                //cria um comando e relaciona com a conexão aberta
                SqlCommand comandoInserirAlternativas = conexaoComBanco.CreateCommand();
                comandoInserirAlternativas.CommandText = sqlInserirAlternativas;

                MapeadorQuestao mapeador = new MapeadorQuestao();

                mapeador.ConfigurarParamentrosAlternativas(comandoInserirAlternativas, item, questao);
				comandoInserirAlternativas.ExecuteNonQuery();

				conexaoComBanco.Close();
            }
        }

		public void EditarAlternativas(Questao questao)
		{
            foreach (Alternativa item in questao.alternativas)
            {
                SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
                conexaoComBanco.Open();

                //cria um comando e relaciona com a conexão aberta
                SqlCommand comandoEditarAlternativas = conexaoComBanco.CreateCommand();
                comandoEditarAlternativas.CommandText = sqlEditarAlternativas;

                MapeadorQuestao mapeador = new MapeadorQuestao();

                mapeador.ConfigurarParamentrosAlternativas(comandoEditarAlternativas, item, questao);
                comandoEditarAlternativas.ExecuteNonQuery();

                conexaoComBanco.Close();
            }
        }

		public List<Alternativa> SelecionarAlternativas(Questao questao)
		{
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            SqlCommand comandoSelecionarAlternativas = conexaoComBanco.CreateCommand();
            comandoSelecionarAlternativas.CommandText = sqlCarregarAlternativas;

            comandoSelecionarAlternativas.Parameters.AddWithValue("ID_QUESTAO", questao.id);

            MapeadorQuestao mapeador = new MapeadorQuestao();

            SqlDataReader leitorItem = comandoSelecionarAlternativas.ExecuteReader();

			List<Alternativa> alternatvias = new List<Alternativa>();

            while (leitorItem.Read())
            {
				Alternativa alternativa = mapeador.ConverterParaAlternativastr(leitorItem);

				alternatvias.Add(alternativa);
            }

            conexaoComBanco.Close();

			return alternatvias;
        }
    }
}
