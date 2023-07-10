namespace TestesDonaMariana.WinForm.Compartilhado
{
    public abstract class ControladorBase
    {

        public abstract string ToolTipInserir { get; }
        public abstract string ToolTipEditar { get; }
        public abstract string ToolTipExcluir { get; }
        public abstract string ToolTipFiltrar { get; }
        public abstract string ToolTipPdf { get; }
        public abstract string ToolTipGabarito { get; }
        public abstract string ToolTipDuplicar { get; }

        public virtual bool InserirHabilitado { get { return true; } }
        public virtual bool EditarHabilitado { get { return true; } }
        public virtual bool ExcluirHabilitado { get { return true; } }
        public virtual bool VisualizarHabilitado { get { return false; } }
        public virtual bool GerarGabaritoHabilitado { get { return false; } }
        public virtual bool GerarPdfHabilitado { get { return false; } }
        public virtual bool DuplicarHabilitado { get { return false; } }

        public abstract void Inserir();
        public abstract void Editar();
        public abstract void Excluir();
        public virtual void VisualizarTeste() { }
        public virtual void GerarGabarito() { }
        public virtual void GerarPdf() { }
        public abstract UserControl ObterListagem();
        public abstract string ObterTipoCadastro();


    }

}
