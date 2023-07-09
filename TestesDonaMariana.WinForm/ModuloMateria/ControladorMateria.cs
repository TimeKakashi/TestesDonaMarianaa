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

        public ControladorMateria(IRepositorioMateria repositorioMateria, IRepositorioDisciplina repositorioDisciplina, IRepositorioQuestoes repositorioQuestao)
        {
            this.repositorioMateria = repositorioMateria;
            this.repositorioDisciplina = repositorioDisciplina;
            this.repositorioQuestao = repositorioQuestao;
            CarregarMaterias();
        }

        public override string ToolTipInserir => "Cadastrar Materia";

        public override string ToolTipEditar => "Editar Materia";

        public override string ToolTipExcluir => "Excluir Materia";
        public override string ToolTipFiltrar => "Filtrar Matérias";

        public override string ToolTipPdf => "Este botão está desabilitado nessa Tela";

        public override string ToolTipGabarito => "Este botão está desabilitado nessa Tela";

        public override string ToolTipDuplicar => "Este botão está desabilitado nessa Tela";

        public override bool FiltrarHabilitado => true;



        public override void Editar()
        {
            Materia materia = ObterMateriaSelecionada();

            if (materia == null)
            {
                MessageBox.Show("Selecione uma matéria primeiro!", "Edição de Matérias", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaMateria telaMateria = new TelaMateria(repositorioDisciplina);
            telaMateria.ArrumaTela(materia);

            while (true)
            {
                DialogResult result = telaMateria.ShowDialog();

                if (result == DialogResult.OK)
                {
                    List<Materia> listaMateria = repositorioMateria.SelecionarTodos();
                    Materia materiaNova = telaMateria.ObterMateria();
                    materiaNova.id = materia.id;

                    if (listaMateria.Any(x => x.nome.ToLower() == materiaNova.nome.ToLower() && x.id != materiaNova.id))
                    {
                        TelaPrincipal.Instancia.AtualizarRodape("O nome da matéria já existe. Por favor, insira um nome diferente.");
                        continue;
                    }

                    repositorioMateria.Editar(materiaNova.id, materiaNova);

                    break;
                }
                else if (result == DialogResult.Cancel)
                    break;
            }

            CarregarMaterias();
        }


        public override void Excluir()
        {
            Materia materia = ObterMateriaSelecionada();
            bool PossuiQuestao = false;

            if (materia == null)
            {
                MessageBox.Show("Selecione uma matéria primeiro!",
                    "Exclusão de Matéria",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            int quantidadeQuestao = repositorioMateria.SelecionarQuestoesMateria(materia).Count;

            if (quantidadeQuestao > 0)
            {
                MessageBox.Show("Essa materia possui questoes atreladas!",
                    "Exclusão de Matéria",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show($"Deseja excluir a matéria {materia.nome}?", "Exclusão de Matéria",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);


            if (opcaoEscolhida == DialogResult.OK)
            {
                repositorioMateria.Excluir(materia);
            }

            CarregarMaterias();
        }



        public override void Inserir()
        {
            TelaMateria telaMateria = new TelaMateria(repositorioDisciplina);
            while (true)
            {
                DialogResult result = telaMateria.ShowDialog();

                if (result == DialogResult.OK)
                {
                    List<Materia> listaMateria = repositorioMateria.SelecionarTodos();
                    Materia materia = telaMateria.ObterMateria();

                    if (listaMateria.Any(x => x.nome.ToLower() == materia.nome.ToLower()))
                    {
                        TelaPrincipal.Instancia.AtualizarRodape("O nome da matéria já existe. Por favor, insira um nome diferente.");
                        continue;
                    }

                    repositorioMateria.Inserir(materia);
                    CarregarMaterias();
                    break;
                }
                else if (result == DialogResult.Cancel)
                    break;

            }
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
