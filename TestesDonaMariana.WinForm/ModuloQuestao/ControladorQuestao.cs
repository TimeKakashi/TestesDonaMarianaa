using FluentResults;
using TestesDonaMariana.Aplicacao.ModuloQuestao;
using TestesDonaMariana.Dominio.ModuloMateria;
using TestesDonaMariana.Dominio.ModuloQuestao;
using TestesDonaMariana.Dominio.ModuloQuestoes;
using TestesDonaMariana.Dominio.ModuloTeste;
using TestesDonaMariana.WinForm.Compartilhado;

namespace TestesDonaMariana.WinForm.ModuloQuestao
{
    public class ControladorQuestao : ControladorBase
    {
        private ListagemQuestaoControl listagemQuestao;
        private IRepositorioQuestoes repositorioQuestao;
        private IRepositorioMateria repositorioMateria;
        private IRepositorioTeste repositorioTeste;
        private ServicoQuestao servicoQuestao;

        public ControladorQuestao(IRepositorioQuestoes repositorioQuestao, IRepositorioMateria repositorioMateria, IRepositorioTeste repositorioTeste, ServicoQuestao servicoQuestao)
        {
            this.repositorioQuestao = repositorioQuestao;
            this.repositorioMateria = repositorioMateria;
            this.repositorioTeste = repositorioTeste;
            this.servicoQuestao = servicoQuestao;
            CarregarQuestoes();
        }

        public override string ToolTipInserir => "Cadastrar Questão";

        public override string ToolTipEditar => "Editar Questão";

        public override string ToolTipExcluir => "Excluir Questão";

        public override string ToolTipFiltrar => "Este botão está desabilitado nessa Tela";

        public override string ToolTipPdf => "Este botão está desabilitado nessa Tela";

        public override string ToolTipGabarito => "Este botão está desabilitado nessa Tela";

        public override string ToolTipDuplicar => "Este botão está desabilitado nessa Tela";

        public override void Inserir()
        {
            TelaQuestao telaQuestao = new TelaQuestao(repositorioMateria);
           
            telaQuestao.onGravarRegistro += servicoQuestao.Inserir;

            DialogResult opcaoEscolhida = telaQuestao.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                CarregarQuestoes();
            }
        }


        public override void Editar()
        {
            Questao questao = ObterQuestaoSelecionada();

            if (questao == null)
            {
                MessageBox.Show("Selecione uma questão primeiro!", "Edição de Questões", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaQuestao telaQuestao = new TelaQuestao(repositorioMateria);

            telaQuestao.ConfigurarTela(questao);

            telaQuestao.onGravarRegistro += servicoQuestao.Editar;

            DialogResult opcaoEscolhida = telaQuestao.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
                 CarregarQuestoes();
        }

        public override void Excluir()
        {
            Questao questao = ObterQuestaoSelecionada();

            if (questao == null)
            {
                MessageBox.Show($"Selecione uma questão primeiro!",
                    "Exclusão de Questões",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            //bool podeExcluir = true;

            //foreach (Teste teste in repositorioTeste.SelecionarTodos())
            //{
            //    teste.questoes = repositorioTeste.SelecionarQuestoesPorMateria(teste);

            //    foreach (Questao q in teste.questoes)
            //    {
            //        if (q.id == questao.id)
            //        {
            //            podeExcluir = false;
            //            break;
            //        }
            //    }
            //}

            //if (!podeExcluir)
            //{
            //    MessageBox.Show($"Essa questão esta atrelada a um teste!",
            //       "Exclusão de Questões",
            //       MessageBoxButtons.OK,
            //       MessageBoxIcon.Exclamation);
            //    return;
            //}

            DialogResult opcaoEscolhida = MessageBox.Show($"Deseja excluir a questão {questao.titulo}?", "Exclusão de Questões",
                                                            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                Result result = servicoQuestao.Excluir(questao);

                if (result.IsFailed)
                {
                    MessageBox.Show(result.Errors[0].Message, "Exclusão de Questoes", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
            }

            CarregarQuestoes();
        }

        private void CarregarQuestoes()
        {
            List<Questao> listaQuestoes = repositorioQuestao.SelecionarTodos();

            if (listagemQuestao == null)
                listagemQuestao = new ListagemQuestaoControl();

            listagemQuestao.AtualizarRegistros(listaQuestoes);
        }

        public override UserControl ObterListagem()
        {
            if (listagemQuestao == null)
                listagemQuestao = new ListagemQuestaoControl();

            return listagemQuestao;
        }

        public override string ObterTipoCadastro() => "Cadastro de Questões";


        private Questao ObterQuestaoSelecionada()
        {
            int id = listagemQuestao.ObterIdSelecionado();

            Questao questao = repositorioQuestao.SelecionarPorId(id);

            questao.alternativas = repositorioQuestao.SelecionarAlternativas(questao);

            return questao;

        }

    }
}
