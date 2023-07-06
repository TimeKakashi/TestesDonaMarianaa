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

            return new Teste(materia, disciplina, numeroQuestoes, serie);
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
            List<Materia> materias = new List<Materia>();
            List<Disciplina> disciplinas = new List<Disciplina>();
            List<Questao> questoes = repositorioQuestoes.SelecionarTodos();

            Disciplina disciplina = new Disciplina("Fisica", 2);
            Materia materia = new Materia(1, "Arquimedes", "Primeira", disciplina);
            materia.questoes = questoes;

            materias.Add(materia);
            disciplinas.Add(disciplina);

            foreach (Materia item in materias)
            {
                cbMateria.Items.Add(item);
            }

            foreach (Disciplina item in disciplinas)
            {
                cbDisciplina.Items.Add(item);
            }




            //foreach (Materia materia in repositorioMateria.SelecionarTodos())
            //{
            //    cbMateria.Items.Add(materia);
            //}

            //foreach (Disciplina disciplina in repositorioDisciplina.SelecionarTodos())
            //{
            //    cbDisciplina.Items.Add(disciplina);
            //}
        }

        public List<Questao> GeradorQuestao(Materia materia)
        {
            List<Questao> todasQuestoes = materia.questoes;


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

            return questoesSorteadas;
        }

        public List<Questao> GeradorQuestao(Disciplina disciplina)
        {
            List<Questao> todasQuestoes = new List<Questao>();

            foreach (Materia materia in disciplina.listaMateria)
            {
                foreach (Questao questao in materia.questoes)
                {
                    todasQuestoes.Add(questao);
                }
            }


            List<Questao> questoesSorteadas = new List<Questao>();
            Random rand = new Random();

            for (int i = 0; i < numericNumeroQuestoes.Value; i++)
            {
                int numero = rand.Next(1, todasQuestoes.Count);

                if (questoesSorteadas.Contains(todasQuestoes[numero]))
                {
                    i--;
                    continue;
                }

                questoesSorteadas.Add(todasQuestoes[numero]);
            }

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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Teste teste = ObterTeste();

            if (teste.materia == null)
            {
                teste.questoes.Clear();
                teste.questoes = GeradorQuestao(teste.disciplina);

                int numero = teste.materia.questoes.Count;

                if (numericNumeroQuestoes.Value > numero)
                {
                    MessageBox.Show($"O numero de questoes deve ser menor ou igual ao numero de questoes cadastradas: {numero}", "Nao possui questoes suficinetes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


            }

            else
            {
                int numero = teste.materia.questoes.Count;

                if (numericNumeroQuestoes.Value > numero)
                {
                    MessageBox.Show($"O numero de questoes deve ser menor ou igual ao numero de questoes cadastradas: {numero}", "Nao possui questoes suficinetes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                teste.questoes.Clear();
                teste.questoes = GeradorQuestao(teste.materia);
            }

            EncherListBox(teste.questoes);
        }
    }
}
