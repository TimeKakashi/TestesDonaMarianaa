using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDonaMariana.Dominio.ModuloMateria;
using TestesDonaMariana.Infra.Dados.Sql.ModuloMateriaSql;
using TestesDonaMariana.WinForm.Compartilhado;
using TestesDonaMariana.WinForm.ModuloGabarito;

namespace TestesDonaMariana.WinForm.ModuloMateria
{
    public class ControladorMateria : ControladorBase
    {

        private ListagemMateriaControl listagemMateria;
        private IRepositorioMateria repositorioMateria;
        private RepositorioMateriaSql repositorioMateriaSql;

        public ControladorMateria(IRepositorioMateria repositorioMateria, RepositorioMateriaSql repositorioMateriaSql)
        {
            this.repositorioMateria = repositorioMateria;
            this.repositorioMateriaSql = repositorioMateriaSql;
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
            TelaMateria telaMateria = new TelaMateria();
            if (telaMateria.ShowDialog() == DialogResult.OK)
            {
                List<Materia> listaMateria = repositorioMateriaSql.SelecionarTodos();

                Materia materia = telaMateria.Materia;

                if (listaMateria.Any(x => x.nome.ToLower() == materia.nome.ToLower()))
                {
                    TelaPrincipal.Instancia.AtualizarRodape("Nao é possivel cadastrar uma matéria com o mesmo nome de outra matéria!");
                    return;
                }

                repositorioMateriaSql.Inserir(materia);

                
            }
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
