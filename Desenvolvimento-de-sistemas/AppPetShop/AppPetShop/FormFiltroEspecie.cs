using System;
using System.Windows.Forms;

namespace AppPetShop
{
    public partial class FormFiltroEspecie : Form
    {
        RepositorioFiltros repositorio;
        public FormFiltroEspecie()
        {
            InitializeComponent();
            repositorio = new RepositorioFiltros();
        }

        private void btnBuscarEspecie_Click(object sender, System.EventArgs e)
        {
            try
            {
                Texto especie = new Texto(inputEspecie.Text, limite_max: 30);
                gridEspecie.DataSource = repositorio.BuscarEspecie(especie);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }
    }
}
