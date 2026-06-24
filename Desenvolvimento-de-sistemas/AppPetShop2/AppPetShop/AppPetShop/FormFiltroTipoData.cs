using System;
using System.Windows.Forms;

namespace AppPetShop
{
    public partial class FormFiltroTipoData : Form
    {
        RepositorioFiltros repositorio;

        public FormFiltroTipoData()
        {
            InitializeComponent();
            repositorio = new RepositorioFiltros();
        }

        private void FormFiltroTipoData_Load(object sender, System.EventArgs e)
        {
            inputServico.Items.Clear();
            inputServico.Text = "selecione um serviço";
            inputServico.Items.Add("banho");
            inputServico.Items.Add("tosa");
        }

        private void btnBuscarServico_Click(object sender, System.EventArgs e)
        {
            try
            {
                TipoServiço servico = new TipoServiço(tipoS: inputServico);
                gridServico.DataSource = repositorio.buscarServico(servico);

            } catch (Exception ex) {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void btnBuscarData_Click(object sender, EventArgs e)
        {
            try
            {
                Data data = new Data(dataForm: inputDataServico);
                gridServico.DataSource = repositorio.buscarData(data);
            } catch(Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Data data = new Data(dataForm: inputDataServico);
                TipoServiço servico = new TipoServiço(tipoS: inputServico);
                gridServico.DataSource = repositorio.buscarDataServico(data, servico);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }

        }
    }
}
