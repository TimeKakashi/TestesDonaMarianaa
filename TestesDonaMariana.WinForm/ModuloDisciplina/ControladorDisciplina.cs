using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDonaMariana.Dominio.ModuloDisciplina;
using TestesDonaMariana.Infra.Dados.Sql.ModuloDisciplinaSql;
using TestesDonaMariana.WinForm.Compartilhado;

namespace TestesDonaMariana.WinForm.ModuloDisciplina
{
    public class ControladorDisciplina : ControladorBase
    {
        private IRepositorioDisciplina repositorioDisciplina;
        ListagemDisciplinaControl listagemDisciplina;

        public ControladorDisciplina(IRepositorioDisciplina repositorioDisciplina)
        {
            this.repositorioDisciplina = repositorioDisciplina;
        }

        public override string ToolTipInserir => "Cadastrar Disciplina";

        public override string ToolTipEditar => "Editar Disciplina";

        public override string ToolTipExcluir => "Excluir Disciplina";
        public override string ToolTipDuplicar => "Este botão está desabilitado nessa Tela";


        public override string ToolTipFiltrar => "Filtrar Disciplinas";

        public override string ToolTipPdf => "Este botão está desabilitado nessa Tela";

        public override string ToolTipGabarito => "Este botão está desabilitado nessa Tela";
        public override bool FiltrarHabilitado => true;

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
            DialogResult opcaoEscolhida = telaDisciplina.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK) 
            {
                Disciplina novaDisciplina = telaDisciplina.ObterDisciplina();
                repositorioDisciplina.Inserir(novaDisciplina);
                CarregarDisciplina();

            }
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

            DialogResult opcaoEscolhida = telaDisciplina.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK) 
            {
                Disciplina novaDisciplina = telaDisciplina.ObterDisciplina();
                novaDisciplina.id = disciplinaSelecionada.id;

                repositorioDisciplina.Editar(novaDisciplina.id, novaDisciplina);

                CarregarDisciplina();
            }
        }

        public override void Excluir()
        {
            Disciplina disciplinaSelecionada = ObterDisciplinaSelecionado();

            if (disciplinaSelecionada == null) 
            {
                MessageBox.Show("Nenhuma Disciplina Selecionada","Excluir Disciplina",MessageBoxButtons.OK);
                return;
            }
            DialogResult opcaoEscolhida = MessageBox.Show($"Deseja Excluir a Disciplina{disciplinaSelecionada}?","Exclusão de Disciplina",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK) 
            {
                repositorioDisciplina.Excluir(disciplinaSelecionada);
                CarregarDisciplina();
            }
        }
    }
}
