using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestesDonaMariana.Dominio.ModuloDisciplina;

namespace TestesDonaMariana.WinForm.ModuloDisciplina
{
    public partial class ListagemDisciplinaControl : UserControl
    {
        public ListagemDisciplinaControl()
        {
            InitializeComponent();
        }

        internal void AtualizarRegistros(List<Disciplina> disciplinas)
        {
            throw new NotImplementedException();
        }

        internal int ObterIdSelecionado()
        {
            throw new NotImplementedException();
        }
    }
}
