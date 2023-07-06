using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestesDonaMariana.Dominio.ModuloMateria;

namespace TestesDonaMariana.WinForm.ModuloMateria
{
    public partial class ListagemMateriaControl : UserControl
    {
        public ListagemMateriaControl()
        {
            InitializeComponent();
        }
        private void ConfigurarColunas()
        {
            DataGridViewColumn[] colunas = new DataGridViewColumn[]
            {
        new DataGridViewTextBoxColumn()
        {
            Name = "id",
            HeaderText = "Id"
        },
        new DataGridViewTextBoxColumn()
        {
            Name = "nome",
            HeaderText = "Nome"
        },
        new DataGridViewTextBoxColumn()
        {
            Name = "disciplina",
            HeaderText = "Disciplina"
        },
        new DataGridViewTextBoxColumn()
        {
            Name = "serie",
            HeaderText = "Série"
        }
            };

            grid.Columns.AddRange(colunas);
        }

        public void AtualizarRegistros(List<Materia> listaMaterias)
        {
            grid.Rows.Clear();

            foreach (Materia materia in listaMaterias)
            {
                grid.Rows.Add(materia.id,
                              materia.nome,
                              materia.disciplina,
                              materia.serie
                              );
            }
        }
        public int ObterIdSelecionado()
        {
            if (grid.SelectedRows.Count == 0)
                return -1;

            int id = Convert.ToInt32(grid.SelectedRows[0].Cells["id"].Value);

            return id;
        }

    }
}
