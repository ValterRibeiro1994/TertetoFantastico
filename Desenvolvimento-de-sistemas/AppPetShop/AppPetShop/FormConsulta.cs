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
    public partial class FormConsulta : Form
    {
        Conexao conexao = new Conexao();
        StringBuilder cmdSql = new StringBuilder();
        Utilidades utils = new Utilidades();


        public FormConsulta()
        {
            InitializeComponent();
        }

        private bool validarEntradas()
        {
            if (utils.campoVazio(campoCod.Text))
            {
                utils.notificarUsuario("Campo Código está vazio, informe o codigo do pet !!!");
                return false;
            }

            try
            {
                int n = int.Parse(campoCod.Text);
                if (n <= 0)
                {
                    utils.notificarUsuario("Código de pet invalido !!!");
                    return false;
                }
            }
            catch (Exception ex)
            {
                utils.notificarUsuario("Código de Pet aceita apenas números !!!");
                return false;
            }


            if (utils.campoVazio(descConsulta.Text))
            {
                utils.notificarUsuario("Informe a descrição da consulta !!!!");
                return false;
            }

            return true;


        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            if (!validarEntradas())
            {
                return;
            }


            cmdSql.Remove(0, cmdSql.Length);
            cmdSql.Append(" Insert into tb_consulta ");
            cmdSql.Append(" (cod_pet, data_consulta, prescricao_consulta) ");
            cmdSql.Append("values (@codigo, @data, @prescricao);");

            try
            {
                conexao.comandoSql.Parameters.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.ToString()); // captura os detalhes do erro
                MessageBox.Show("Erro: " + ex.Message); // captura apenas mensagem
            }  

        }
    }
}
