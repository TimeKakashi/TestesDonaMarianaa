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
using TestesDonaMariana.Dominio.ModuloQuestao;
using TestesDonaMariana.Dominio.ModuloQuestoes;

namespace TestesDonaMariana.WinForm.ModuloQuestao
{
    public partial class TelaQuestao : Form
    {
        private IRepositorioMateria repositorioMateria;
        public TelaQuestao(IRepositorioMateria repositorioMateria)
        {
            InitializeComponent();
            this.repositorioMateria = repositorioMateria;
            EncherComboBox();
        }

        public Questao ObterQuestao()
        {
            List<Alternativa> Alternativas = new List<Alternativa>();

            string titulo = txTitulo.Text;

            Alternativa alternativaA = new Alternativa(txAlternativaA.Text);
            Alternativa alternativaB = new Alternativa(txAlternativaB.Text);
            Alternativa alternativaC = new Alternativa(txAlternativaC.Text);
            Alternativa alternativaD = new Alternativa(txAlternativaD.Text);

            Alternativas.Add(alternativaA);
            Alternativas.Add(alternativaB);
            Alternativas.Add(alternativaC);
            Alternativas.Add(alternativaD);

            EnumAlternativaCorreta alternativaCorrea = (EnumAlternativaCorreta)cbAlternativaCorreta.SelectedItem;
            Materia materia = (Materia)cbMateria.SelectedItem;

            return new Questao(titulo, Alternativas, alternativaCorrea, materia);
        }

        public void ConfigurarTela(Questao questao)
        {
            cbMateria.SelectedItem = questao.materia;
            cbAlternativaCorreta.SelectedItem = questao.alternativaCorretaENUM;
            txAlternativaA.Text = questao.alternativas[0].alternativa;
            txAlternativaB.Text = questao.alternativas[1].alternativa;
            txAlternativaC.Text = questao.alternativas[2].alternativa;
            txAlternativaD.Text = questao.alternativas[3].alternativa;
            txTitulo.Text = questao.titulo;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {

        }

        private void EncherComboBox()
        {
            foreach (Materia materia in repositorioMateria.SelecionarTodos())
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
