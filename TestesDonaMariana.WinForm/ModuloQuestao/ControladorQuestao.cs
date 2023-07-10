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

        public ControladorQuestao(IRepositorioQuestoes repositorioQuestao, IRepositorioMateria repositorioMateria, IRepositorioTeste repositorioTeste)
        {
            this.repositorioQuestao = repositorioQuestao;
            this.repositorioMateria = repositorioMateria;
            this.repositorioTeste = repositorioTeste;
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

            bool nomeRepetido = false;

            do
            {
                DialogResult opcaoEscolhida = telaQuestao.ShowDialog();

                if (opcaoEscolhida == DialogResult.OK)
                {
                    Questao questao = telaQuestao.ObterQuestao();

                    List<Questao> listaQuestoes = repositorioQuestao.SelecionarTodos();
                    if (listaQuestoes.Any(x => x.titulo.ToLower() == questao.titulo.ToLower()))
                    {
                        // Nome repetido, exibir mensagem de erro e continuar na tela de inserção
                        TelaPrincipal.Instancia.AtualizarRodape("O nome da questão já existe. Por favor, insira um nome diferente.");
                        nomeRepetido = true;
                    }
                    else
                    {
                        repositorioQuestao.Inserir(questao);
                        repositorioQuestao.InserirAlternativa(questao.alternativas, questao);
                        List<Alternativa> lista = repositorioQuestao.SelecionarAlternativas(questao);
                        nomeRepetido = false;
                    }
                }
                else if (opcaoEscolhida == DialogResult.Cancel)
                {
                    // O usuário cancelou a operação de inserção
                    nomeRepetido = false;
                }
            }
            while (nomeRepetido);

            CarregarQuestoes();
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

            bool nomeRepetido = false;

            do
            {
                DialogResult opcaoEscolhida = telaQuestao.ShowDialog();

                if (opcaoEscolhida == DialogResult.OK)
                {
                    Questao questaoAtualizada = telaQuestao.ObterQuestao();
                    questaoAtualizada.id = questao.id;

                    List<Questao> listaQuestoes = repositorioQuestao.SelecionarTodos();
                    if (listaQuestoes.Any(x => x.titulo.ToLower() == questaoAtualizada.titulo.ToLower() && x.id != questaoAtualizada.id))
                    {
                        // Nome repetido, exibir mensagem de erro e continuar na tela de edição
                        TelaPrincipal.Instancia.AtualizarRodape("O nome da questão já existe. Por favor, insira um nome diferente.");
                        nomeRepetido = true;
                    }
                    else
                    {
                        repositorioQuestao.Editar(questaoAtualizada.id, questaoAtualizada);
                        EditarAlternativas(questaoAtualizada);
                        nomeRepetido = false;
                    }
                }
                else if (opcaoEscolhida == DialogResult.Cancel)
                {
                    // O usuário cancelou a operação de edição
                    nomeRepetido = false;
                }
            }
            while (nomeRepetido);

            CarregarQuestoes();
        }


        private void EditarAlternativas(Questao questaoAtualizada)
        {
            int contador = 0;
            List<Alternativa> alternativasIdCorreto = repositorioQuestao.SelecionarAlternativas(questaoAtualizada);

            foreach (Alternativa item in questaoAtualizada.alternativas)
            {
                item.id = alternativasIdCorreto[contador].id;
                contador++;
            }

            repositorioQuestao.EditarAlternativas(questaoAtualizada);
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

            bool podeExcluir = true;

            foreach (Teste teste in repositorioTeste.SelecionarTodos())
            {
                teste.questoes = repositorioTeste.SelecionarQuestoesPorMateria(teste);

                foreach (Questao q in teste.questoes)
                {
                    if (q.id == questao.id)
                    {
                        podeExcluir = false;
                        break;
                    }
                }
            }

            if (!podeExcluir)
            {
                MessageBox.Show($"Essa questão esta atrelada a um teste!",
                   "Exclusão de Questões",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show($"Deseja excluir a questão {questao.titulo}?", "Exclusão de Questões",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);


            if (opcaoEscolhida == DialogResult.OK)
            {
                repositorioQuestao.Excluir(questao);
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
