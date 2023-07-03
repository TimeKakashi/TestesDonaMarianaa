using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDonaMariana.Dominio.ModuloTeste;
using TestesDonaMariana.Infra.Dados.Sql.Compatilhado;

namespace TestesDonaMariana.Infra.Dados.Sql.ModuloTesteSql
{
    public class RepositorioTesteSql : RepositorioEmSqlBase<Teste, MapeadorTeste>, IRepositorioTeste
    {
        protected override string sqlInserir => throw new NotImplementedException();

        protected override string sqlEditar => throw new NotImplementedException();

        protected override string sqlExcluir => throw new NotImplementedException();

        protected override string sqlSelecionarTodos => throw new NotImplementedException();

        protected override string sqlSelecionarPorId => throw new NotImplementedException();
    }
}
