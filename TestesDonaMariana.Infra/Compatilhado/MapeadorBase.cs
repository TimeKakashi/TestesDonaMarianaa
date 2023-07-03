using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDonaMariana.Dominio.Compartilhado;

namespace TestesDonaMariana.Infra.Dados.Sql.Compatilhado
{
    public abstract class MapeadorBase<T>
    {
        public abstract void ConfigurarParametros(SqlCommand comando, T registro);

        public abstract T ConverterRegistro(SqlDataReader leitorRegistros);
    }
}
