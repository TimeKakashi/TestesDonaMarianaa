using System.Drawing.Drawing2D;
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
        private IRepositorioQuestoes repositorioQuestoes { get; }

        List<Questao> questoesFinais { get; set; } = new List<Questao>();

        public TelaTeste()
        {
            InitializeComponent();
        }

        public TelaTeste(IRepositorioDisciplina repositorioDisciplina, IRepositorioMateria repositorioMateria, IRepositorioQuestoes repositorioQuestoes) : this()
        {
            this.repositorioDisciplina = repositorioDisciplina;
            this.repositorioMateria = repositorioMateria;
            this.repositorioQuestoes = repositorioQuestoes;
            EncherBox();
        }

        public Teste ObterTeste()
        {
            Materia materia = (Materia)cbMateria.SelectedItem;
            Disciplina disciplina = (Disciplina)cbDisciplina.SelectedItem;
            int numeroQuestoes = Convert.ToInt32((numericNumeroQuestoes.Value));
            string serie = cxRadio.Controls.OfType<RadioButton>().SingleOrDefault(RadioButton => RadioButton.Checked).Text;
            List<Questao> questoes = questoesFinais;

            return new Teste(materia, disciplina, numeroQuestoes, serie, questoes);
        }

        public void ConfigurarTela(Teste teste)
        {
            cbMateria.SelectedItem = teste.materia;
            cbDisciplina.SelectedItem = teste.disciplina;
            numericNumeroQuestoes.Value = teste.numeroQuestoes;
            cxRadio.Controls.OfType<RadioButton>().SingleOrDefault(RadioButton => RadioButton.Checked).Text = teste.serie;

            EncherListBox(teste.questoes);
        }

        public void EncherBox()
        {



            foreach (Disciplina item in repositorioDisciplina.SelecionarTodos())
            {
                cbDisciplina.Items.Add(item);
            }

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
            {
                listBox1.Items.Add(questao);
            }
        }


        private void PegarMateriasDisciplina(Disciplina? disciplina)
        {
            cbMateria.Enabled = true;

            foreach (Materia item in repositorioMateria.SelecionarMateriasDaDisciplina(disciplina))
            {
                cbMateria.Items.Add(item);
            }
        }

        private void cbDisciplina_SelectedValueChanged(object sender, EventArgs e)
        {
            Disciplina disciplina = cbDisciplina.SelectedItem as Disciplina;

            PegarMateriasDisciplina(disciplina);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Teste teste = ObterTeste();

            if (teste.materia == null)
            {
                teste.questoes.Clear();
                teste.questoes = GeradorQuestao(teste.disciplina);

                int numero = 0;

                if (teste.materia != null)
                    numero = teste.materia.questoes.Count;

                else
                    numero = repositorioQuestoes.SelecionarQuestoesDisciplina(teste.disciplina).Count;


                if (numericNumeroQuestoes.Value > numero)
                {
                    MessageBox.Show($"O numero de questoes deve ser menor ou igual ao numero de questoes cadastradas: {numero}", "Nao possui questoes suficinetes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
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
    }
}
