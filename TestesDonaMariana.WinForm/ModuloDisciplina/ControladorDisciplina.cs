using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDonaMariana.Dominio.ModuloDisciplina;
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
            if (listagemDisciplina == null)
                listagemDisciplina = new ListagemDisciplinaControl();

            return listagemDisciplina;
        }

        public override string ObterTipoCadastro()
        {
            throw new NotImplementedException();
        }
    }
}
