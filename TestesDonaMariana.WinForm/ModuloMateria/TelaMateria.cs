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
    public partial class TelaMateria : Form
    {
        public TelaMateria()
        {
            InitializeComponent();
        }
        private Materia materia;

        public Materia Materia
        {
            set
            {
                textBox1.Text = value.nome;
                
            }
            get
            {
                return materia;
            }
        }
    }
}
