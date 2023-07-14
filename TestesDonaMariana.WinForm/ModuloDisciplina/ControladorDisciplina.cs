using FluentResults;
using TestesDonaMariana.Aplicacao.ModuloQuestao;
using TestesDonaMariana.Dominio.ModuloDisciplina;
using TestesDonaMariana.WinForm.Compartilhado;

namespace TestesDonaMariana.WinForm.ModuloDisciplina
{
    public class ControladorDisciplina : ControladorBase
    {
        private IRepositorioDisciplina repositorioDisciplina;
        private ListagemDisciplinaControl listagemDisciplina;
        private ServicoDisciplina servicoDisciplina;

        public ControladorDisciplina(IRepositorioDisciplina repositorioDisciplina, ServicoDisciplina servicoDisciplina)
        {
            this.repositorioDisciplina = repositorioDisciplina;
            this.servicoDisciplina = servicoDisciplina;
        }

        public override string ToolTipInserir => "Cadastrar Disciplina";

        public override string ToolTipEditar => "Editar Disciplina";

        public override string ToolTipExcluir => "Excluir Disciplina";
        public override string ToolTipDuplicar => "Este botão está desabilitado nessa Tela";


        public override string ToolTipFiltrar => "VisualizarTeste Disciplinas";

        public override string ToolTipPdf => "Este botão está desabilitado nessa Tela";

        public override string ToolTipGabarito => "Este botão está desabilitado nessa Tela";

        private Disciplina ObterDisciplinaSelecionado()
        {
            int id = listagemDisciplina.ObterIdSelecionado();

            return repositorioDisciplina.SelecionarPorId(id);
        }

        private void CarregarDisciplina()
        {
            List<Disciplina> disciplinas = repositorioDisciplina.SelecionarTodos();

            listagemDisciplina.AtualizarRegistros(disciplinas);
        }

        public override UserControl ObterListagem()
        {
            if (listagemDisciplina == null)
                listagemDisciplina = new ListagemDisciplinaControl();

            CarregarDisciplina();
            return listagemDisciplina;
        }

        public override string ObterTipoCadastro()
        {
            return "Cadastro de Disciplina";
        }

        public override void Inserir()
        {
            TelaDisciplina telaDisciplina = new TelaDisciplina();

            telaDisciplina.onGravarRegistro += servicoDisciplina.Inserir;

            DialogResult opcaoEscolhida = telaDisciplina.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
                CarregarDisciplina();
        }


        public override void Editar()
        {
            Disciplina disciplinaSelecionada = ObterDisciplinaSelecionado();

            if (disciplinaSelecionada == null)
            {
                MessageBox.Show("Nenhuma Disciplina Selecionada!", "Editar Disciplina", MessageBoxButtons.OK);
                return;
            }

            TelaDisciplina telaDisciplina = new TelaDisciplina(repositorioDisciplina);
            telaDisciplina.ConfigurarTela(disciplinaSelecionada);
            telaDisciplina.onGravarRegistro += servicoDisciplina.Editar;

            DialogResult opcaoEscolhida = telaDisciplina.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
                CarregarDisciplina();

        }


        public override void Excluir()
        {
            Disciplina disciplinaSelecionada = ObterDisciplinaSelecionado();

            if (disciplinaSelecionada == null)
            {
                MessageBox.Show("Nenhuma Disciplina Selecionada", "Excluir Disciplina", MessageBoxButtons.OK);
                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show($"Deseja Excluir a Disciplina {disciplinaSelecionada}?", "Exclusão de Disciplina", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                Result resultado = servicoDisciplina.Excluir(disciplinaSelecionada);

                if (resultado.IsFailed)
                {
                    MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Disciplina", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                CarregarDisciplina();
            }
        }
    }
}
