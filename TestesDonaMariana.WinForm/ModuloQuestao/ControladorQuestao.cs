using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDonaMariana.Dominio.ModuloQuestoes;
using TestesDonaMariana.WinForm.Compartilhado;

namespace TestesDonaMariana.WinForm.ModuloQuestao
{
    public class ControladorQuestao : ControladorBase
    {
        private ListagemQuestaoControl listagemQuestao;
        private IRepositorioQuestoes repositorioQuestao;

        public ControladorQuestao(IRepositorioQuestoes repositorioQuestao)
        {
            this.repositorioQuestao = repositorioQuestao;
        }

        public override string ToolTipInserir => "Cadastrar Questao";

        public override string ToolTipEditar => "Editar Questao";

        public override string ToolTipExcluir => "Excluir Questao";
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
            if (listagemQuestao == null)
                listagemQuestao = new ListagemQuestaoControl();

            return listagemQuestao;
        }

        public override string ObterTipoCadastro()
        {
            throw new NotImplementedException();
        }
    }
}
