using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppPetShop
{
    public partial class TelaInicial : Form
    {
        public TelaInicial()
        {
            InitializeComponent();
        }

        private void cadastrarTutorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCadastrarTutor tela = new FormCadastrarTutor();
            tela.ShowDialog();
            
        }

        private void pesquisarTutorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBuscarTutor tela = new FormBuscarTutor();
            tela.ShowDialog();
        }

        private void fecharApp(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
