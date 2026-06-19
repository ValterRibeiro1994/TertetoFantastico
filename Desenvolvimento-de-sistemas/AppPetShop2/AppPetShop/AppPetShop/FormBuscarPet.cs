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
            using (MemoryStream ms = new MemoryStream(pet.getFoto()))
            {
                Image img_pet = Image.FromStream(ms);

                campoImagem.Image = img_pet;
            }
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
            byte[] blob_pet = (byte[])gridPet.CurrentRow.Cells[7].Value;

            using (MemoryStream ms = new MemoryStream(blob_pet))
            {
                Image img_pet = Image.FromStream(ms);

                campoImagem.Image = img_pet;
            }
        }

        private void btnRemoverPet_Click(object sender, EventArgs e)
        {
            try
            {
                CodigoBanco codigo = new CodigoBanco(campoCodigo.Text);
                repositorio.removerPet(codigo);
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
    }
}}
