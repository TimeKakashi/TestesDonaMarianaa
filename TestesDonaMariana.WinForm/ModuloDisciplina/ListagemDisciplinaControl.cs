using FestasInfantis.WinApp.Compartilhado;
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
using TestesDonaMariana.Dominio.ModuloQuestoes;

namespace TestesDonaMariana.WinForm.ModuloDisciplina
{
    public partial class ListagemDisciplinaControl : UserControl
    {
        public ListagemDisciplinaControl()
        {
            InitializeComponent();
            ConfigurarColunas();
            ConfiguracaoGrid.ConfigurarGridSomenteLeitura(grid);
            ConfiguracaoGrid.ConfigurarGridZebrado(grid);
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
                }
            };

            grid.Columns.AddRange(colunas);
        }
        public void AtualizarRegistros(List<Disciplina> listaDisciplina)
        {
            grid.Rows.Clear();

            foreach (Disciplina item in listaDisciplina)
                grid.Rows.Add(item.id,
                            item.nome);
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
