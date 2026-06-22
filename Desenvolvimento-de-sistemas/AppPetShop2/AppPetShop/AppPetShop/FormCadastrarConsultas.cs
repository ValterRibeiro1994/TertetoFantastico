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
    public partial class FormCadastrarConsultas : Form
    {
        RepositorioConsulta repositorio;
        Consulta consulta;
        public FormCadastrarConsultas()
        {
            InitializeComponent();
             repositorio = new RepositorioConsulta();
             consulta = null;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                CodigoBanco codigoPet = new CodigoBanco(campoCodPet.Text);
                Data dataConsulta = new Data(dataForm: campoData);
                Texto descricao = new Texto(campoDesc.Text, limite_max: 65000);

                Consulta Consulta = new Consulta();
                Consulta.setCodigo(codigoPet);
                Consulta.setData(dataConsulta);
                Consulta.setDesc(descricao);

                if (repositorio.salvarConsulta(Consulta))
                {
                    MessageBox.Show("Consulta cadastrada com sucesso!");
                    
                }
                else
                {
                    MessageBox.Show("Erro ao cadastrar a consulta.");
                } 
                Consulta = null;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar a consulta: " + ex.Message);
            }
        }
    }
}
