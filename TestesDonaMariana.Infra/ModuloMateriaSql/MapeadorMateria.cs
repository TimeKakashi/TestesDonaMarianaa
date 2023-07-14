using Microsoft.Data.SqlClient;
using TestesDonaMariana.Dominio;
using TestesDonaMariana.Dominio.ModuloDisciplina;
using TestesDonaMariana.Dominio.ModuloMateria;
using TestesDonaMariana.Infra.Dados.Sql.Compatilhado;
using TestesDonaMariana.Infra.Dados.Sql.ModuloDisciplinaSql;

namespace TestesDonaMariana.Infra.Dados.Sql.ModuloMateriaSql
{
    public class MapeadorMateria : MapeadorBase<Materia>
    {
        public override void ConfigurarParametros(SqlCommand comando, Materia registro)
        {
            comando.Parameters.AddWithValue("ID_DISCIPLINA", registro.disciplina.id);

            comando.Parameters.AddWithValue("NOME", registro.nome);

            comando.Parameters.AddWithValue("ID_SERIE", registro.serie.id);

            comando.Parameters.AddWithValue("ID", registro.id);

        }

        public override Materia ConverterRegistro(SqlDataReader leitorRegistros)
        {

            Disciplina disciplina = new MapeadorDisciplina().ConverterRegistro(leitorRegistros);
            int id = 0;

            if (leitorRegistros["ID_MATERIA"] != DBNull.Value)
            {
                id = Convert.ToInt32(leitorRegistros["ID_MATERIA"]);
            }

            string nome = Convert.ToString(leitorRegistros["NOME_MATERIA"]);

            string nomeSerie = Convert.ToString(leitorRegistros["SERIE"]);

            int idSerie = 3;

            if (leitorRegistros["ID_MATERIA"] != DBNull.Value)
            {
                id = Convert.ToInt32(leitorRegistros["ID_MATERIA"]);
            }

            Serie serie = new Serie(nomeSerie, idSerie);

            Materia materia = new Materia(id, nome, serie, disciplina);

            return materia;
        }
    }
}
