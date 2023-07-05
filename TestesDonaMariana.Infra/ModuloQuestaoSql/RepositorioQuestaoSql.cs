using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

				WHERE [Id] = @ID

			UPDATE [TB_Alternativa]
				SET 
					[Alternativa]
				WHERE
					[Id_Questao] = @ID";

		protected override string sqlExcluir =>
            @"DELETE FROM 
					[TB_Questao]
				WHERE 
					[Id] = @ID";
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

				S.[serie]				SERIE_NOME
				

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

				S.[serie]				SERIE_NOME
				

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
            @"select 
				a.[Alternativa]

		from [TB_Alternativa] as a inner join [TB_Questao] as q on a.Id_Questao = q.Id where q.id = @ID";

		public const string sqlExcluirAlternativas =
            @"delete from [TB_Alternativa] where Id_Questao = @id";

        public override void Excluir(Questao registroSelecionado)
        {
			ExcluirAlternativas(registroSelecionado);

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            SqlCommand comandoExcluir = conexaoComBanco.CreateCommand();
            comandoExcluir.CommandText = sqlExcluir;

            comandoExcluir.Parameters.AddWithValue("ID", registroSelecionado.id);

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

        public void InserirAlternativa(List<string> alternativas, Questao questao)
        {
            //obter a conexão com o banco e abrir ela
            

            foreach (var item in alternativas)
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

		public List<string> SelecionarAlternativas(Questao questao)
		{
            //obter a conexão com o banco e abrir ela
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            //cria um comando e relaciona com a conexão aberta
            SqlCommand comandoSelecionarItens = conexaoComBanco.CreateCommand();
            comandoSelecionarItens.CommandText = sqlCarregarAlternativas;

            comandoSelecionarItens.Parameters.AddWithValue("ID", questao.id);

            MapeadorQuestao mapeador = new MapeadorQuestao();

            //executa o comando
            SqlDataReader leitorItem = comandoSelecionarItens.ExecuteReader();

			List<string> alternatvias = new List<string>();

            while (leitorItem.Read())
            {
				string item = mapeador.ConverterParaAlternativastr(leitorItem);

				alternatvias.Add(item);
            }

            //encerra a conexão
            conexaoComBanco.Close();

			return alternatvias;
        }
    }

    
}
