using System;
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

        private void buscarConsultasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBuscarConsultas tela = new FormBuscarConsultas();
            tela.ShowDialog();
        }

        private void lista1ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FormFiltroEspecie tela = new FormFiltroEspecie();
            tela.ShowDialog();

        }

        private void faleConoscoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormFaleConosco tela = new FormFaleConosco();
            tela.ShowDialog();
        }

        private void lista2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormFiltroTipoData tela = new FormFiltroTipoData();
            tela.ShowDialog();
        }

        private void filtrarPetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FiltrarPet tela = new FiltrarPet();
            tela.ShowDialog();
        }
    }
}
