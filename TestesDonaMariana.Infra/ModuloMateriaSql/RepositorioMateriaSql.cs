﻿using Microsoft.Data.SqlClient;
using TestesDonaMariana.Dominio;
using TestesDonaMariana.Dominio.ModuloDisciplina;
using TestesDonaMariana.Dominio.ModuloMateria;
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

															M.[ID_DISCIPLINA]			ID_DISCIPLINA,
															M.[ID]						ID_MATERIA,
															M.[ID_SERIE]				ID_SERIE,
															M.[NOME]					NOME_MATERIA,

															D.[NOME]					NOME_DISCIPLINA,

															S.[SERIE]					SERIE,
															S.[ID]						ID_SERIE
	

														FROM 
															TB_MATERIA AS M
														INNER JOIN
															TB_DISCIPLINA AS D
														ON 
															M.ID_DISCIPLINA = D.ID
														LEFT JOIN
															TB_SERIE AS S
														ON
															M.ID_SERIE = S.ID";

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

        private const string sqlSelecionarSeriePorNome = @"select serie as NOME_SERIE, Id as ID_SERIE from TB_Serie where TB_Serie.serie = @NOME_SERIE";

        private const string sqlInserirSeries = @"Insert into TB_Serie (serie) Values ('Primeira Serie'), ('Segunda Serie')";

        public Serie SelecionarSerieNome(string nome)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            SqlCommand comandoSelecionarSerie = conexaoComBanco.CreateCommand();
            comandoSelecionarSerie.CommandText = sqlSelecionarSeriePorNome;

            comandoSelecionarSerie.Parameters.AddWithValue("NOME_SERIE", nome);

            SqlDataReader leitorItem = comandoSelecionarSerie.ExecuteReader();

            Serie serie = null;

            if (leitorItem.Read())
            {
                string nomeSerie = Convert.ToString(leitorItem["NOME_SERIE"]);
                int id = Convert.ToInt32(leitorItem["ID_SERIE"]);

                serie = new Serie(nomeSerie, id);
            }

            return serie;
        }

        public void InserirSeries()
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            SqlCommand comandoInserirSeries = conexaoComBanco.CreateCommand();
            comandoInserirSeries.CommandText = sqlInserirSeries;

            comandoInserirSeries.ExecuteNonQuery();

            conexaoComBanco.Close();
        }

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
