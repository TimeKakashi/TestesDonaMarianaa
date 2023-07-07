using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDonaMariana.WinForm.Compartilhado;

namespace TestesDonaMariana.WinForm.ModuloGabarito
{
    public class ControladorGabarito : ControladorBase
    {
        private ListagemGabaritoControl listagemGabarito;

        public override string ToolTipInserir => "Cadastrar Gabarito";

        public override string ToolTipEditar => "Este botão está desabilitado nessa tela";

        public override string ToolTipExcluir => "Excluir Gabarito";
        public override string ToolTipFiltrar => "Filtrar Gabaritos";

        public override string ToolTipPdf => "Este botão está desabilitado nessa tela";

        public override string ToolTipGabarito => "Este botão está desabilitado nessa tela";

        public override string ToolTipDuplicar => "Este botão está desabilitado nessa tela";

        public override bool EditarHabilitado => false;

        public override bool FiltrarHabilitado => true;

        public override bool DuplicarHabilitado => false;

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
            if (listagemGabarito == null)
                listagemGabarito = new ListagemGabaritoControl();

            return listagemGabarito;
        }

        public override string ObterTipoCadastro()
        {
            throw new NotImplementedException();
        }
    }
}
