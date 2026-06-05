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
        Utilidades utils;

        /*
         Construtor
         */
        public FormPet()
        {
            InitializeComponent();
            utils = new Utilidades();
        }

        /*
         Menu Strip - funções
         */
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

        
        /*
         Eventos de formulario
         */
        private void FormPet_Load(object sender, EventArgs e)
        {

        }

        private void fecharApp(object sender, FormClosingEventArgs e)
        {
            if (!abrir_form)
            {
                Application.Exit();
            }
        }

        /*
         Botões de formulario
         */
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

        private void btnCadastrarPet_Click(object sender, EventArgs e)
        {
            //
        }

        /*
            Getters e setter abaixo - adicionar metodos de eventos e botoes acima desses comentarios
         */

        private void setNascimento(string data)
        {

        }

        private void setCpf(string cpf)
        {
            if (utils.campoVazio(cpf))
            {
                throw new Exception("Cpf deve ser preenchido !!!");
            } else if (utils.totalCaracteres(11, cpf))
            {
                throw new Exception("Cpf deve ter 11 caracteres");
            } else
            {
                this.cpf = cpf;
            }
        }

        private void setNomePet(string nomePet)
        {
            if (utils.campoVazio(nomePet)){
                throw new Exception("Nome do pet deve ser informado");
            } else if (utils.limiteTexto(30, nomePet)){
                throw new Exception("Limite de caracteres excedido para nome do Pet");
            } else
            {
                this.nome = nomePet;
            }
        }

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
