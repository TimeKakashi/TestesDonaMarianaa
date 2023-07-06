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
using TestesDonaMariana.Dominio.ModuloMateria;
using TestesDonaMariana.Dominio.ModuloTeste;

namespace TestesDonaMariana.WinForm.ModuloTeste
{
    public partial class ListagemTesteControl : UserControl
    {
        public ListagemTesteControl()
        {
            InitializeComponent();
            ConfigurarColunas();
            ConfiguracaoGrid.ConfigurarGridZebrado(grid);
            ConfiguracaoGrid.ConfigurarGridSomenteLeitura(grid);
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
            Name = "nomeMateria",
            HeaderText = "Materia"
        },
        new DataGridViewTextBoxColumn()
        {
            Name = "nomeDisciplina",
            HeaderText = "Disciplina"
        },
        new DataGridViewTextBoxColumn()
        {
            Name = "serie",
            HeaderText = "Série"
        },
        new DataGridViewTextBoxColumn()
        {
            Name = "dataCriacao",
            HeaderText = "Data Criacao"
        }
            };

            grid.Columns.AddRange(colunas);
        }

        public void AtualizarRegistros(List<Teste> testes)
        {
            grid.Rows.Clear();

            foreach (Teste teste in testes)
            {
                grid.Rows.Add(teste.id, teste.materia.nome, teste.disciplina.nome, teste.serie, teste.dataCriacao);
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
