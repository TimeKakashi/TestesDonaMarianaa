using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDonaMariana.Dominio.ModuloMateria;
using TestesDonaMariana.Dominio.ModuloQuestao;
using TestesDonaMariana.Dominio.ModuloQuestoes;
using TestesDonaMariana.WinForm.Compartilhado;

namespace TestesDonaMariana.WinForm.ModuloQuestao
{
    public class ControladorQuestao : ControladorBase
    {
        private ListagemQuestaoControl listagemQuestao;
        private IRepositorioQuestoes repositorioQuestao;
        private IRepositorioMateria repositorioMateria;

        public ControladorQuestao(IRepositorioQuestoes repositorioQuestao, IRepositorioMateria repositorioMateria)
        {
            this.repositorioQuestao = repositorioQuestao;
            this.repositorioMateria = repositorioMateria;
            CarregarQuestoes();
        }

        public override string ToolTipInserir => "Cadastrar Questao";

        public override string ToolTipEditar => "Editar Questao";

        public override string ToolTipExcluir => "Excluir Questao";

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
                MessageBox.Show($"Selecione uma questao primeiro!",
                    "Exclusão de Questoes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show($"Deseja excluir a questao {questao.titulo}?", "Exclusão de Questoes",
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

        public override string ObterTipoCadastro() => "Cadastro de Questao";
        

        private Questao ObterQuestaoSelecionada()
        {
            int id = listagemQuestao.ObterIdSelecionado();

            Questao questao = repositorioQuestao.SelecionarPorId(id);

            questao.alternativas = repositorioQuestao.SelecionarAlternativas(questao);

            return questao;

        }

    }
}
