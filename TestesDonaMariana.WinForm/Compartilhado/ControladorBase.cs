using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }

}
