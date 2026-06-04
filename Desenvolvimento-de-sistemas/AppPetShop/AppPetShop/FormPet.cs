using System;
using System.Windows.Forms;

namespace AppPetShop
{
    public partial class FormPet : Form
    {
        /*
         Usar o modelo de getters e setter do mesmo modo que em formTutor, 
         */
        string nome, cpf, genero, raca, especie, data_nascimento;

        public FormPet()
        {
            InitializeComponent();
        }

        private void fecharApp(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
