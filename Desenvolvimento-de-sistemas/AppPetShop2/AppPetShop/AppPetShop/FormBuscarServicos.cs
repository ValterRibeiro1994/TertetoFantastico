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
    public partial class FormBuscarServicos : Form
    {
        RepositorioServico repositorio;
        Servico servico;
        public FormBuscarServicos()
        {
            InitializeComponent();
            repositorio = new RepositorioServico();
            servico = null;
        }

        private void btnFitrarCod_Click(object sender, EventArgs e)
        {

            try
            {
                CodigoBanco codigo = new CodigoBanco(campoCodigo.Text.ToString());
                
                servico = repositorio.buscarServico(codigo,gridServico);

                // Completa os campos em branco
                campoTipo.Text = servico.getTipo();
                campoData.Value = servico.getData();
                campoValor.Text = (servico.getValor()).ToString();

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

        private void chamarGrid()
        {
            try
            {
                repositorio.listarServicoes(gridServico);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            string codigo = gridServico.CurrentRow.Cells[0].Value.ToString();
            if (!campoCodigo.Text.Equals(codigo))
            {
                MessageBox.Show("CPF não pode ser alterado !!!");
                return;
            }

            try
            {
                CodigoBanco codigoBanco = new CodigoBanco(codigo);
                TipoServiço tipo = new TipoServiço(campoTipo);
                DataServico data = new DataServico(campoData);
                ValorServico valor = new ValorServico(campoValor);
                
                Servico servico = new Servico();
                servico.setCodigo(codigoBanco);
                servico.setTipo(tipo);
                servico.setData(data);
                servico.setValor(valor);

                if (repositorio.alterarServico(servico))
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
            repositorio.limparServico(campoCodigo, campoTipo, campoData, campoValor);
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            try
            {
                CodigoBanco codigoBanco = new CodigoBanco(campoCodigo.Text);
                repositorio.removerServico(codigoBanco);
                repositorio.listarServicoes(gridServico);
                repositorio.limparServico(campoCodigo, campoTipo, campoData, campoValor);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void clicarCelula(object sender, DataGridViewCellEventArgs e)
        {
            String codigo = gridServico.CurrentRow.Cells[0].Value.ToString();
            String tipo = gridServico.CurrentRow.Cells[1].Value.ToString();
            DateTime data = Convert.ToDateTime(gridServico.CurrentRow.Cells[2].Value);
            String valor = gridServico.CurrentRow.Cells[3].Value.ToString();

            campoCodigo.Text = codigo;
            campoTipo.Text = tipo;
            campoData.Value = data;
            campoValor.Text = valor;
        }

        private void clicar_celula(object sender, DataGridViewCellEventArgs e)
        {
            String codigo = gridServico.CurrentRow.Cells[0].Value.ToString();
            String tipo = gridServico.CurrentRow.Cells[1].Value.ToString();
            DateTime data = Convert.ToDateTime(gridServico.CurrentRow.Cells[2].Value);
            String valor = gridServico.CurrentRow.Cells[3].Value.ToString();

            campoCodigo.Text = codigo;
            campoTipo.Text = tipo;
            campoData.Value = data;
            campoValor.Text = valor;
        }
    }
}

