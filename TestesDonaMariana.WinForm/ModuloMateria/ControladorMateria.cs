using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDonaMariana.Dominio.ModuloMateria;
using TestesDonaMariana.WinForm.Compartilhado;
using TestesDonaMariana.WinForm.ModuloGabarito;

namespace TestesDonaMariana.WinForm.ModuloMateria
{
    public class ControladorMateria : ControladorBase
    {

        private ListagemMateriaControl listagemMateria;
        private IRepositorioMateria repositorioMateria;

        public ControladorMateria(IRepositorioMateria repositorioMateria)
        {
            this.repositorioMateria = repositorioMateria;
        }

        public override string ToolTipInserir => "Cadastrar Materia";

        public override string ToolTipEditar => "Editar Materia";

        public override string ToolTipExcluir => "Excluir Materia";

        public override bool FiltrarHabilitado => true;
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
            if (listagemMateria == null)
                listagemMateria = new ListagemMateriaControl();

            return listagemMateria;
        }

        public override string ObterTipoCadastro()
        {
            throw new NotImplementedException();
        }
    }
}
