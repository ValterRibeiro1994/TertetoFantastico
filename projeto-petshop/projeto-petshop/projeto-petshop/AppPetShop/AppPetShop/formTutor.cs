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
    public partial class formTutor : Form
    {
        Utilidades util = new Utilidades();

        public formTutor()
        {
            InitializeComponent();

            
        }

        private void btnCadTutor_Click(object sender, EventArgs e)
        {
            try
            {
                if (!util.validarCampo(txtNomeTutor.Text, "Nome do tutor"))
                {
                    return;
                }
                ;

                if (!util.validarCampo(txtCpfTutor.Text, "CPF do tutor"))
                {
                    return;
                }
                ;

                if (!util.validarCampo(txtCelTutor.Text, "Celular do tutor"))
                {
                    return;
                }
                ;

                if (!util.validarCampo(txtEmailTutor.Text, "Email do tutor"))
                {
                    return;
                }
                ;


                PegarDados(txtNomeTutor, txtCpfTutor, txtCelTutor, txtEmailTutor);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERRO ENCONTRADO: " + ex.Message);
            }
        }

        public static void PegarDados(TextBox Nome, TextBox CPF, TextBox Celular, TextBox Email)
        {
            String nome = Nome.Text;
            String cpf = CPF.Text;
            String celular = Celular.Text;
            String email = Email.Text;

        }
    }
}
