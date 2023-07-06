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
            EncharComboBox(/*repositorioDisciplina*/);
        }

        public void EncharComboBox(/*IRepositorioDisciplina repositorioDisciplina*/)
        {
            Disciplina disciplina = new Disciplina("Quimica", 5);

            List<Disciplina> disciplinas = new List<Disciplina>();

            disciplinas.Add(disciplina);

            foreach (Disciplina dis in disciplinas)
            {
                comboBox1.Items.Add(dis);
            }
        }

        public Materia ObterMateria()
        {
            string nome = textBox1.Text;
            Disciplina disciplina = (Disciplina)comboBox1.SelectedItem;
            string serie = gbRadio.Controls.OfType<RadioButton>().SingleOrDefault(RadioButton => RadioButton.Checked).Text;


            return new Materia(nome, disciplina, serie);
        }

        public void ArrumaTela(Materia materia)
        {
            textBox1.Text = materia.nome;
            gbRadio.Controls.OfType<RadioButton>().SingleOrDefault(RadioButton => RadioButton.Checked).Text = materia.serie;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        
    }
}
