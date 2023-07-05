using TestesDonaMariana.WinForm.Compartilhado;
using TestesDonaMariana.WinForm.ModuloDisciplina;
using TestesDonaMariana.Dominio.ModuloDisciplina;
using TestesDonaMariana.WinForm.ModuloMateria;
using TestesDonaMariana.WinForm.ModuloQuestao;
using TestesDonaMariana.WinForm.ModuloTeste;
using TestesDonaMariana.Dominio.ModuloGabarito;
using TestesDonaMariana.Dominio.ModuloMateria;
using TestesDonaMariana.Dominio.ModuloQuestoes;
using TestesDonaMariana.Dominio.ModuloTeste;
using TestesDonaMariana.Infra.Dados.Sql.ModuloQuestaoSql;
using TestesDonaMariana.Infra.Dados.Sql.ModuloMateriaSql;
using TestesDonaMariana.Infra.Dados.Sql.ModuloGabaritoSql;
using TestesDonaMariana.Infra.Dados.Sql.ModuloDisciplinaSql;
using TestesDonaMariana.Infra.Dados.Sql.ModuloTesteSql;

namespace TestesDonaMariana.WinForm
{
    public partial class TelaPrincipal : Form
    {
        private IRepositorioDisciplina repositorioDisciplina = new RepositorioDisciplinaSql();
        private IRepositorioGabarito repositorioGabarito = new RepositorioGabaritoSql();
        private IRepositorioMateria repositorioMateria = new RepositorioMateriaSql();
        private IRepositorioQuestoes repositorioQuestao = new RepositorioQuestaoSql();
        private IRepositorioTeste repositorioTeste = new RepositorioTesteSql();

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
            btnGerarGabarito.Enabled = controlador.GerarGabaritoHabilitado;
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
            controlador = new ControladorQuestao(repositorioQuestao, repositorioMateria);
            ConfigurarTelaPrincipal(controlador);
        }

        private void testeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlador = new ControladorTeste(repositorioTeste, repositorioGabarito, repositorioDisciplina, repositorioMateria);
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

            controlador.Filtrar();
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
    }
}