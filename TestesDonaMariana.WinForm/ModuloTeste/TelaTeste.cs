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
using TestesDonaMariana.Dominio.ModuloTeste;

namespace TestesDonaMariana.WinForm.ModuloTeste
{
    public partial class TelaTeste : Form
    {
        private IRepositorioDisciplina repositorioDisciplina { get; }
        private IRepositorioMateria repositorioMateria { get; }

        public TelaTeste()
        {
            InitializeComponent();
        }

        public TelaTeste(IRepositorioDisciplina repositorioDisciplina, IRepositorioMateria repositorioMateria) : this()
        {
            this.repositorioDisciplina = repositorioDisciplina;
            this.repositorioMateria = repositorioMateria;
            EnchercbBox();
        }

        public Teste ObterTeste()
        {
            Materia materia = (Materia)cbMateria.SelectedValue;
            Disciplina disciplina = (Disciplina)cbDisciplina.SelectedValue;
            int numeroQuestoes = Convert.ToInt32((numericNumeroQuestoes.Value));
            string serie = cxRadio.Controls.OfType<RadioButton>().SingleOrDefault(RadioButton => RadioButton.Checked).Text;

            return new Teste(materia, disciplina, numeroQuestoes, serie);
        }

        public void ConfigurarTela(Teste teste)
        {
            cbMateria.SelectedItem = teste.materia;
            cbDisciplina.SelectedItem = teste.disciplina;
            numericNumeroQuestoes.Value = teste.numeroQuestoes;
            cxRadio.Controls.OfType<RadioButton>().SingleOrDefault(RadioButton => RadioButton.Checked).Text = teste.serie;

            //foreach (Questao questao in teste.questoes)
            //{
            //    groupBox1.Controls.Add(questao.titulo)
            //}
        }

        public void EnchercbBox()
        {
            foreach (Materia materia in repositorioMateria.SelecionarTodos())
            {
                cbMateria.Items.Add(materia);
            }

            foreach (Disciplina disciplina in repositorioDisciplina.SelecionarTodos())
            {
                cbDisciplina.Items.Add(disciplina);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
