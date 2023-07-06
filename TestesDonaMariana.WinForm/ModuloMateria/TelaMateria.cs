using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestesDonaMariana.Dominio;
using TestesDonaMariana.Dominio.ModuloDisciplina;
using TestesDonaMariana.Dominio.ModuloMateria;
using TestesDonaMariana.WinForm.ModuloQuestao;

namespace TestesDonaMariana.WinForm.ModuloMateria
{
    public partial class TelaMateria : Form
    {
        private IRepositorioDisciplina repositorioDisciplina;
        private Materia materia;

        public TelaMateria(IRepositorioDisciplina repositorioDisciplina)
        {
            InitializeComponent();
            this.repositorioDisciplina = repositorioDisciplina;
            EncharComboBox(repositorioDisciplina);
        }

        public void EncharComboBox(IRepositorioDisciplina repositorioDisciplina)
        {
            foreach (Disciplina dis in repositorioDisciplina.SelecionarTodos())
            {
                comboBox1.Items.Add(dis);
            }
        }

        public Materia ObterMateria()
        {
            string nome = textBox1.Text;
            Disciplina disciplina = (Disciplina)comboBox1.SelectedItem;
            string serieNome = gbRadio.Controls.OfType<RadioButton>().SingleOrDefault(RadioButton => RadioButton.Checked).Text;

            Serie serie = new Serie();

            if (serieNome == "Primeira Série")
            {
                serie.id = 1;
                serie.nome = "Primeira Série";
            }
            else
            {
                serie.id = 2;
                serie.nome = "Segunda Série";
            }
              

            return new Materia(nome, disciplina, serie);
        }

        public void ArrumaTela(Materia materia)
        {
            textBox1.Text = materia.nome;
            gbRadio.Controls.OfType<RadioButton>().SingleOrDefault(RadioButton => RadioButton.Checked).Text = materia.serie.nome;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }


    }
}
