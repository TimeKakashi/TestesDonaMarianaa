using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDonaMariana.Dominio.ModuloDisciplina;
using TestesDonaMariana.Infra.Dados.Sql.ModuloDisciplinaSql;
using TestesDonaMariana.WinForm.ModuloDisciplina;

namespace TestesDonaMariana.WinForm.Compartilhado
{
    public abstract class ControladorBase
    {
        public abstract string ToolTipInserir { get; }
        public abstract string ToolTipEditar { get; }
        public abstract string ToolTipExcluir { get; }

        public virtual bool InserirHabilitado { get { return true; } }
        public virtual bool EditarHabilitado { get { return true; } }
        public virtual bool ExcluirHabilitado { get { return true; } }
        public virtual bool FiltrarHabilitado { get { return false; } }
        public virtual bool GerarGabarito { get { return false; } }
        public virtual bool GerarPdfHabilitado { get { return false; } }

        public abstract void Inserir();
        public abstract void Editar();
        public abstract void Excluir();
        public abstract UserControl ObterListagem();
        public abstract string ObterTipoCadastro();

        public override void Editar(RepositorioDisciplinaSql repositorioDisciplinaSql)
        {
            Disciplina disciplinaSelecionada = ObterDisciplinaSelecionado();

            if (disciplinaSelecionada != null)
            {
                MessageBox.Show("Nenhuma Disciplina Selecionada!", "Editar Disciplina", MessageBoxButtons.OK);
                return;
            }
            TelaDisciplina telaDisciplina = new TelaDisciplina(RepositorioDisciplinaSql);
            telaDisciplina.ConfigurarTela(disciplinaSelecionada);

            DialogResult opcaoEscolhida = telaDisciplina.ShowDialog();

            if (opcaoEscolhida != DialogResult.OK) 
            {
                Disciplina disciplina = telaDisciplina.ObterDisciplina();
                repositorioDisciplinaSql.Editar(disciplina.id, disciplina);

                CarregarDisciplina();
            }
        }

        public override void Inserir(RepositorioDisciplinaSql repositorioDisciplinaSql)
        {
            TelaDisciplina telaDisciplina = new TelaDisciplina();
            bool nomeRepetido = false;

            do 
            {
                if (telaDisciplina.ShowDialog() == DialogResult.OK) 
                {
                    Disciplina disciplina = telaDisciplina.Disciplina;
                    List<Disciplina> listaDisciplina = RepositorioDisciplinaSql.SelecionarTodos();

                    if (listaDisciplina.Any(n => n.nome.ToLower() == disciplina.nome.ToLower())) 
                    {
                        object value = TelaPrincipal.Instancia.AtualizarRodape("Nome já utilizado!");
                        nomeRepetido = true;
                    }
                    else 
                    {
                        repositorioDisciplinaSql.Inserir(disciplina);
                        CarregarDisciplina();
                        nomeRepetido = false;
                    }
                }
                else
                {
                    nomeRepetido = false;
              
                }
            }while (nomeRepetido);
    }

        public override void Excluir(RepositorioDisciplinaSql repositorioDisciplinaSql)
        {
            Disciplina disciplina = ObterDisciplinaSelecionado(RepositorioDisciplinaSql);

            if (disciplina == null) 
            {
                MessageBox.Show($"Selecione uma disciplina primeiro!",
                    "Exclusão de Disciplina",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }
            if (disciplina.contador > 0) 
            {
                TelaPrincipal.Instancia.AtualizarRodape("Esse disciplina foi selecionada não é possivel cadastrar novamente !");
                return;
            }
            DialogResult opcaoEscolhida = MessageBox.Show($"Deseja excluir a disciplina {disciplina.nome}?", "Exclusão de Disciplina",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK) 
            {
                RepositorioDisciplinaSql.Excluir(disciplina);

                CarregarDisciplina();
            }
        }
    }

}
