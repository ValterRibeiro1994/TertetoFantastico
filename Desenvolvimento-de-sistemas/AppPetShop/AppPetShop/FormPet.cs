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
        bool abrir_form = false;

        private void petToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrir_form = true;
            this.Close();

            FormPet tela = new FormPet();
            tela.Show();
        }


        private void tutorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrir_form = true;
            this.Close();

            FormTutor tela = new FormTutor();
            tela.Show();
            
        }

        

        private void FormPet_Load(object sender, EventArgs e)
        {

        }

        public FormPet()
        {
            InitializeComponent();
        }

        private void fecharApp(object sender, FormClosingEventArgs e)
        {
            if (!abrir_form)
            {
                Application.Exit();
            }
        }

        private void btnFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog cxFoto = new OpenFileDialog();
            cxFoto.Title = "Selecione Imagem";
            cxFoto.Filter = "Imagens|*.jpg;*.jpeg;*.png;*.gif";
            if (cxFoto.ShowDialog() == DialogResult.OK)
            {
                inputFoto.ImageLocation = cxFoto.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        /*
            Getters e setter abaixo - adicionar metodos de eventos e botoes acima desses comentarios
         */

        private string getCpf()
        {
            return cpf;
        }

        private string getNome()
        {
            return nome;
        }

        private string getNascimento()
        {
            return data_nascimento;
        }

        private string getRaca()
        {
            return raca;
        }

        private string getEspecie()
        {
            return especie;
        }

        private string getGenero()
        {
            return genero;
        }
    }
}
