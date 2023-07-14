using Microsoft.Data.SqlClient;
using TestesDonaMariana.Dominio.ModuloDisciplina;
using TestesDonaMariana.Infra.Dados.Sql.Compatilhado;

namespace TestesDonaMariana.Infra.Dados.Sql.ModuloDisciplinaSql
{
    public class MapeadorDisciplina : MapeadorBase<Disciplina>
    {
        public override void ConfigurarParametros(SqlCommand comando, Disciplina registro)
        {
            comando.Parameters.AddWithValue("ID_DISCIPLINA", registro.id);

            comando.Parameters.AddWithValue("NOME_DISCIPLINA", registro.nome);
        }

        public override Disciplina ConverterRegistro(SqlDataReader leitorRegistros)
        {
            int id = Convert.ToInt32(leitorRegistros["ID_DISCIPLINA"]);

            string nome = Convert.ToString(leitorRegistros["NOME_DISCIPLINA"]);

            Disciplina disciplina = new Disciplina(nome, id);


            return disciplina;
        }
    }
}
