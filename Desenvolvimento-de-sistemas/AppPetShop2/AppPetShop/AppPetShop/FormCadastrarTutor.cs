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
    public partial class FormCadastrarTutor : Form
    {
        Tutor tutor;
        RepositorioTutor repositorio;
        public FormCadastrarTutor()
        {
            InitializeComponent();
            repositorio = new RepositorioTutor();
            tutor = null; 
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                tutor = new Tutor();
                tutor.setNome(inputNome.Text);
                tutor.setCpf(inputCpf.Text);
                tutor.setEmail(inputEmail.Text);
                tutor.setTelefone(inputTelefone.Text);
                repositorio.salvarTutor(tutor);
                MessageBox.Show("Tutor Registrado com Sucesso !!!");
                tutor = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }
    }
}
