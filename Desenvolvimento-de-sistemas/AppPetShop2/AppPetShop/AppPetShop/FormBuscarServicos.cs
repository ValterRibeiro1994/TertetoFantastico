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
            limparCampos();
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
                DataTable tabela_de_dados = repositorio.listarServicoes();
                gridServico.DataSource = tabela_de_dados;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (campoId.Text.Equals(""))
            {
                // se o Id tiver vazio ele não selecionou nenhum item da tabela
                MessageBox.Show("Campo Id Obrigatorio para alteração dos dados, clique no serviço que deseja ser editado antes");
                return;
            }

            try
            {
                Servico servico = new Servico();
                servico.setCodigo(new CodigoBanco(codigo: campoId.Text)); // CodigoBanco envia o Id do serviço e não o código do pet
                servico.setTipo(new TipoServiço(tipoS: campoTipo));
                servico.setData(new DataServico(dataForm: campoData));
                servico.setValor(new ValorServico(valorForm: campoValor));
            
            if (repositorio.alterarServico(servico)){
                MessageBox.Show("Dados Alterados com sucesso !!!");
            } else
            {
               MessageBox.Show("Dados não foram alterados !!!");
            }

             chamarGrid();
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

        private void limparCampos()
        {
            campoCodigo.Text = "";
            campoTipo.SelectedItem = null;
            campoData.Value = DateTime.Now;
            campoValor.Text = "";
            campoTipo.Text = "Escolha um Serviço";
            campoId.Text = "Selecione um Serviço";
        }
        
        private void btnRemover_Click(object sender, EventArgs e)
        {
            try
            {
                CodigoBanco id = new CodigoBanco(campoId.Text);
                repositorio.removerServico(id);
                chamarGrid();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void clicar_celula(object sender, DataGridViewCellEventArgs e)
        {
            String id = gridServico.CurrentRow.Cells[0].Value.ToString();
            String codigo = gridServico.CurrentRow.Cells[1].Value.ToString();
            String tipo = gridServico.CurrentRow.Cells[2].Value.ToString();
            DateTime data = (DateTime) gridServico.CurrentRow.Cells[3].Value;
            String valor = gridServico.CurrentRow.Cells[4].Value.ToString();

            campoId.Text = id;
            campoCodigo.Text = codigo;
            campoTipo.Text = tipo;
            campoData.Value = data;
            campoValor.Text = valor;
        }
    }
}

