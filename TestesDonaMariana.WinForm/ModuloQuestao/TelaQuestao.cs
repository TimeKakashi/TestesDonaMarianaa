using FluentResults;
using TestesDonaMariana.Dominio.ModuloMateria;
using TestesDonaMariana.Dominio.ModuloQuestao;
using TestesDonaMariana.Dominio.ModuloQuestoes;
using TestesDonaMariana.WinForm.Compartilhado;

namespace TestesDonaMariana.WinForm.ModuloQuestao
{
    public partial class TelaQuestao : Form
    {
        private IRepositorioMateria repositorioMateria;

        private Questao questao;

        public event GravarRegistroDelegate<Questao> onGravarRegistro;
        public TelaQuestao(IRepositorioMateria repositorioMateria)
        {
            InitializeComponent();
            this.repositorioMateria = repositorioMateria;
            EncherComboBox();
        }

        public Questao ObterQuestao()
        {

            int id = 0;

            List<Alternativa> Alternativas = new List<Alternativa>();
            List<Materia> materias = repositorioMateria.SelecionarTodos();

            string titulo = txTitulo.Text;

            if (txId.Text != null && txId.Text != "")
            {
                id = Convert.ToInt32(txId.Text);
            }

            Alternativa alternativaA = new Alternativa(txAlternativaA.Text);
            Alternativa alternativaB = new Alternativa(txAlternativaB.Text);
            Alternativa alternativaC = new Alternativa(txAlternativaC.Text);
            Alternativa alternativaD = new Alternativa(txAlternativaD.Text);

            Alternativas.Add(alternativaA);
            Alternativas.Add(alternativaB);
            Alternativas.Add(alternativaC);
            Alternativas.Add(alternativaD);

            EnumAlternativaCorreta alternativaCorrea;

            if (cbAlternativaCorreta.SelectedItem == null)
            {
                alternativaCorrea = (EnumAlternativaCorreta)4;
            }
            else
                alternativaCorrea = (EnumAlternativaCorreta)cbAlternativaCorreta.SelectedItem;

            Materia materia = null;

            if (cbMateria.SelectedItem != null)
            {
                if (cbMateria.SelectedItem.GetType() == typeof(string))
                {
                    materia = materias.Find(m => m.nome == (string)cbMateria.SelectedItem);
                }
                else
                    materia = (Materia)cbMateria.SelectedItem;
            }

            questao = new Questao();

            questao.titulo = titulo;
            questao.materia = materia;
            questao.alternativas = Alternativas;
            questao.id = id;
            questao.alternativaCorretaENUM = alternativaCorrea;

            return new Questao(titulo, Alternativas, alternativaCorrea, materia);
        }

        public void ConfigurarTela(Questao questao)
        {

            cbMateria.SelectedItem = questao.materia.nome;
            cbAlternativaCorreta.SelectedItem = questao.alternativaCorretaENUM;
            txAlternativaA.Text = questao.alternativas[0].alternativa;
            txAlternativaB.Text = questao.alternativas[1].alternativa;
            txAlternativaC.Text = questao.alternativas[2].alternativa;
            txAlternativaD.Text = questao.alternativas[3].alternativa;
            txId.Text = questao.id.ToString();
            txTitulo.Text = questao.titulo;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            Questao questao = ObterQuestao();

            Result result = onGravarRegistro(this.questao);

            if (result.IsFailed)
            {
                string erro = result.Errors[0].Message;

                TelaPrincipal.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        private void EncherComboBox()
        {
            foreach (Materia materia in repositorioMateria.SelecionarTodos())
            {
                cbMateria.Items.Add(materia.nome);
            }

            var valoresEnum = Enum.GetValues(typeof(EnumAlternativaCorreta));

            foreach (EnumAlternativaCorreta item in valoresEnum)
            {
                if (item == EnumAlternativaCorreta.Erro)
                    continue;

                cbAlternativaCorreta.Items.Add(item);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
