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
        protected override string sqlInserir => @"INSERT INTO [TBDISCIPLINA] 
	                                            (
		                                            [NOME]
	                                            )
	                                            VALUES 
	                                            (
		                                            @NOME
	                                            );                 

                                            SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar => @"UPDATE [TBDISCIPLINA] 
                                                SET
                                                    [NOME] = @NOME
                                                WHERE
                                                    [ID] = @ID";

        protected override string sqlExcluir => @"DELETE FROM [TBDISCIPLINA]
	                                                WHERE 
		                                                [ID] = @ID";

        protected override string sqlSelecionarTodos => @"SELECT 
	                                                    [ID]        DISCIPLINA_ID 
	                                                   ,[NOME]      DISCIPLINA_NOME
                                                    FROM 
	                                                    [TBDISCIPLINA]";

        protected override string sqlSelecionarPorId => @"SELECT 
	                                                    [ID]        DISCIPLINA_ID 
	                                                   ,[NOME]      DISCIPLINA_NOME
                                                    FROM 
	                                                    [TBDISCIPLINA] 
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
