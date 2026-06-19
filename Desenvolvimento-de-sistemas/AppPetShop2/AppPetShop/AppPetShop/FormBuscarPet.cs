using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        }
}}
