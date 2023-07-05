using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestesDonaMariana.Dominio.ModuloDisciplina;
using TestesDonaMariana.Dominio.ModuloMateria;
using TestesDonaMariana.Dominio.ModuloQuestoes;

namespace TestesDonaMariana.WinForm.ModuloQuestao
{
    public partial class TelaQuestao : Form
    {
        private IRepositorioMateria repositorioMateria;
        private List<Materia> materias = new List<Materia>();
        public TelaQuestao(/*IRepositorioMateria repositorioMateria*/)
        {
            InitializeComponent();
            //this.repositorioMateria = repositorioMateria;
            Disciplina disciplina = new Disciplina("Geopolitica", 1);
            Materia materia = new Materia(1, "geo", "primeira serie", disciplina);
            this.materias.Add(materia);
            materias.Add(materia);
            EncherComboBox();
        }

        public Questao ObterQuestao()
        {
            List<string> Alternativas = new List<string>();

            string titulo = txTitulo.Text;
            Alternativas.Add(txAlternativaA.Text);
            Alternativas.Add(txAlternativaB.Text);
            Alternativas.Add(txAlternativaC.Text);
            Alternativas.Add(txAlternativaD.Text);
            EnumAlternativaCorreta alternativaCorrea = (EnumAlternativaCorreta)cbAlternativaCorreta.SelectedItem;
            Materia materia = (Materia)cbMateria.SelectedItem;

            return new Questao(titulo, Alternativas, alternativaCorrea, materia);
        }

        public void ConfigurarTela(Questao questao)
        {
            cbMateria.SelectedItem = questao.materia;
            cbAlternativaCorreta.SelectedItem = questao.alternativaCorretaENUM;
            txAlternativaA.Text = questao.alternativas[0];
            txAlternativaB.Text = questao.alternativas[1];
            txAlternativaC.Text = questao.alternativas[2];
            txAlternativaD.Text = questao.alternativas[3];
            txTitulo.Text = questao.titulo;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {

        }

        private void EncherComboBox()
        {
            foreach (Materia materia in materias)
            {
                cbMateria.Items.Add(materia);
            }

            var valoresEnum = Enum.GetValues(typeof(EnumAlternativaCorreta));

            foreach(EnumAlternativaCorreta item in valoresEnum)
            {
                cbAlternativaCorreta.Items.Add(item);
            }
        }



    }
}
