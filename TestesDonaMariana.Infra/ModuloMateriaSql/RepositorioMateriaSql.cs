using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDonaMariana.Dominio.ModuloDisciplina;
using TestesDonaMariana.Dominio.ModuloMateria;
using TestesDonaMariana.Dominio.ModuloQuestao;
using TestesDonaMariana.Dominio.ModuloQuestoes;
using TestesDonaMariana.Infra.Dados.Sql.Compatilhado;
using TestesDonaMariana.Infra.Dados.Sql.ModuloQuestaoSql;

namespace TestesDonaMariana.Infra.Dados.Sql.ModuloMateriaSql
{
    public class RepositorioMateriaSql : RepositorioEmSqlBase<Materia, MapeadorMateria>, IRepositorioMateria
    {
        protected override string sqlInserir => @"INSERT INTO TB_MATERIA
                                                (
	                                                ID_DISCIPLINA,
	                                                NOME,
	                                                ID_SERIE
                                                )
                                                VALUES
                                                (
	                                                @ID_DISCIPLINA,
	                                                @NOME,
	                                                @ID_SERIE
                                                )  
                                                SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar => @"UPDATE 
														TB_MATERIA
													SET 
														ID_DISCIPLINA =		@ID_DISCIPLINA,
														NOME =				@NOME,
														ID_SERIE =			@ID_SERIE
														WHERE
															ID = @ID";

        protected override string sqlExcluir => "DELETE FROM TB_MATERIA WHERE ID = @ID";

        protected override string sqlSelecionarTodos => @"SELECT 

															M.[Id_Disciplina]			ID_DISCIPLINA,
															M.[Id]						ID_MATERIA,
															M.[Id_Serie]				ID_SERIE,
															M.[Nome]					NOME_MATERIA,

															D.[Nome]					NOME_DISCIPLINA,

															S.[serie]					SERIE,
															S.[ID]						ID_SERIE
	

														FROM 
															TB_Materia as M
														inner join
															TB_Disciplina as D
														ON 
															M.Id_Disciplina = D.Id
														left join
															TB_Serie as S
														ON
															M.Id_Serie = S.Id";

        protected override string sqlSelecionarPorId => @"SELECT 

															M.[Id_Disciplina]			ID_DISCIPLINA,
															M.[Id]						ID_MATERIA,
															M.[Id_Serie]				ID_SERIE,
															M.[Nome]					NOME_MATERIA,

															D.[Nome]					NOME_DISCIPLINA,

															S.[serie]					SERIE
	

														FROM 
															TB_Materia as M
														inner join
															TB_Disciplina as D
														ON 
															M.Id_Disciplina = D.Id
														inner join
															TB_Serie as S
														ON
															M.Id_Serie = S.Id
														WHERE 
															M.[ID] = @ID";

		private const string sqlSelecionarQuestoesMateria = @"SELECT 
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

																	Where M.id = @ID_MATERIA";

		private const string sqlSelecionarMateriasDisciplina = @"SELECT 

																	M.ID				ID_MATERIA,
																	M.NOME				NOME_MATERIA,
																	M.ID_SERIE			ID_SERIE,

																	S.SERIE				SERIE,

																	D.ID				ID_DISCIPLINA,
																	D.NOME				NOME_DISCIPLINA

																FROM
																	TB_MATERIA AS M
																INNER JOIN
																	TB_DISCIPLINA AS D
																ON 
																	M.ID_DISCIPLINA = D.ID
																INNER JOIN 
																	TB_SERIE AS S
																ON 
																	S.ID = M.ID_SERIE
																WHERE
																	D.ID = @ID_DISCIPLINA";

        public List<Questao> SelecionarQuestoesMateria(Materia materia)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            SqlCommand comandoSelecionarMaterias = conexaoComBanco.CreateCommand();
            comandoSelecionarMaterias.CommandText = sqlSelecionarQuestoesMateria;

            comandoSelecionarMaterias.Parameters.AddWithValue("ID_MATERIA", materia.id);

            MapeadorQuestao mapeador = new MapeadorQuestao();

            SqlDataReader leitorItem = comandoSelecionarMaterias.ExecuteReader();

            List<Questao> questoes = new List<Questao>();

            while (leitorItem.Read())
            {
				Questao questao = new MapeadorQuestao().ConverterRegistro(leitorItem);

                questoes.Add(questao);
            }

            conexaoComBanco.Close();

            return questoes;
        }

        public List<Materia> SelecionarMateriasDaDisciplina(Disciplina? disciplina)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            SqlCommand comandoSelecionarMateriasDaDisciplina = conexaoComBanco.CreateCommand();
            comandoSelecionarMateriasDaDisciplina.CommandText = sqlSelecionarMateriasDisciplina;

            comandoSelecionarMateriasDaDisciplina.Parameters.AddWithValue("ID_DISCIPLINA", disciplina.id);

            SqlDataReader leitorItem = comandoSelecionarMateriasDaDisciplina.ExecuteReader();

            List<Materia> materias = new List<Materia>();

            while (leitorItem.Read())
            {
                Materia questao = new MapeadorMateria().ConverterRegistro(leitorItem);

                materias.Add(questao);
            }

            conexaoComBanco.Close();

            return materias;
        }
    }

	

}
