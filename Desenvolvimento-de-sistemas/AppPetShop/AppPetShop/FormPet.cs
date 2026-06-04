using System;
using System.Windows.Forms;

namespace AppPetShop
{
    public partial class FormPet : Form
    {
        /*
         Usar o modelo de getters e setter do mesmo modo que em formTutor, 
         */
        string nome, cpf, genero, raca, especie, data_nascimento, foto;

        private void FormPet_Load(object sender, EventArgs e)
        {

        }

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

        /*
            Getters e setter abaixo - adicionar metodos de eventos e botoes acima desses comentarios
         */
    }
}
