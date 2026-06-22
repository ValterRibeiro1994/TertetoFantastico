using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppPetShop
{
    public partial class FormBuscarPet : Form
    {
        RepositorioPet repositorio;
        byte[] fotoPet;
        public FormBuscarPet()
        {
            InitializeComponent();
            repositorio = new RepositorioPet();
        }
        

        private void btnBuscarPedCod_Click(object sender, EventArgs e)
        {
            try
            {
                CodigoBanco codigo_pet = new CodigoBanco(campoCodigo.Text);
                Pet pet = repositorio.buscarPetCodigo(codigo_pet);
                if (pet == null)
                {
                    MessageBox.Show("Pet não Localizado");
                    return;
                }
                MessageBox.Show("Pet Localizado");
                enviarDados(pet);

                
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
    }

        private void btnBuscarCpf_Click(object sender, EventArgs e)
        {
            try
            {
                Cpf cpf = new Cpf(campoCpf.Text);
                repositorio.buscarPetCpf(cpf, gridPet);
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void enviarDados(Pet pet) {
            campoCodigo.Text = pet.getCodigo().ToString();
            campoCpf.Text = pet.getCpf();
            campoData.Value = pet.getNascimento();
            campoEspecie.Text = pet.getEspecie();
            campoNome.Text = pet.getNome();
            campoRaca.Text = pet.getRaca();
            char genero = pet.getGenero();
            if (genero.Equals('F'))
            {
                rbFemea.Checked = true;
            } else
            {
                rbMacho.Checked = true;
            }
            exibirFoto(pet.getFoto());
        }

        private void btnListarPet_Click(object sender, EventArgs e)
        {
            try
            {
                repositorio.listarPet(gridPet);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void selecionarPet(object sender, DataGridViewCellEventArgs e)
        {
            campoCodigo.Text = gridPet.CurrentRow.Cells[0].Value.ToString();
            campoCpf.Text = gridPet.CurrentRow.Cells[1].Value.ToString();
            campoEspecie.Text = gridPet.CurrentRow.Cells[6].Value.ToString();
            campoRaca.Text = gridPet.CurrentRow.Cells[4].Value.ToString();
            campoNome.Text = gridPet.CurrentRow.Cells[5].Value.ToString();
            campoData.Text = gridPet.CurrentRow.Cells[2].Value.ToString();
            string genero = gridPet.CurrentRow.Cells[3].Value.ToString();
            if (genero.Equals("F"))
            {
                rbFemea.Checked = true;
            } else if (genero.Equals("M"))
            {
                rbMacho.Checked = true;
            } else
            {
                rbMacho.Checked = false;
                rbFemea.Checked = false;
            }

            try
            {
                byte[] blob_pet = (byte[])gridPet.CurrentRow.Cells[7].Value;
                exibirFoto(blob_pet);
                fotoPet = blob_pet;

            } catch (Exception ex) {
                MessageBox.Show("Pet Selecionado não tem Foto, Tire uma foto do Pet e adicione ao banco");
                campoImagem.Image = null;
                fotoPet = null;
            }
        }

        private void btnRemoverPet_Click(object sender, EventArgs e)
        {
            try
            {
                CodigoBanco codigo = new CodigoBanco(campoCodigo.Text);
                repositorio.removerPet(codigo);
                campoImagem.Image = null;
                repositorio.listarPet(gridPet);
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void exibirFoto(byte[] foto)
        {
            using (MemoryStream ms = new MemoryStream(foto))
            {
                Image img_pet = Image.FromStream(ms);

                campoImagem.Image = img_pet;
            }
        }

        private Pet criarPet()
        {
            char genero;

            if (rbFemea.Checked == false && rbMacho.Checked == false)
            {
                MessageBox.Show("Marque o genero do pet !!!");
                return null;
            }

            if (rbFemea.Checked)
            {
                genero = 'F';
            }
            else
            {
                genero = 'M';
            }

            try
            {

                CodigoBanco codigo = new CodigoBanco(campoCodigo.Text);
                Cpf cpf = new Cpf(campoCpf.Text);
                Texto nome = new Texto(campoNome.Text, limite_max: 30);
                Texto especie = new Texto(campoEspecie.Text, limite_max: 30);
                Texto raca = new Texto(campoRaca.Text, limite_max: 30);
               
                Pet pet = new Pet();
                pet.setFoto(fotoPet);
                pet.setNascimento(campoData.Value);
                pet.setGenero(genero);
                pet.setEspecie(especie);
                pet.setRaca(raca);
                pet.setNomePet(nome);
                pet.setCpfTutor(cpf);
                pet.setCodigo(codigo);
                return pet;
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

}

        private void btnEditarPet_Click(object sender, EventArgs e)
        {
            try
            {
                Pet pet = criarPet();
                if (pet == null)
                {
                    return;
                }
                if (repositorio.editarPet(pet))
                {
                    repositorio.listarPet(gridPet);
                    MessageBox.Show("Pet editado com sucesso !!");
                }
                else
                {
                    MessageBox.Show("Erro ao editar Pet");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAlterarFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog cxDialogo = new OpenFileDialog();

            cxDialogo.Title = "Selecione imagem";
            cxDialogo.Filter = "Imagens|*.jpg;*.jpeg;*.png;*.gif";


            if (cxDialogo.ShowDialog() == DialogResult.OK)
            {
                campoImagem.ImageLocation = cxDialogo.FileName;
                fotoPet = File.ReadAllBytes(campoImagem.ImageLocation);
            }
        }
    }
}
