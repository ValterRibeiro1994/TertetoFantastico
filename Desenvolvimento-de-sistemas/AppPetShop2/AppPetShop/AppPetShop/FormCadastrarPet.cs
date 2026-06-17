using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AppPetShop
{
    public partial class FormCadastrarPet : Form
    {
        public FormCadastrarPet()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                string codigo = inputCodigo.Text;
                Cpf cpf = new Cpf(inputCpf.Text);
                char genero = obterGenero();
                Nome raca = new Nome(inputRaca.Text, limite_max: 30);
                byte[] foto = obterFoto();
                Nome nome_pet = new Nome(inputNome.Text, limite_max: 30);
                Nome especie = new Nome(inputRaca.Text, limite_max: 30);

                Pet pet = new Pet();
                pet.setCodigo(codigo);
                pet.setCpfTutor(cpf);
                pet.setNascimento(inputNascimento.Value);
                pet.setGenero(genero);
                pet.setRaca(raca);
                pet.setFoto(foto);
                pet.setNomePet(nome_pet);
                pet.setEspecie(especie);


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
