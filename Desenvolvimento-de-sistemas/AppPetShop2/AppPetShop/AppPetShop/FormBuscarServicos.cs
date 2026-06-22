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

        public FormBuscarServicos()
        {
            InitializeComponent();
            repositorio = new RepositorioServico();
        }

        private void btnFitrarCod_Click(object sender, EventArgs e)
        {
            try
            {
                CodigoBanco codigo = new CodigoBanco(campoCodigo.Text);
                gridServico.DataSource = repositorio.buscarServicosPet(codigo);
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
                gridServico.DataSource = repositorio.listarServicos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(campoId.Text))
            {
                MessageBox.Show("Clique no serviço a ser modificado !!!");
                return;
            }

            try
            {
                if (int.Parse(campoId.Text) > repositorio.obterUltimoId())
                {
                    MessageBox.Show("Id não existe na tabela de dados !!!");
                    return;
                }

                Servico servico = new Servico();
                servico.setCodigo(new CodigoBanco(campoId.Text));
                servico.setTipo(new TipoServiço(tipoS: campoTipo));
                servico.setData(new DataServico(dataForm: campoData));
                servico.setValor(new ValorServico(valorForm: campoValor));

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
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limparCampos();
        }

        private void limparCampos()
        {
            campoId.Text = String.Empty;
            campoCodigo.Text = String.Empty;
            campoData.Value = DateTime.Now;
            campoTipo.Text = String.Empty;
            campoValor.Text = String.Empty;
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            try
            {
                CodigoBanco codigoBanco = new CodigoBanco(campoCodigo.Text);
                repositorio.removerServico(codigoBanco);
                limparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void clicarCelula(object sender, DataGridViewCellEventArgs e)
        {
            String id = gridServico.CurrentRow.Cells[0].Value.ToString();
            String codigo = gridServico.CurrentRow.Cells[1].Value.ToString();
            String tipo = gridServico.CurrentRow.Cells[2].Value.ToString();
            DateTime data = (DateTime)gridServico.CurrentRow.Cells[3].Value;
            String valor = gridServico.CurrentRow.Cells[4].Value.ToString();

            campoId.Text = id;
            campoCodigo.Text = codigo;
            campoTipo.Text = tipo;
            campoData.Value = data;
            campoValor.Text = valor;
        }
    }
}