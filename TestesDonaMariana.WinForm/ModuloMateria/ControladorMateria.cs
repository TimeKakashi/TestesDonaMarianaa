using FluentResults;
using TestesDonaMariana.Aplicacao.ModuloQuestao;
using TestesDonaMariana.Dominio.ModuloDisciplina;
using TestesDonaMariana.Dominio.ModuloMateria;
using TestesDonaMariana.Dominio.ModuloQuestoes;
using TestesDonaMariana.WinForm.Compartilhado;

namespace TestesDonaMariana.WinForm.ModuloMateria
{
    public class ControladorMateria : ControladorBase
    {
        private ListagemMateriaControl listagemMateria;
        private IRepositorioMateria repositorioMateria;
        private IRepositorioDisciplina repositorioDisciplina;
        private IRepositorioQuestoes repositorioQuestao;
        private ServicoMateria servicoMateria;

        public ControladorMateria(IRepositorioMateria repositorioMateria, IRepositorioDisciplina repositorioDisciplina, IRepositorioQuestoes repositorioQuestao, ServicoMateria servicoMateria)
        {
            this.repositorioMateria = repositorioMateria;
            this.repositorioDisciplina = repositorioDisciplina;
            this.repositorioQuestao = repositorioQuestao;
            this.servicoMateria = servicoMateria;
            CarregarMaterias();
        }

        public override string ToolTipInserir => "Cadastrar Materia";

        public override string ToolTipEditar => "Editar Materia";

        public override string ToolTipExcluir => "Excluir Materia";
        public override string ToolTipFiltrar => "VisualizarTeste Matérias";

        public override string ToolTipPdf => "Este botão está desabilitado nessa Tela";

        public override string ToolTipGabarito => "Este botão está desabilitado nessa Tela";

        public override string ToolTipDuplicar => "Este botão está desabilitado nessa Tela";

        public override void Editar()
        {
            Materia materia = ObterMateriaSelecionada();

            if (materia == null)
            {
                MessageBox.Show("Selecione uma matéria primeiro!", "Edição de Matérias", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaMateria telaMateria = new TelaMateria(repositorioDisciplina, repositorioMateria);
            telaMateria.ArrumaTela(materia);
            telaMateria.onGravarRegistro += servicoMateria.Editar;

            DialogResult result = telaMateria.ShowDialog();

            if (result == DialogResult.OK)
                CarregarMaterias();
        }


        public override void Excluir()
        {
            Materia materia = ObterMateriaSelecionada();

            if (materia == null)
            {
                MessageBox.Show("Selecione uma matéria primeiro!",
                    "Exclusão de Matéria",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show($"Deseja excluir a matéria {materia.nome}?", "Exclusão de Matéria",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);


            if (opcaoEscolhida == DialogResult.OK)
            {
                Result result = servicoMateria.Excluir(materia);

                if (result.IsFailed)
                {
                    MessageBox.Show(result.Errors[0].Message, "Exclusão de Materia", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
            }

            CarregarMaterias();
        }



        public override void Inserir()
        {
            TelaMateria telaMateria = new TelaMateria(repositorioDisciplina, repositorioMateria);

            telaMateria.onGravarRegistro += servicoMateria.Inserir;

            DialogResult result = telaMateria.ShowDialog();

            if (result == DialogResult.OK)
                CarregarMaterias();
        }



        private void CarregarMaterias()
        {
            List<Materia> listaMaterias = repositorioMateria.SelecionarTodos();

            if (listagemMateria == null)
                listagemMateria = new ListagemMateriaControl();

            listagemMateria.AtualizarRegistros(listaMaterias);
        }

        public override UserControl ObterListagem()
        {
            if (listagemMateria == null)
                listagemMateria = new ListagemMateriaControl();

            return listagemMateria;
        }


        public override string ObterTipoCadastro() => "Cadastro de Matérias";
        private Materia ObterMateriaSelecionada()
        {
            int id = listagemMateria.ObterIdSelecionado();

            Materia materia = repositorioMateria.SelecionarPorId(id);

            return materia;
        }





    }
}
