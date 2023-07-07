using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDonaMariana.Dominio.ModuloDisciplina;
using TestesDonaMariana.Dominio.ModuloGabarito;
using TestesDonaMariana.Dominio.ModuloMateria;
using TestesDonaMariana.Dominio.ModuloQuestoes;
using TestesDonaMariana.Dominio.ModuloTeste;
using TestesDonaMariana.WinForm.Compartilhado;

namespace TestesDonaMariana.WinForm.ModuloTeste
{
    public class ControladorTeste : ControladorBase
    {
        private ListagemTesteControl listagemTeste;
        private IRepositorioTeste repositorioTeste;
        private IRepositorioGabarito repositorioGabarito;
        private IRepositorioDisciplina repositorioDisciplina;
        private IRepositorioMateria repositorioMateria;
        private IRepositorioQuestoes repositorioQuestoes;

        public ControladorTeste(IRepositorioTeste repositorioTeste, IRepositorioGabarito repositorioGabarito, IRepositorioDisciplina repositorioDisciplina, IRepositorioMateria repositorioMateria, IRepositorioQuestoes repositorioQuestoes)
        {
            this.repositorioTeste = repositorioTeste;
            this.repositorioGabarito = repositorioGabarito;
            this.repositorioMateria = repositorioMateria;
            this.repositorioDisciplina = repositorioDisciplina;
            this.repositorioQuestoes = repositorioQuestoes;

            CarregarTestes();
        }

        public override string ToolTipInserir => "Cadastrar Teste";

        public override string ToolTipEditar => "Este botão está desabilitado nessa Tela";

        public override string ToolTipExcluir => "Excluir Teste";
        public override string ToolTipFiltrar => "Filtrar Testes";

        public override string ToolTipPdf => "Gerar PDF";

        public override string ToolTipGabarito => "Gerar Gabarito";

        public override string ToolTipDuplicar => "Duplicar Teste";

        public override bool FiltrarHabilitado => true;

        public override bool GerarGabaritoHabilitado => true;

        public override bool GerarPdfHabilitado => true;

        public override bool EditarHabilitado => false;
        public override bool DuplicarHabilitado => true;

        

        public override void Inserir()
        {
            TelaTeste telaTeste = new TelaTeste(repositorioDisciplina, repositorioMateria, repositorioQuestoes);

            DialogResult resultado = telaTeste.ShowDialog();

            if(resultado == DialogResult.OK)
            {
                Teste teste = telaTeste.ObterTeste();

                repositorioTeste.Inserir(teste, teste.questoes);
            }
            CarregarTestes();
        }

        public override void Editar()
        {
            //Não é usado
        }
        public override void Excluir()
        {
            Teste testeSelecionado = ObterTesteSelecionado();

            if (testeSelecionado == null)
            {
                MessageBox.Show("Nenhum Teste Selecionado", "Excluir Teste", MessageBoxButtons.OK);
                return;
            }
            DialogResult opcaoEscolhida = MessageBox.Show($"Deseja Excluir o Teste?", "Exclusão de Disciplina", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                repositorioTeste.Excluir(testeSelecionado);
                CarregarTestes();
            }
        }

        private void CarregarTestes()
        {
            List<Teste> testes = repositorioTeste.SelecionarTodos();

            if (listagemTeste == null)
                listagemTeste = new ListagemTesteControl();

            listagemTeste.AtualizarRegistros(testes);
        }

        private Teste ObterTesteSelecionado()
        {
            int id = listagemTeste.ObterIdSelecionado();

            Teste teste =  repositorioTeste.SelecionarPorId(id);

            List<Questao> questoes = repositorioTeste.SelecionarQuestoes(teste);

            teste.questoes = questoes;

            return teste;
        }



        public override UserControl ObterListagem()
        {
            if (listagemTeste == null)
                listagemTeste = new ListagemTesteControl();

            return listagemTeste;
        }
        public void DuplicarTeste()
        {
            Teste testeSelecionado = ObterTesteSelecionado();

            if (testeSelecionado != null)
            {
                Teste testeDuplicado = testeSelecionado.Clone() as Teste;

                if (testeDuplicado != null)
                {
                    // Define um novo ID para o teste duplicado
                    testeDuplicado.id = ObterNovoId();

                    // Cria uma nova lista de questões duplicadas
                    List<Questao> questoesDuplicadas = new List<Questao>();
                    foreach (Questao questao in testeSelecionado.questoes)
                    {
                        Questao questaoDuplicada = questao.Clone() as Questao;
                        questoesDuplicadas.Add(questaoDuplicada);
                    }
                    testeDuplicado.questoes = questoesDuplicadas;

                    // Inserir o teste duplicado no repositório
                    repositorioTeste.Inserir(testeDuplicado, questoesDuplicadas);

                    // Recarregar a lista de testes
                    CarregarTestes();
                }
            }
        }


        private int ObterNovoId()
            {
                // Lógica para obter um novo ID para o teste duplicado
                // Pode ser obtido do repositório ou de outra fonte de dados
                // Neste exemplo, estou apenas retornando um valor fixo
                return repositorioTeste.SelecionarTodos().Count + 1;
            }


        public override string ObterTipoCadastro() => "Cadastro de Testes";
        
    }
}
