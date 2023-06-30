using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDonaMariana.Dominio.ModuloGabarito;
using TestesDonaMariana.Dominio.ModuloTeste;
using TestesDonaMariana.WinForm.Compartilhado;

namespace TestesDonaMariana.WinForm.ModuloTeste
{
    public class ControladorTeste : ControladorBase
    {
        private ListagemTesteControl listagemTeste;
        private IRepositorioTeste repositorioTeste;
        private IRepositorioGabarito repositorioGabarito;

        public ControladorTeste(IRepositorioTeste repositorioTeste, IRepositorioGabarito repositorioGabarito)
        {
            this.repositorioTeste = repositorioTeste;
            this.repositorioGabarito = repositorioGabarito;
        }

        public override string ToolTipInserir => "Cadastrar Teste";

        public override string ToolTipEditar => "Cadastrar Teste";

        public override string ToolTipExcluir => "Excluir Teste";

        public override bool FiltrarHabilitado => true;

        public override bool GerarGabarito => true;

        public override bool GerarPdfHabilitado => true;

        public override void Editar()
        {
            throw new NotImplementedException();
        }

        public override void Excluir()
        {
            throw new NotImplementedException();
        }

        public override void Inserir()
        {
            throw new NotImplementedException();
        }

        public override UserControl ObterListagem()
        {
            if(listagemTeste == null)
                listagemTeste = new ListagemTesteControl();

            return listagemTeste;
        }

        public override string ObterTipoCadastro()
        {
            throw new NotImplementedException();
        }
    }
}
