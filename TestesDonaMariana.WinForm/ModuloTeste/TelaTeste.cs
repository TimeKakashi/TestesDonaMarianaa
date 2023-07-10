using TestesDonaMariana.Dominio;
using TestesDonaMariana.Dominio.ModuloDisciplina;
using TestesDonaMariana.Dominio.ModuloMateria;
using TestesDonaMariana.Dominio.ModuloQuestoes;
using TestesDonaMariana.Dominio.ModuloTeste;

namespace TestesDonaMariana.WinForm.ModuloTeste
{
    public partial class TelaTeste : Form
    {
        private bool recuperacao = false;
        private IRepositorioDisciplina repositorioDisciplina { get; }
        private IRepositorioMateria repositorioMateria { get; }
        private IRepositorioQuestoes repositorioQuestoes { get; }
        private IRepositorioTeste repositorioTeste { get; }

        List<Questao> questoesFinais { get; set; } = new List<Questao>();

        public TelaTeste()
        {
            InitializeComponent();
        }

        public TelaTeste(IRepositorioDisciplina repositorioDisciplina, IRepositorioMateria repositorioMateria, IRepositorioQuestoes repositorioQuestoes, IRepositorioTeste repositorioTeste) : this()
        {
            this.repositorioDisciplina = repositorioDisciplina;
            this.repositorioMateria = repositorioMateria;
            this.repositorioQuestoes = repositorioQuestoes;
            this.repositorioTeste = repositorioTeste;

           

            EncherBox();
        }

        public Teste ObterTeste()
        {
            Materia materia;

            //if (cbMateria.SelectedItem == "")
            //{
            //    materia = null;
            //}
            //else
            //    materia = (Materia)cbMateria.SelectedItem;

            if (recuperacao)
                materia = null;

            else
                materia = (Materia)cbMateria.SelectedItem;

            string serieNome = string.Empty;

            if (cxRadio.Controls.OfType<RadioButton>().SingleOrDefault(RadioButton => RadioButton.Checked) == null)
                serieNome = string.Empty;

            else
                serieNome = cxRadio.Controls.OfType<RadioButton>().SingleOrDefault(RadioButton => RadioButton.Checked).Text;


            string titulo = tbTitulo.Text;
            Disciplina disciplina = (Disciplina)cbDisciplina.SelectedItem;
            int numeroQuestoes = Convert.ToInt32((numericNumeroQuestoes.Value));
            List<Questao> questoes = questoesFinais;

            return new Teste(materia, disciplina, numeroQuestoes, serieNome, questoes, titulo, recuperacao);
        }

        public void ConfigurarTela(Teste teste)
        {
            tbTitulo.Text = teste.titulo;
            cbMateria.SelectedItem = teste.materia;
            cbDisciplina.SelectedItem = teste.disciplina;
            numericNumeroQuestoes.Value = teste.numeroQuestoes;
            cxRadio.Controls.OfType<RadioButton>().SingleOrDefault(RadioButton => RadioButton.Checked).Text = teste.serie;

            EncherListBox(teste.questoes);
        }

        public void EncherBox()
        {
            foreach (Disciplina item in repositorioDisciplina.SelecionarTodos())
                cbDisciplina.Items.Add(item);
        }

        public List<Questao> GeradorQuestao(Materia materia)
        {
            List<Questao> todasQuestoes = repositorioMateria.SelecionarQuestoesMateria(materia);

            List<Questao> questoesSorteadas = new List<Questao>();
            Random rand = new Random();

            for (int i = 0; i < numericNumeroQuestoes.Value; i++)
            {
                int numero = rand.Next(0, todasQuestoes.Count);

                if (questoesSorteadas.Contains(todasQuestoes[numero]))
                {
                    i--;
                    continue;
                }

                questoesSorteadas.Add(todasQuestoes[numero]);
            }

            questoesFinais = questoesSorteadas;

            return questoesSorteadas;
        }

        public List<Questao> GeradorQuestao(Disciplina disciplina)
        {
            List<Questao> todasQuestoes = new List<Questao>();

            todasQuestoes = repositorioQuestoes.SelecionarQuestoesDisciplina(disciplina);

            List<Questao> questoesSorteadas = new List<Questao>();
            Random rand = new Random();

            for (int i = 0; i < numericNumeroQuestoes.Value; i++)
            {
                int numero = rand.Next(0, todasQuestoes.Count);

                if (questoesSorteadas.Contains(todasQuestoes[numero]))
                {
                    i--;
                    continue;
                }

                questoesSorteadas.Add(todasQuestoes[numero]);
            }
            questoesFinais = questoesSorteadas;

            return questoesSorteadas;
        }

        private void EncherListBox(List<Questao> questoes)
        {
            listBox1.Items.Clear();

            foreach (Questao questao in questoes)
                listBox1.Items.Add(questao);
        }


        private void PegarMateriasDisciplina(Disciplina? disciplina)
        {
            cbMateria.Text = "";

            cbMateria.Items.Clear();

            foreach (Materia item in repositorioMateria.SelecionarMateriasDaDisciplina(disciplina))
                cbMateria.Items.Add(item);
        }

        private void cbDisciplina_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!checkRecuperacao.Checked)
                cbMateria.Enabled = true;

            Disciplina disciplina = cbDisciplina.SelectedItem as Disciplina;

            PegarMateriasDisciplina(disciplina);
        }

        private void button2_Click_1(object sender, EventArgs e) //Gerar Questoes
        {
            Teste teste = ObterTeste();

            if (teste.materia == null)
            {
                int numeroQuestoesTotais = repositorioQuestoes.SelecionarQuestoesDisciplina(teste.disciplina).Count;

                if (numericNumeroQuestoes.Value > numeroQuestoesTotais)
                {
                    MessageBox.Show($"O numero de questoes deve ser menor ou igual ao numero de questoes cadastradas: {numeroQuestoesTotais}", "Nao possui questoes suficinetes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                teste.questoes.Clear();
                teste.questoes = GeradorQuestao(teste.disciplina);
            }

            else
            {
                int numero = repositorioMateria.SelecionarQuestoesMateria(teste.materia).Count;

                if (numericNumeroQuestoes.Value > numero)
                {
                    MessageBox.Show($"O numero de questoes deve ser menor ou igual ao numero de questoes cadastradas: {numero}", "Nao possui questoes suficinetes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                teste.questoes.Clear();
                teste.materia.questoes = repositorioMateria.SelecionarQuestoesMateria(teste.materia);
                teste.questoes = GeradorQuestao(teste.materia);
            }

            EncherListBox(teste.questoes);
        }

        private void button1_Click(object sender, EventArgs e) //Cadastrar
        {
            Teste teste = ObterTeste();

            List<Teste> testes = repositorioTeste.SelecionarTodos();
            string[] erros = teste.Validar();

            if (testes.Any(t => t.titulo == teste.titulo))
            {
                TelaPrincipal.Instancia.AtualizarRodape("Nao eh possivel cadastrar um teste com o mesmo titulo de outro!");
                DialogResult = DialogResult.None;
                return;
            }

            if (erros.Length > 0)
            {
                TelaPrincipal.Instancia.AtualizarRodape(erros[0]);
                DialogResult = DialogResult.None;
                return;
            }



        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        public string ObterTituloTeste()
        {
            return tbTitulo.Text;
        }


        private void checkRecuperacao_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkRecuperacao.Checked)
            {
                cbMateria.Enabled = true;
            }
            else
            {
                cbMateria.Text = "";
                cbMateria.Enabled = false;
                recuperacao = true;
            }
        }
    }
}
