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
    public partial class FormBuscarTutor : Form
    {
        RepositorioTutor repositorio;
        Tutor tutor;
        public FormBuscarTutor()
        {
            InitializeComponent();
            repositorio = new RepositorioTutor();
            tutor = null;
        }

        private void btnFiltrarCpf_Click(object sender, EventArgs e)
        {
            try
            {
                Tutor tutor = repositorio.buscarTutor(campoCpf.Text.ToString(), gridTutor);

                // Completa os campos em branco
                campoNome.Text = tutor.getNome();
                campoEmail.Text = tutor.getEmail();
                campoTelefone.Text = tutor.getTelefone();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPesquisarTodos_Click(object sender, EventArgs e)
        {
            chamarGrid();
        }

        private void gridTutor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string nome = gridTutor.CurrentRow.Cells[0].Value.ToString();
            string cpf = gridTutor.CurrentRow.Cells[1].Value.ToString();
            string email = gridTutor.CurrentRow.Cells[2].Value.ToString();
            string telefone = gridTutor.CurrentRow.Cells[3].Value.ToString();

            campoNome.Text = nome;
            campoCpf.Text = cpf;
            campoEmail.Text= email;
            campoTelefone.Text = telefone;

        }


        private void btnAlterar_Click(object sender, EventArgs e)
        {
            // temos que garantir que o cpf não possa ser modificado via código
            string cpf = gridTutor.CurrentRow.Cells[1].Value.ToString();
            if (!campoCpf.Text.Equals(cpf))
            {
                MessageBox.Show("CPF não pode ser alterado !!!");
                return;
            }

            string nome = campoNome.Text.ToString();
            string email = campoEmail.Text.ToString();
            string telefone = campoTelefone.Text.ToString();

            try
            {
                Tutor tutor = new Tutor();
                tutor.setTelefone(telefone);
                tutor.setEmail(email);
                tutor.setCpf(cpf);
                tutor.setNome(nome);

                if (repositorio.alterarTutor(tutor))
                {
                    chamarGrid();
                    MessageBox.Show("Dados Alterados com sucesso !!!");
                }
                else
                {
                    MessageBox.Show("Dados não foram alterados !!!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void chamarGrid()
        {
            try
            {
                repositorio.listarTutores(gridTutor);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            campoCpf.Text = "";
            campoNome.Text = "";
            campoEmail.Text = "";
            campoTelefone.Text = "";
        }
    }

}
