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
        protected override string sqlInserir => "INSERT INTO TB_MATERIA (ID_DISCIPLINA, NOME, ID_SERIE) VALUES (@ID_DISCIPLINA, @NOME, @ID_SERIE)";

        protected override string sqlEditar => "UPDATE TB_MATERIA SET ID_DISCIPLINA = @ID_DISCIPLINA, NOME = @NOME, ID_SERIE = @ID_SERIE WHERE ID = @ID";

        protected override string sqlExcluir => "DELETE FROM TB_MATERIA WHERE ID = @ID";

        protected override string sqlSelecionarTodos => "SELECT * FROM TB_MATERIA";

        protected override string sqlSelecionarPorId => "SELECT * FROM TB_MATERIA WHERE ID = @ID";
    }

}
