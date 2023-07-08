using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TestesDonaMariana.Dominio.ModuloDisciplina;
using TestesDonaMariana.Dominio.ModuloQuestao;
using TestesDonaMariana.Dominio.ModuloQuestoes;
using TestesDonaMariana.Infra.Dados.Sql.Compatilhado;
using TestesDonaMariana.Infra.Dados.Sql.ModuloQuestaoSql;

namespace TestesDonaMariana.Infra.Dados.Sql.ModuloDisciplinaSql
{
    public class RepositorioDisciplinaSql : RepositorioEmSqlBase<Disciplina, MapeadorDisciplina>, IRepositorioDisciplina
    {
        protected override string sqlInserir => @"INSERT INTO [TB_DISCIPLINA] 
	                                            (
		                                            [NOME]
	                                            )
	                                            VALUES 
	                                            (
		                                            @NOME_DISCIPLINA
	                                            );                 

                                            SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar => @"UPDATE [TB_DISCIPLINA] 
                                                SET
                                                    [NOME] = @NOME_DISCIPLINA
                                                WHERE
                                                    [ID] = @ID_DISCIPLINA";

        protected override string sqlExcluir => @"DELETE FROM [TB_DISCIPLINA]
	                                                WHERE 
		                                                [ID] = @ID";

        protected override string sqlSelecionarTodos => @"SELECT 
	                                                    [ID]        ID_DISCIPLINA 
	                                                   ,[NOME]      NOME_DISCIPLINA
                                                    FROM 
	                                                    [TB_DISCIPLINA]";

        protected override string sqlSelecionarPorId => @"SELECT 
	                                                    [ID]        ID_DISCIPLINA
	                                                   ,[NOME]      NOME_DISCIPLINA
                                                    FROM 
	                                                    [TB_DISCIPLINA] 
                                                    WHERE 
                                                        [ID] = @ID";

        private const string sqlVerificarTestesDisciplina = @"
																		SELECT 
	
																			D.ID				ID_DISCIPLINA,
																			D.NOME				NOME_DISCIPLINA
	
																		FROM
																			TB_DISCIPLINA AS D
																			INNER JOIN TBTESTE AS T
																			ON
																				D.ID = T.ID_DISCIPLINA
																			WHERE
																				D.ID = @ID";

        private const string sqlVerificarMateriasDisciplina = @"select 
	
		                                                        D.Id				ID_DISCIPLINA,
		                                                        D.Nome				NOME_DISCIPLINA
	
	                                                        from
		                                                        TB_Disciplina as D
		                                                        inner join TB_Materia as M
		                                                        on
			                                                        D.Id = M.Id_Disciplina
		                                                        where
			                                                        D.Id = @ID";
        public Disciplina SelecionarPorId(int id)
        {
            Disciplina disciplina = base.SelecionarPorId(id);

            return disciplina;
        }

        public List<Disciplina> SelecionarTodos()
        {
            List<Disciplina> disciplinas = base.SelecionarTodos();

            return disciplinas;
        }

		public List<Disciplina> VerificarTestesNaDisciplina(Disciplina disciplina)
		{
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            SqlCommand comandoSelecionarAlternativas = conexaoComBanco.CreateCommand();
            comandoSelecionarAlternativas.CommandText = sqlVerificarTestesDisciplina;

            comandoSelecionarAlternativas.Parameters.AddWithValue("ID", disciplina.id);

            SqlDataReader leitorItem = comandoSelecionarAlternativas.ExecuteReader();

            List<Disciplina> disciplinas = new List<Disciplina>();

            while (leitorItem.Read())
            {
                Disciplina alternativa = new MapeadorDisciplina().ConverterRegistro(leitorItem);

                disciplinas.Add(alternativa);
            }

            conexaoComBanco.Close();

            return disciplinas;
        }

        public List<Disciplina> VerificarMateriasNaDisciplina(Disciplina disciplina)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            SqlCommand comandoSelecionarMateriasDisciplina = conexaoComBanco.CreateCommand();
            comandoSelecionarMateriasDisciplina.CommandText = sqlVerificarMateriasDisciplina;

            comandoSelecionarMateriasDisciplina.Parameters.AddWithValue("ID", disciplina.id);

            SqlDataReader leitorItem = comandoSelecionarMateriasDisciplina.ExecuteReader();

            List<Disciplina> disciplinas = new List<Disciplina>();

            while (leitorItem.Read())
            {
                Disciplina alternativa = new MapeadorDisciplina().ConverterRegistro(leitorItem);

                disciplinas.Add(alternativa);
            }

            conexaoComBanco.Close();

            return disciplinas;
        }
    }
}
