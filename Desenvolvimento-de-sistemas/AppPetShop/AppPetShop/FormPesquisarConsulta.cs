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
    public partial class FormPesquisarConsulta : Form
    {
        public FormPesquisarConsulta()
        {
            InitializeComponent();
        }

        private void pesquisarTutor_CheckedChanged(object sender, EventArgs e)
        {
            desmarcarData();
            desmarcarPet();

            // verifica se o campo atual está marcado
            if (pesquisarTutor.Checked)
            {
                rotuloIndentificador.Text = "Cpf do Tutor";
                rotuloIndentificador.Visible = true;
                inputId.Visible = true;
                btnPesquisar.Visible = true;
            }
            else
            {
                rotuloIndentificador.Visible = false;
                inputId.Visible = false;
                btnPesquisar.Visible = false;
            }
        }

        private void pesquisarPet_CheckedChanged(object sender, EventArgs e)
        {
            desmarcarData();
            desmarcarTutor();

            if (pesquisarPet.Checked)
            {
                rotuloIndentificador.Text = "Código do Pet";
                rotuloIndentificador.Visible = true;
                inputId.Visible = true;
                btnPesquisar.Visible = true;
            } 
            else
            {
                rotuloIndentificador.Visible = false;
                inputId.Visible = false;
                btnPesquisar.Visible = false;
            }
        }

        private void pesquisarData_CheckedChanged(object sender, EventArgs e)
        {
            desmarcarTutor();
            desmarcarPet();

            if (pesquisarData.Checked)
            {
                // rotulos
                rotuloDataAte.Visible = true;
                rotuloDataDe.Visible = true;
                
                // campos de entrada
                inputDataAte.Visible = true;
                inputDataDe.Visible = true;
            } 
            else
            {
                // rotulos
                rotuloDataAte.Visible = false;
                rotuloDataDe.Visible = false;
                
                //campos de entrada
                inputDataAte.Visible = false;
                inputDataDe.Visible = false;
            }
        }

        private void desmarcarData()
        {
            if (pesquisarData.Checked)
            {
                pesquisarData.Checked = false;
                pesquisarData_CheckedChanged(this, EventArgs.Empty);
            }
        }

        private void desmarcarPet()
        {
            // desmarca os campos de entrada marcados anteriormente
            if (pesquisarPet.Checked)
            {
                pesquisarPet.Checked = false;
                pesquisarPet_CheckedChanged(this, EventArgs.Empty);
            }

        }

        private void desmarcarTutor()
        {
            // desmarca os campos de entrada marcados anteriormente
            if (pesquisarTutor.Checked)
            {
                pesquisarTutor.Checked = false;
                pesquisarTutor_CheckedChanged(this, EventArgs.Empty);
            }

        }
    }
}
