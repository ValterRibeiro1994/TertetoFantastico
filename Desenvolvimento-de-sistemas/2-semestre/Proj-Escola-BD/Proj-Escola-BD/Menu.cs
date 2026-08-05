using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proj_Escola_BD
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
         

        }

        private void alunosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAlunos Alunos = new frmAlunos();
            Alunos.ShowDialog();
        }

        private void mensalidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMensalidade Mensalidade = new frmMensalidade();
            Mensalidade.ShowDialog();
        }

        private void listagensToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //listagem Lista = new listagem();
            ListarAlunos Lista = new ListarAlunos();
            Lista.ShowDialog();
        }
    }
}
