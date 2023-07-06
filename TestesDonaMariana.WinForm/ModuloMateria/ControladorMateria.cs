using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDonaMariana.Dominio.ModuloDisciplina;
using TestesDonaMariana.Dominio.ModuloMateria;
using TestesDonaMariana.Dominio.ModuloQuestoes;
using TestesDonaMariana.Infra.Dados.Sql.ModuloMateriaSql;
using TestesDonaMariana.WinForm.Compartilhado;
using TestesDonaMariana.WinForm.ModuloGabarito;

namespace TestesDonaMariana.WinForm.ModuloMateria
{
    public class ControladorMateria : ControladorBase
    {
        private ListagemMateriaControl listagemMateria;
        private IRepositorioMateria repositorioMateria;
        private IRepositorioDisciplina repositorioDisciplina;

        public ControladorMateria(IRepositorioMateria repositorioMateria, IRepositorioDisciplina repositorioDisciplina)
        {
            this.repositorioMateria = repositorioMateria;
            this.repositorioDisciplina = repositorioDisciplina;
            CarregarMaterias();        }

        public override string ToolTipInserir => "Cadastrar Materia";

        public override string ToolTipEditar => "Editar Materia";

        public override string ToolTipExcluir => "Excluir Materia";

        public override bool FiltrarHabilitado => true;
        public override void Editar()
        {
            Materia materia = ObterMateriaSelecionada();

            if (materia == null)
            {
                MessageBox.Show($"Selecione uma materia primeiro!",
                    "Edição de Materias",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            TelaMateria telaMateria = new TelaMateria(repositorioDisciplina);

            telaMateria.ArrumaTela(materia);

            if (telaMateria.ShowDialog() == DialogResult.OK)
            {
                List<Materia> listaMateria = repositorioMateria.SelecionarTodos();

                Materia materiaNova = telaMateria.ObterMateria();
                materiaNova.id = materia.id;

                if (listaMateria.Any(x => x.nome.ToLower() == materiaNova.nome.ToLower() && x.id != materiaNova.id))
                {
                    
                    return;
                }

                repositorioMateria.Editar(materiaNova.id, materiaNova);
            }

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
                repositorioMateria.Excluir(materia);
            }

            CarregarMaterias();
        }



        public override void Inserir()
        {
            TelaMateria telaMateria = new TelaMateria(repositorioDisciplina);
            if (telaMateria.ShowDialog() == DialogResult.OK)
            {
                List<Materia> listaMateria = repositorioMateria.SelecionarTodos();

                Materia materia = telaMateria.ObterMateria();

                if (listaMateria.Any(x => x.nome.ToLower() == materia.nome.ToLower()))
                {
                   
                    return;
                }

                repositorioMateria.Inserir(materia);

                CarregarMaterias();
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
