using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDonaMariana.Dominio.ModuloDisciplina;
using TestesDonaMariana.Infra.Dados.Sql.Compatilhado;

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
    }
}
