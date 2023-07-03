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
        protected override string sqlInserir => throw new NotImplementedException();

        protected override string sqlEditar => throw new NotImplementedException();

        protected override string sqlExcluir => throw new NotImplementedException();

        protected override string sqlSelecionarTodos => throw new NotImplementedException();

        protected override string sqlSelecionarPorId => throw new NotImplementedException();
    }
}
