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
    public partial class FiltrarPet : Form
    {
        RepositorioFiltros repos;
        public FiltrarPet()
        {
            InitializeComponent();
            repos = new RepositorioFiltros();
        }

        private void btnNascimento_Click(object sender, EventArgs e)
        {
            try
            {
                gridPet.DataSource = repos.ordenarPetNascimento();
            } catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
    }

        private void btnPetTutor_Click(object sender, EventArgs e)
        {
            try
            {
                gridPet.DataSource = repos.buscarPetTutor();
            } catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
    }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            try
            {
                gridPet.DataSource = repos.buscarConsultas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }
    }
}
