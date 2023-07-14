using Microsoft.Data.SqlClient;

namespace TestesDonaMariana.Infra.Dados.Sql.Compatilhado
{
    public abstract class MapeadorBase<T>
    {
        public abstract void ConfigurarParametros(SqlCommand comando, T registro);

        public abstract T ConverterRegistro(SqlDataReader leitorRegistros);
    }
}
