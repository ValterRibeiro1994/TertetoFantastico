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

            try
            {
                CodigoBanco id = new CodigoBanco(campoCodCons.Text.ToString());

                consulta = repositorio.buscarConsulta(id, gridConsulta);

                // Completa os campos em branco
                campoCodPet.Text = (consulta.getCodigo()).ToString();
                campoDesc.Text = consulta.getDesc();
                dtpDataConsulta.Value = consulta.getData();
                

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
                repositorio.listarConsultas(gridConsulta);
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
            string idCons = gridConsulta.CurrentRow.Cells[0].Value.ToString();
            if (!campoCodCons.Text.Equals(idCons))
            {
                MessageBox.Show("CPF não pode ser alterado !!!");
                return;
            }


            try
            {
                CodigoBanco id = new CodigoBanco(campoCodCons.Text);
                CodigoBanco codigoPet = new CodigoBanco(campoCodPet.Text);
                DataConsulta data = new DataConsulta(dtpDataConsulta);
                DescConsulta desc= new DescConsulta (campoDesc.Text);
                

                Consulta consulta = new Consulta();

                consulta.setId(id);
                consulta.setCodigo(codigoPet);
                consulta.setData(data);
                consulta.setDesc(desc);

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
            repositorio.limparConsulta(campoCodCons, campoCodPet, dtpDataConsulta , campoDesc);
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            try
            {
                CodigoBanco id = new CodigoBanco(campoCodCons.Text);
                repositorio.removerConsulta(id);
                repositorio.listarConsultas(gridConsulta);
                repositorio.limparConsulta(campoCodCons, campoCodPet, dtpDataConsulta, campoDesc);
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

            campoCodCons.Text = id;
            campoCodPet.Text = codPet;
            dtpDataConsulta.Value = data;
            campoDesc.Text = desc;
        }
    }
}
