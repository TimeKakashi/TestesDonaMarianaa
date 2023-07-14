using FluentResults;
using TestesDonaMariana.Dominio;
using TestesDonaMariana.Dominio.ModuloDisciplina;
using TestesDonaMariana.Dominio.ModuloMateria;
using TestesDonaMariana.WinForm.Compartilhado;

namespace TestesDonaMariana.WinForm.ModuloMateria
{
    public partial class TelaMateria : Form
    {
        private IRepositorioDisciplina repositorioDisciplina;
        private IRepositorioMateria repositorioMateria;
        public event GravarRegistroDelegate<Materia> onGravarRegistro;
        private Materia materia;

        public TelaMateria(IRepositorioDisciplina repositorioDisciplina, IRepositorioMateria repositorioMateria)
        {
            InitializeComponent();
            this.repositorioDisciplina = repositorioDisciplina;
            this.repositorioMateria = repositorioMateria;
            EncharComboBox(repositorioDisciplina);
        }

        public void EncharComboBox(IRepositorioDisciplina repositorioDisciplina)
        {
            comboBox1.Items.Clear();

            foreach (Disciplina dis in repositorioDisciplina.SelecionarTodos())
            {
                comboBox1.Items.Add(dis.nome);
            }
        }

        public Materia ObterMateria()
        {
            string nome = textBox1.Text;
            Serie serie = new Serie();
            int idMateria = 0;

            List<Disciplina> disciplinas = repositorioDisciplina.SelecionarTodos();

            Disciplina disciplina = new Disciplina();

            if (comboBox1.SelectedItem != null)
            {
                if (comboBox1.SelectedItem.GetType() == typeof(string))
                {
                    disciplina = disciplinas.Find(m => m.nome == (string)comboBox1.SelectedItem);
                }
                else
                    disciplina = (Disciplina)comboBox1.SelectedItem;
            }

            if (txId.Text != "")
                idMateria = Convert.ToInt32(txId.Text);

            if (gbRadio.Controls.OfType<RadioButton>().SingleOrDefault(RadioButton => RadioButton.Checked) == null)
            {
                serie = null;
            }

            else
            {
                string serieNome = gbRadio.Controls.OfType<RadioButton>().SingleOrDefault(RadioButton => RadioButton.Checked).Text;

                if (serieNome == "Primeira Serie")
                    serie = repositorioMateria.SelecionarSerieNome("Primeira Serie");

                else
                    serie = repositorioMateria.SelecionarSerieNome("Segunda Serie");
            }

            materia = new Materia(idMateria, nome, serie, disciplina);

            return new Materia(nome, disciplina, serie);
        }

        public void ArrumaTela(Materia materia)
        {
            EncharComboBox(repositorioDisciplina);

            textBox1.Text = materia.nome;
            txId.Text = materia.id.ToString();
            comboBox1.SelectedItem = materia.disciplina.nome;

            if (materia.serie.nome == "Primeira Serie")
                primeiraSerie.Checked = true;

            else if (materia.serie.nome == "Segunda Serie")
                SegundSerie.Checked = true;

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Materia materia = ObterMateria();
            Result result = null;

            if (this.materia.id != 0)
                result = onGravarRegistro(this.materia);

            else
                result = onGravarRegistro(materia);

            if (result.IsFailed)
            {
                TelaPrincipal.Instancia.AtualizarRodape(result.Errors[0].Message);

                DialogResult = DialogResult.None;
            }
        }
    }
}
