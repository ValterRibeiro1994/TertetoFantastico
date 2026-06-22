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
    public partial class FormCadastrarServico : Form
    {
        
        RepositorioServico repositorio;
        Servico servico;
        public FormCadastrarServico()
        {
            InitializeComponent();
            repositorio = new RepositorioServico();
            servico = null;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                CodigoBanco codigo = new CodigoBanco(inputCodigo.Text);
                TipoServiço tipo = new TipoServiço(tipoS: inputServiço);
                DataServico data = new DataServico(dataForm: dtpDataServico);
                ValorServico valor = new ValorServico(valorForm: inputValor);
               
                // checa se o pet Existe
                RepositorioPet repos = new RepositorioPet();
                Pet pet = repos.buscarPetCodigo(codigo);
                if (pet != null) {
                        servico = new Servico();
                        servico.setCodigo(codigo);
                        servico.setTipo(tipo);
                        servico.setData(data);
                        servico.setValor(valor);


                        if (repositorio.salvarServico(servico))
                        {
                            MessageBox.Show("Servico Registrado com Sucesso !!!");
                        }
                        else
                        {
                            MessageBox.Show("Servico Não registrado !!!");
                        }
                        servico = null;
                    }

                repos = null;
                
            } catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }
    }
}
