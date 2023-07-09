using TestesDonaMariana.Dominio;
using TestesDonaMariana.Dominio.ModuloDisciplina;
using TestesDonaMariana.Dominio.ModuloMateria;

namespace TestesDonaMariana.WinForm.ModuloMateria
{
    public partial class TelaMateria : Form
    {
        private IRepositorioDisciplina repositorioDisciplina;
        private IRepositorioMateria repositorioMateria;
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
            foreach (Disciplina dis in repositorioDisciplina.SelecionarTodos())
            {
                comboBox1.Items.Add(dis);
            }
        }

        public Materia ObterMateria()
        {
            string nome = textBox1.Text;
            Disciplina disciplina = (Disciplina)comboBox1.SelectedItem;
            Serie serie = new Serie();

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



            return new Materia(nome, disciplina, serie);
        }

        public void ArrumaTela(Materia materia)
        {
            textBox1.Text = materia.nome;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Materia materia = ObterMateria();

            string[] erros = materia.Validar();

            if (erros.Length > 0)
            {
                TelaPrincipal.Instancia.AtualizarRodape(erros[0]);
                DialogResult = DialogResult.None;
            }
        }
    }
}
