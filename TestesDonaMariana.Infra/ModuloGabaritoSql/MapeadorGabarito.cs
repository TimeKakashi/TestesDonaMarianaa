using Microsoft.Data.SqlClient;
using TestesDonaMariana.Dominio.ModuloGabarito;
using TestesDonaMariana.Infra.Dados.Sql.Compatilhado;

namespace TestesDonaMariana.Infra.Dados.Sql.ModuloGabaritoSql
{
    public class MapeadorGabarito : MapeadorBase<Gabarito>
    {
        public override void ConfigurarParametros(SqlCommand comando, Gabarito registro)
        {
            throw new NotImplementedException();
        }

        public override Gabarito ConverterRegistro(SqlDataReader leitorRegistros)
        {
            throw new NotImplementedException();
        }
    }
}
