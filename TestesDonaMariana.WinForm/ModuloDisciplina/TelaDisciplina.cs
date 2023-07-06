using Microsoft.Identity.Client;
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
    
    public partial class TelaDisciplina : Form
    {
        private IRepositorioDisciplina repositorioDisciplina;
        public TelaDisciplina()
        {
            InitializeComponent();
        }
        public TelaDisciplina(IRepositorioDisciplina repositorioDisciplina)
        {

            InitializeComponent();
            this.repositorioDisciplina = repositorioDisciplina;
        }

        private Disciplina disciplina;

        

        public  void ConfigurarTela(Disciplina? disciplinaSelecionada)
        {
            tbNome.Text = disciplinaSelecionada.id.ToString();
            tbListaDeMateria.Text = disciplinaSelecionada.nome;
        }

        public Disciplina ObterDisciplina()
        {
            string nome = tbNome.Text;
            
            return  new Disciplina(nome);
        }

    }
}
