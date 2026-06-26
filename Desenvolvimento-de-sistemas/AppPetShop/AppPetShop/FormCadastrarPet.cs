using System;
using System.IO;
using System.Windows.Forms;

namespace AppPetShop
{
    public partial class FormCadastrarPet : Form
    {
        RepositorioPet repositorio;

        public FormCadastrarPet()
        {
            InitializeComponent();
            repositorio = new RepositorioPet();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                Cpf cpf = new Cpf(inputCpf.Text);
                char genero = obterGenero();
                Texto raca = new Texto(inputRaca.Text, limite_max: 30);
                byte[] foto = obterFoto();
                Texto nome_pet = new Texto(inputNome.Text, limite_max: 30);
                Texto especie = new Texto(inputEspecie.Text, limite_max: 30);

                Pet pet = new Pet();
                pet.setCpfTutor(cpf);
                pet.setNascimento(inputNascimento.Value);
                pet.setGenero(genero);
                pet.setRaca(raca);
                pet.setFoto(foto);
                pet.setNomePet(nome_pet);
                pet.setEspecie(especie);

                if (repositorio.cadastrarPet(pet))
                {
                    MessageBox.Show("Pet cadastrado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private char obterGenero()
        {
            if (rbFemea.Checked)
            {
                return 'F';
            }
            else if (rbMacho.Checked)
            {
                return 'M';
            }
            else
            {
                throw new Exception("Gênero obrigatorio para Pet");
            }
        }

        private byte[] obterFoto()
        {
            if (String.IsNullOrEmpty(fotoPet.ImageLocation))
            {
                throw new Exception("Imagem obrigatoria para Pet !!!");
            }

            try
            {
                byte[] foto = File.ReadAllBytes(fotoPet.ImageLocation);
                return foto;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO FOTO: " + ex.Message);

            }
            return null;
        }

        private void btnFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog cxFoto = new OpenFileDialog();
            cxFoto.Title = "Selecione Imagem";
            cxFoto.Filter = "Imagens|*.jpg;*.jpeg;*.png;*.gif";
            if (cxFoto.ShowDialog() == DialogResult.OK)
            {
                fotoPet.ImageLocation = cxFoto.FileName;
            }
        }
    }
}
