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
    public partial class FormFiltroEspecie : Form
    {
        RepositorioFiltros repositorio;
        public FormFiltroEspecie()
        {
            InitializeComponent();
            repositorio = new RepositorioFiltros();
        }

        private void btnBuscarEspecie_Click(object sender, EventArgs e)
        {
            try
            {
                Texto especie = new Texto(nome: inputEspecie.Text, limite_max: 30);
                gridEspecie.DataSource = repositorio.BuscarEspecie(especie);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
