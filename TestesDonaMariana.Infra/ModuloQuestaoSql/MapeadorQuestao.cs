using Microsoft.Data.SqlClient;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDonaMariana.Dominio.ModuloDisciplina;
using TestesDonaMariana.Dominio.ModuloMateria;
using TestesDonaMariana.Dominio.ModuloQuestoes;
using TestesDonaMariana.Infra.Dados.Sql.Compatilhado;
using TestesDonaMariana.WinForm.ModuloQuestao;

namespace TestesDonaMariana.Infra.Dados.Sql.ModuloQuestaoSql
{
    public class MapeadorQuestao : MapeadorBase<Questao>
    {
        public override void ConfigurarParametros(SqlCommand comando, Questao registro)
        {
            comando.Parameters.AddWithValue("TITULO", registro.titulo);
            comando.Parameters.AddWithValue("ID_MATERIA", registro.materia.id);
            comando.Parameters.AddWithValue("ALTERNATIVA_CORRETA", registro.alternativaCorretaENUM);
        }

        public override Questao ConverterRegistro(SqlDataReader leitorRegistros)
        {
            string nomeDisciplina = Convert.ToString(leitorRegistros["NOME_DISCIPLINA"]);
            int idDisiplina = Convert.ToInt32(leitorRegistros["MATERIA_ID_DISCIPLINA"]);

            Disciplina disciplina = new Disciplina(nomeDisciplina, idDisiplina);

            int idMateria = Convert.ToInt32(leitorRegistros["QUESTAO_ID_MATERIA"]);
            string nomeMateria = Convert.ToString(leitorRegistros["NOME_MATERIA"]);
            string nomeSerie = Convert.ToString(leitorRegistros["SERIE_NOME"]);

            Materia materia = new Materia(idMateria, nomeMateria, nomeSerie, disciplina);

            int idQuestao = Convert.ToInt32(leitorRegistros["ID_QUESTAO"]);
            string titulo = Convert.ToString(leitorRegistros["TITULO_QUESTAO"]);
            EnumAlternativaCorreta alternativaCorreta = (EnumAlternativaCorreta)leitorRegistros["ALTERNATIVA_CORRETA"];

            return new Questao(idQuestao, titulo, materia, alternativaCorreta);
        }

        public string ConverterParaAlternativastr(SqlDataReader leitor)
        {
            return Convert.ToString(leitor["ALTERNATIVA"])!;
        }

        public void ConfigurarParamentrosAlternativas(SqlCommand comando, string alternativa, Questao questao)
        {
            comando.Parameters.AddWithValue("ALTERNATIVA", alternativa);
            comando.Parameters.AddWithValue("ID_QUESTAO", questao.id);
        }
    }
}
