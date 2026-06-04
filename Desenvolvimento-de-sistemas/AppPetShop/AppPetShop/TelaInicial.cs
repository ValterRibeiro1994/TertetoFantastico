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

        private void tutorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTutor tela = new FormTutor();
            tela.Show();
            this.Hide();
        }

        private void petToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPet tela = new FormPet();
            tela.Show();
            this.Hide();
        }

        private void fecharApp_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
