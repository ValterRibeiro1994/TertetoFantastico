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
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnPesquisarTodos_Click(object sender, EventArgs e)
        {
            try
            {
                repositorio.listarTutores(gridTutor);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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
    
        
    }
}
