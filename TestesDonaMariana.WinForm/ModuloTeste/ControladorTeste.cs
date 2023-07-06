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

        public override string ToolTipEditar => "Cadastrar Teste";

        public override string ToolTipExcluir => "Excluir Teste";

        public override bool FiltrarHabilitado => true;

        public override bool GerarGabaritoHabilitado => true;

        public override bool GerarPdfHabilitado => true;

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
            Teste teste = ObterTesteSelecionado();
        }
        public override void Excluir()
        {
            throw new NotImplementedException();
        }

        private void CarregarTestes()
        {
            List<Teste> testes = repositorioTeste.SelecionarTodos();

            listagemTeste.AtualizarRegistros(testes);
        }

        private Teste ObterTesteSelecionado()
        {
            int id = listagemTeste.ObterIdSelecionado();

            return repositorioTeste.SelecionarPorId(id);
        }


       
        public override UserControl ObterListagem()
        {
            if(listagemTeste == null)
                listagemTeste = new ListagemTesteControl();

            return listagemTeste;
        }

        public override string ObterTipoCadastro() => "Cadastro de Testes";
        
    }
}
