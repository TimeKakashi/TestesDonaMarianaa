using TestesDonaMariana.Aplicacao.ModuloQuestao;
using TestesDonaMariana.Dominio;
using TestesDonaMariana.Dominio.ModuloDisciplina;
using TestesDonaMariana.Dominio.ModuloGabarito;
using TestesDonaMariana.Dominio.ModuloMateria;
using TestesDonaMariana.Dominio.ModuloQuestoes;
using TestesDonaMariana.Dominio.ModuloTeste;
using TestesDonaMariana.Infra.Dados.Sql.ModuloDisciplinaSql;
using TestesDonaMariana.Infra.Dados.Sql.ModuloGabaritoSql;
using TestesDonaMariana.Infra.Dados.Sql.ModuloMateriaSql;
using TestesDonaMariana.Infra.Dados.Sql.ModuloQuestaoSql;
using TestesDonaMariana.Infra.Dados.Sql.ModuloTesteSql;
using TestesDonaMariana.WinForm.Compartilhado;
using TestesDonaMariana.WinForm.ModuloDisciplina;
using TestesDonaMariana.WinForm.ModuloMateria;
using TestesDonaMariana.WinForm.ModuloQuestao;
using TestesDonaMariana.WinForm.ModuloTeste;

namespace TestesDonaMariana.WinForm
{
    public partial class TelaPrincipal : Form
    {
        private IRepositorioDisciplina repositorioDisciplina = new RepositorioDisciplinaSql();
        private IRepositorioGabarito repositorioGabarito = new RepositorioGabaritoSql();
        private IRepositorioMateria repositorioMateria = new RepositorioMateriaSql();
        private IRepositorioQuestoes repositorioQuestao = new RepositorioQuestaoSql();
        private IRepositorioTeste repositorioTeste = new RepositorioTesteSql();
    
        
        

        private static TelaPrincipal telaPrincipal;
        public ControladorBase controlador { get; set; }

        public TelaPrincipal()
        {
            InitializeComponent();

            Serie serie = repositorioMateria.SelecionarSerieNome("Primeira Serie");

            if (serie == null)
                repositorioMateria.InserirSeries();

            telaPrincipal = this;
        }
        public static TelaPrincipal Instancia
        {
            get
            {
                if (telaPrincipal == null)
                    telaPrincipal = new TelaPrincipal();

                return telaPrincipal;
            }
        }

        public void AtualizarRodape(string mensagem)
        {
            StatusLabel.Text = mensagem;
        }

        public void ConfigurarTelaPrincipal(ControladorBase controlador)
        {
            toolStripLabel1.Text = controlador.ObterTipoCadastro();
            ConfigurarToolTips(controlador);
            ConfigurarListagem(controlador);
            ConfigurarEstados(controlador);
        }

        private void ConfigurarEstados(ControladorBase controlador)
        {
            btnInserir.Enabled = controlador.InserirHabilitado;
            btnEditar.Enabled = controlador.EditarHabilitado;
            btnExcluir.Enabled = controlador.ExcluirHabilitado;
            btnFiltrar.Enabled = controlador.VisualizarHabilitado;
            btnGerarGabarito.Enabled = controlador.GerarGabaritoHabilitado;
            btnPdf.Enabled = controlador.GerarPdfHabilitado;
            btnDuplicar.Enabled = controlador.DuplicarHabilitado;
        }

        private void ConfigurarToolTips(ControladorBase controlador)
        {
            btnInserir.ToolTipText = controlador.ToolTipInserir;
            btnEditar.ToolTipText = controlador.ToolTipEditar;
            btnExcluir.ToolTipText = controlador.ToolTipExcluir;
            btnFiltrar.ToolTipText = controlador.ToolTipFiltrar;
            btnGerarGabarito.ToolTipText = controlador.ToolTipGabarito;
            btnPdf.ToolTipText = controlador.ToolTipPdf;
            btnDuplicar.ToolTipText = controlador.ToolTipDuplicar;
        }

        private void ConfigurarListagem(ControladorBase controlador)
        {
            UserControl listagem = controlador.ObterListagem();
            listagem.Dock = DockStyle.Fill;
            panelRegistros.Controls.Clear();
            panelRegistros.Controls.Add(listagem);
        }

        private void disciplinaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ServicoDisciplina servicoDisciplina = new ServicoDisciplina(repositorioDisciplina);
            controlador = new ControladorDisciplina(repositorioDisciplina, servicoDisciplina);
            ConfigurarTelaPrincipal(controlador);
        }

        private void materiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlador = new ControladorMateria(repositorioMateria, repositorioDisciplina, repositorioQuestao);
            ConfigurarTelaPrincipal(controlador);
        }

        private void questaoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ServicoQuestao servicoQuestao = new ServicoQuestao(repositorioQuestao);
            controlador = new ControladorQuestao(repositorioQuestao, repositorioMateria, repositorioTeste, servicoQuestao);
            ConfigurarTelaPrincipal(controlador);
        }

        private void testeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlador = new ControladorTeste(repositorioTeste, repositorioGabarito, repositorioDisciplina, repositorioMateria, repositorioQuestao);
            ConfigurarTelaPrincipal(controlador);
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            if (controlador == null)
            {
                MessageBox.Show("Selecione uma area primeiro!",
                  "Eh necessario selecionar uma area",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            controlador.Inserir();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (controlador == null)
            {
                MessageBox.Show("Selecione uma area primeiro!",
                  "Eh necessario selecionar uma area",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            controlador.Editar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (controlador == null)
            {
                MessageBox.Show("Selecione uma area primeiro!",
                  "Eh necessario selecionar uma area",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            controlador.Excluir();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (controlador == null)
            {
                MessageBox.Show("Selecione uma area primeiro!",
                  "Eh necessario selecionar uma area",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            controlador.VisualizarTeste();
        }

        private void btnGerarGabarito_Click(object sender, EventArgs e)
        {
            if (controlador == null)
            {
                MessageBox.Show("Selecione uma area primeiro!",
                  "Eh necessario selecionar uma area",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            controlador.GerarGabarito();
        }

        private void btnPdf_Click(object sender, EventArgs e)
        {
            if (controlador == null)
                MessageBox.Show("Selecione uma area primeiro!",
                    "Eh necessario selecionar uma area",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            controlador.GerarPdf();
        }


        private void btnDuplicar_Click(object sender, EventArgs e)
        {
            if (controlador == null)
            {
                MessageBox.Show("Selecione uma área primeiro!",
                    "É necessário selecionar uma área",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (controlador is ControladorTeste controladorTeste)
            {
                controladorTeste.DuplicarTeste();
            }
        }

    }
}