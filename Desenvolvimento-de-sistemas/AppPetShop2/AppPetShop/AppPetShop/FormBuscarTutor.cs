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
                Cpf cpf = new Cpf(campoCpf.Text.ToString());
                Tutor tutor = repositorio.buscarTutor(cpf, gridTutor);

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

            try
            {
                Cpf cpfObj = new Cpf(cpf);
                Texto nome = new Texto(campoNome.Text);
                Email email = new Email(campoEmail.Text);
                Telefone telefone = new Telefone(campoTelefone.Text);

                Tutor tutor = new Tutor();
                tutor.setCpf(cpfObj);
                tutor.setNome(nome);
                tutor.setEmail(email);
                tutor.setTelefone(telefone);

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
            repositorio.limparTutor(campoCpf, campoNome, campoEmail, campoTelefone);
        }

        private void btnRemoverTut_Click(object sender, EventArgs e)
        {
            try
            {
                Cpf cpf = new Cpf(campoCpf.Text);
                repositorio.removerTutor(cpf);
                repositorio.listarTutores(gridTutor);
                repositorio.limparTutor(campoCpf, campoNome, campoEmail, campoTelefone);

            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
    }

}
