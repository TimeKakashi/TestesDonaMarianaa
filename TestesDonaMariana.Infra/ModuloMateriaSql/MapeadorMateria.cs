using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDonaMariana.Dominio.ModuloMateria;
using TestesDonaMariana.Infra.Dados.Sql.Compatilhado;

namespace TestesDonaMariana.Infra.Dados.Sql.ModuloMateriaSql
{
    public class MapeadorMateria : MapeadorBase<Materia>
    {
        public override void ConfigurarParametros(SqlCommand comando, Materia registro)
        {
            comando.Parameters.AddWithValue("ID", registro.id);

            comando.Parameters.AddWithValue("NOME", registro.nome);

            comando.Parameters.AddWithValue("ID_SERIE", registro.serie);
        }

        public override Materia ConverterRegistro(SqlDataReader leitorRegistros)
        {

            int id = Convert.ToInt32(leitorRegistros["ID"]);

            string nome = Convert.ToString(leitorRegistros["NOME"]);

            string serie = Convert.ToString(leitorRegistros["ID_SERIE"]);
            Materia materia = new Materia(id, nome, serie);

            return materia;
        }
    }
}
