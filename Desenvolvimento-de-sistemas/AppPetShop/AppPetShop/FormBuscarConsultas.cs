using System;
using System.Windows.Forms;

namespace AppPetShop
{
    public partial class FormBuscarConsultas : Form
    {
        RepositorioConsulta repositorio;
        Consulta consulta;
        public FormBuscarConsultas()
        {
            InitializeComponent();
            repositorio = new RepositorioConsulta();
            consulta = new Consulta();
        }

        private void btnFitrarCod_Click(object sender, EventArgs e)
        {
            /*
             Metodo filtra as consultas pelo código do PET
             */
            try
            {
                CodigoBanco codigoPet = new CodigoBanco(campoCodPet.Text);
                gridConsulta.DataSource = repositorio.buscarConsultaPet(codigoPet: codigoPet);

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
                // atualiza o grid view
                gridConsulta.DataSource = repositorio.listarConsultas();
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

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                // captura o codigo do PET que foi armazenado no banco
                string codigoPetGrid = gridConsulta.CurrentRow.Cells[1].Value.ToString();

                // verifica se ele não foi modificado, porque a consulta do PET x deve ser sempre do pet x
                if (!codigoPetGrid.Equals(campoCodPet.Text))
                {
                    MessageBox.Show("O Pet não deve ser alterado para essa consulta !!!");
                    return;
                }

                Consulta consulta = new Consulta();
                consulta.setCodigo(new CodigoBanco(campoId.Text));
                consulta.setData(new Data(dataForm: dtpDataConsulta));
                consulta.setDesc(new Texto(campoDesc.Text, limite_max: 65000));

                if (repositorio.alterarConsulta(consulta))
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

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limparCampos();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            try
            {
                CodigoBanco id = new CodigoBanco(campoId.Text);
                repositorio.removerConsulta(id);
                chamarGrid();
                limparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void clicarCelula(object sender, DataGridViewCellEventArgs e)
        {
            String id = gridConsulta.CurrentRow.Cells[0].Value.ToString();
            String codPet = gridConsulta.CurrentRow.Cells[1].Value.ToString();
            DateTime data = Convert.ToDateTime(gridConsulta.CurrentRow.Cells[2].Value);
            String desc = gridConsulta.CurrentRow.Cells[3].Value.ToString();

            campoId.Text = id;
            campoCodPet.Text = codPet;
            dtpDataConsulta.Value = data;
            campoDesc.Text = desc;
        }

        private void limparCampos()
        {
            campoId.Text = "";
            campoCodPet.Text = "";
            dtpDataConsulta.Value = DateTime.Now;
            campoDesc.Text = "";
        }
    }
}
