using TestesDonaMariana.WinForm.Compartilhado;
using TestesDonaMariana.WinForm.ModuloDisciplina;
using TestesDonaMariana.Dominio.ModuloDisciplina;
using TestesDonaMariana.Infra.Dados.Sql.Disciplina;
using TestesDonaMariana.WinForm.ModuloMateria;
using TestesDonaMariana.WinForm.ModuloQuestao;
using TestesDonaMariana.WinForm.ModuloTeste;
using TestesDonaMariana.Dominio.ModuloGabarito;
using TestesDonaMariana.Infra.Dados.Sql.Gabarito;
using TestesDonaMariana.Dominio.ModuloMateria;
using TestesDonaMariana.Infra.Dados.Sql.Materia;
using TestesDonaMariana.Dominio.ModuloQuestoes;
using TestesDonaMariana.Infra.Dados.Sql.Questao;
using TestesDonaMariana.Dominio.ModuloTeste;
using TestesDonaMariana.Infra.Dados.Sql.Teste;

namespace TestesDonaMariana.WinForm
{
    public partial class TelaPrincipal : Form
    {
        private IRepositorioDisciplina repositorioDisciplina = new RepositorioDisciplinaSql();
        private IRepositorioGabarito repositorioGabarito = new RepositorioGabarito();
        private IRepositorioMateria repositorioMateria = new RepositorioMateria();
        private IRepositorioQuestoes repositorioQuestao = new RepositorioQuestao();
        private IRepositorioTeste repositorioTeste = new RepositorioTeste();

        public ControladorBase controlador { get; set; }
        public TelaPrincipal()
        {
            InitializeComponent();

        }

        public void ConfigurarTelaPrincipal(ControladorBase controlador)
        {
            ConfigurarToolTips(controlador);
            ConfigurarListagem(controlador);
            ConfigurarEstados(controlador);
        }

        private void ConfigurarEstados(ControladorBase controlador)
        {
            btnInserir.Enabled = controlador.InserirHabilitado;
            btnEditar.Enabled = controlador.EditarHabilitado;
            btnExcluir.Enabled = controlador.ExcluirHabilitado;
            btnFiltrar.Enabled = controlador.FiltrarHabilitado;
            btnGerarGabarito.Enabled = controlador.GerarGabarito;
            btnPdf.Enabled = controlador.GerarPdfHabilitado;
        }

        private void ConfigurarToolTips(ControladorBase controlador)
        {
            btnInserir.ToolTipText = controlador.ToolTipInserir;
            btnEditar.ToolTipText = controlador.ToolTipEditar;
            btnExcluir.ToolTipText = controlador.ToolTipExcluir;
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
            controlador = new ControladorDisciplina(repositorioDisciplina);
            ConfigurarTelaPrincipal(controlador);
        }

        private void materiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlador = new ControladorMateria(repositorioMateria);
            ConfigurarTelaPrincipal(controlador);
        }

        private void questaoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlador = new ControladorQuestao(repositorioQuestao);
            ConfigurarTelaPrincipal(controlador);
        }

        private void testeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlador = new ControladorTeste(repositorioTeste, repositorioGabarito);
            ConfigurarTelaPrincipal(controlador);
        }
    }
}