using System;
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
                Cpf cpf = new Cpf(inputCpf.Text);
                Texto nome = new Texto(inputNome.Text);
                Email email = new Email(inputEmail.Text);
                Telefone telefone = new Telefone(inputTelefone.Text);

                tutor = new Tutor();
                tutor.setNome(nome);
                tutor.setCpf(cpf);
                tutor.setEmail(email);
                tutor.setTelefone(telefone);
                if (repositorio.salvarTutor(tutor))
                {
                    MessageBox.Show("Tutor Registrado com Sucesso !!!");
                }
                else
                {
                    MessageBox.Show("Tutor Não registrado !!!");
                }
                tutor = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }
    }
}
