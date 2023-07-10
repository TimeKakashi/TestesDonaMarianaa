using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestesDonaMariana.Dominio.ModuloQuestoes;
using TestesDonaMariana.Dominio.ModuloTeste;

namespace TestesDonaMariana.WinForm.ModuloTeste
{
    public partial class TelaVisualizarTeste : Form
    {
        public TelaVisualizarTeste()
        {
            InitializeComponent();
        }

        public void SetarValores(Teste TesteSelecionado)
        {
            lBdisciplina.Text = TesteSelecionado.disciplina.nome;

            if (TesteSelecionado.recuperacao)
                lBmateria.Text = "Esta em Prova de Recuperação";
            else
                lBmateria.Text = TesteSelecionado.materia.nome;

            lBtitulo.Text = TesteSelecionado.titulo;

            foreach (Questao questao in TesteSelecionado.questoes)
            {
                lBquestoes.Items.Add(questao);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
