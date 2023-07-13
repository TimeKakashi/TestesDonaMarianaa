using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDonaMariana.Aplicacao.Compartilhado;
using TestesDonaMariana.Dominio.Compartilhado;
using TestesDonaMariana.Dominio.ModuloDisciplina;

namespace TestesDonaMariana.Aplicacao.ModuloQuestao
{
    public class ServicoDisciplina : ServicoBase<Disciplina>
    {
        private IRepositorioDisciplina repositorioDisciplina;

        public ServicoDisciplina(IRepositorioDisciplina repositorioDisciplina)
        {
            this.repositorioDisciplina = repositorioDisciplina;
        }

        public override IRepositorioBase<Disciplina> repositorio => repositorioDisciplina;

        public override List<string> ValidarEntidade(Disciplina item)
        {
            List<string> erros = new List<string>(item.Validar());

            if (repositorioDisciplina.SelecionarTodos().Any(q => q.nome == item.nome && q.id != item.id))
                erros.Add($"Este nome '{item.nome}' já está sendo utilizado na aplicação");

            return erros;
        }
    }
}
