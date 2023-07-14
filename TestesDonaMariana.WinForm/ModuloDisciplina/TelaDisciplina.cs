using FluentResults;
using TestesDonaMariana.Dominio.ModuloDisciplina;
using TestesDonaMariana.WinForm.Compartilhado;

namespace TestesDonaMariana.WinForm.ModuloDisciplina
{
    public partial class TelaDisciplina : Form
    {
        private IRepositorioDisciplina repositorioDisciplina;

        private Disciplina disciplina1;

        public event GravarRegistroDelegate<Disciplina> onGravarRegistro;

        public TelaDisciplina()
        {
            InitializeComponent();
        }
        public TelaDisciplina(IRepositorioDisciplina repositorioDisciplina)
        {

            InitializeComponent();
            this.repositorioDisciplina = repositorioDisciplina;
        }

        public void ConfigurarTela(Disciplina? disciplinaSelecionada)
        {
            tbNome.Text = disciplinaSelecionada.id.ToString();
            tbListaDeMateria.Text = disciplinaSelecionada.nome;
        }

        public Disciplina ObterDisciplina()
        {
            int id = 0;

            string nome = tbListaDeMateria.Text;

            if (tbNome.Text != "")
                id = Convert.ToInt32(tbNome.Text);

            disciplina1 = new Disciplina(nome, id);

            return new Disciplina(nome);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Disciplina disciplina = ObterDisciplina();
            Result result;

            if (this.disciplina1.id != 0)
                result = onGravarRegistro(disciplina1);

            else
                result = onGravarRegistro(disciplina);

            if (result.IsFailed)
            {
                TelaPrincipal.Instancia.AtualizarRodape(result.Errors[0].Message);

                DialogResult = DialogResult.None;
            }
        }
    }
}
