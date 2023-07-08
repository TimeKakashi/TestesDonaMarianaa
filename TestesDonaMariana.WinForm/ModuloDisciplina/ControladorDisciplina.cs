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
            bool nomeRepetido = false;

            do
            {
                DialogResult opcaoEscolhida = telaDisciplina.ShowDialog();

                if (opcaoEscolhida == DialogResult.OK)
                {
                    Disciplina novaDisciplina = telaDisciplina.ObterDisciplina();

                    List<Disciplina> listaDisciplinas = repositorioDisciplina.SelecionarTodos();
                    if (listaDisciplinas.Any(x => x.nome.ToLower() == novaDisciplina.nome.ToLower()))
                    {
                        // Nome repetido, exibir mensagem de erro e continuar na tela de cadastro
                        TelaPrincipal.Instancia.AtualizarRodape("O nome da disciplina já existe. Por favor, insira um nome diferente.");
                        nomeRepetido = true;
                    }
                    else
                    {
                        repositorioDisciplina.Inserir(novaDisciplina);
                        CarregarDisciplina();
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

            bool nomeRepetido = false;

            do
            {
                DialogResult opcaoEscolhida = telaDisciplina.ShowDialog();

                if (opcaoEscolhida == DialogResult.OK)
                {
                    Disciplina novaDisciplina = telaDisciplina.ObterDisciplina();
                    novaDisciplina.id = disciplinaSelecionada.id;

                    List<Disciplina> listaDisciplinas = repositorioDisciplina.SelecionarTodos();
                    if (listaDisciplinas.Any(x => x.nome.ToLower() == novaDisciplina.nome.ToLower() && x.id != novaDisciplina.id))
                    {
                        // Nome repetido, exibir mensagem de erro e continuar na tela de edição
                        TelaPrincipal.Instancia.AtualizarRodape("O nome da disciplina já existe. Por favor, insira um nome diferente.");
                        nomeRepetido = true;
                    }
                    else
                    {
                        repositorioDisciplina.Editar(novaDisciplina.id, novaDisciplina);
                        CarregarDisciplina();
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
        }


        public override void Excluir()
        {
            Disciplina disciplinaSelecionada = ObterDisciplinaSelecionado();

            if (disciplinaSelecionada == null) 
            {
                MessageBox.Show("Nenhuma Disciplina Selecionada","Excluir Disciplina",MessageBoxButtons.OK);
                return;
            }

            else if (repositorioDisciplina.VerificarTestesNaDisciplina(disciplinaSelecionada).Count > 0)
            {
                MessageBox.Show("A Disciplina Selecionada contem um teste cadastrado!", "Excluir Disciplina", MessageBoxButtons.OK);
                return;
            }

            else if(repositorioDisciplina.VerificarMateriasNaDisciplina(disciplinaSelecionada).Count > 0)
            {
                MessageBox.Show("A Disciplina Selecionada contem uma materia cadastrada!", "Excluir Disciplina", MessageBoxButtons.OK);
                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show($"Deseja Excluir a Disciplina {disciplinaSelecionada}?","Exclusão de Disciplina",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK) 
            {
                repositorioDisciplina.Excluir(disciplinaSelecionada);
                CarregarDisciplina();
            }
        }
    }
}
