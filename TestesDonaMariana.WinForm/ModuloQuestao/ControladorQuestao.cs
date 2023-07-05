using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDonaMariana.Dominio.ModuloMateria;
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

        public override void Inserir()
        {
            TelaQuestao telaQuestao = new TelaQuestao(/*repositorioMateria*/);

            DialogResult opcaoEscolhida = telaQuestao.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                Questao questao = telaQuestao.ObterQuestao();

                repositorioQuestao.Inserir(questao);
                repositorioQuestao.InserirAlternativa(questao.alternativas, questao);
                List<string> lista = repositorioQuestao.SelecionarAlternativas(questao);
            }

            CarregarQuestoes();
        }

        public override void Editar()
        {
            Questao questao = ObterQuestaoSelecionada();

            if (questao == null)
            {
                MessageBox.Show($"Selecione uma questao primeiro!",
                    "Edição de Questoes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            TelaQuestao telaQuestao = new TelaQuestao(/*repositorioMateria*/);
            telaQuestao.ConfigurarTela(questao);

            DialogResult opcaoEscolhida = telaQuestao.ShowDialog();

            if(opcaoEscolhida == DialogResult.OK )
            {
                Questao questaoAtualizada = telaQuestao.ObterQuestao();
                repositorioQuestao.Editar(questaoAtualizada.id, questaoAtualizada );
            }

            CarregarQuestoes();
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
