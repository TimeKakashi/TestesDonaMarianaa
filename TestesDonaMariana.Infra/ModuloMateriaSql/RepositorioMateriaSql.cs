using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDonaMariana.Dominio.ModuloMateria;
using TestesDonaMariana.Infra.Dados.Sql.Compatilhado;

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

        protected override string sqlEditar => "UPDATE TB_MATERIA SET ID_DISCIPLINA = @ID_DISCIPLINA, NOME = @NOME, ID_SERIE = @ID_SERIE WHERE ID = @ID";

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
														inner join
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
    }

}
