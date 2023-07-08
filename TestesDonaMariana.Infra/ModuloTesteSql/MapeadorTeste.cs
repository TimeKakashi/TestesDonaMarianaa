using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDonaMariana.Dominio.ModuloDisciplina;
using TestesDonaMariana.Dominio.ModuloMateria;
using TestesDonaMariana.Dominio.ModuloTeste;
using TestesDonaMariana.Infra.Dados.Sql.Compatilhado;
using TestesDonaMariana.Infra.Dados.Sql.ModuloDisciplinaSql;
using TestesDonaMariana.Infra.Dados.Sql.ModuloMateriaSql;

namespace TestesDonaMariana.Infra.Dados.Sql.ModuloTesteSql
{
    public class MapeadorTeste : MapeadorBase<Teste>
    {
        public override void ConfigurarParametros(SqlCommand comando, Teste registro)
        {
            comando.Parameters.AddWithValue("ID_DISCIPLINA", registro.disciplina.id);

            if(registro.materia == null || registro.materia.id == 0)
                comando.Parameters.AddWithValue("ID_MATERIA", DBNull.Value);
            else
            comando.Parameters.AddWithValue("ID_MATERIA", registro.materia.id);

            comando.Parameters.AddWithValue("TITULO_TESTE", registro.titulo);
            comando.Parameters.AddWithValue("DATA", registro.dataCriacao.Ticks);
            comando.Parameters.AddWithValue("NUMERO_QUESTAO", registro.numeroQuestoes);
        }

        public override Teste ConverterRegistro(SqlDataReader leitorRegistros)
        {

            Materia materia = new MapeadorMateria().ConverterRegistro(leitorRegistros);

            Disciplina disciplina = new MapeadorDisciplina().ConverterRegistro(leitorRegistros);

            string titulo = Convert.ToString(leitorRegistros["TITULO_TESTE"]);
            DateTime data = DateTime.FromFileTimeUtc(Convert.ToInt64(leitorRegistros["DATA_CRIACAO"]));
            int numeroQuestoes = Convert.ToInt32(leitorRegistros["NUMERO_QUESTAO"]);
            string serie = "Priemira serie";
            int idTeste = Convert.ToInt32(leitorRegistros["ID_TESTE"]);
            

            return new Teste(materia, disciplina, numeroQuestoes, serie, idTeste, titulo);
        }
    }
}
