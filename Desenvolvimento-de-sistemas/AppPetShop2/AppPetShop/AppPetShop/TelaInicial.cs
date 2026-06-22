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

        private void cadastrarPetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCadastrarPet tela = new FormCadastrarPet();
            tela.ShowDialog();
        }

        private void pesquisarPetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBuscarPet tela = new FormBuscarPet();
            tela.ShowDialog();
        }

        private void cadastrarServiçoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCadastrarServico tela = new FormCadastrarServico();
            tela.ShowDialog();
        }

        private void pesquisarServiçoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBuscarServicos tela = new FormBuscarServicos();
            tela.ShowDialog();
        }

        private void cadastrarConsultasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCadastrarConsultas tela = new FormCadastrarConsultas();
            tela.ShowDialog();
        }
    }
}
