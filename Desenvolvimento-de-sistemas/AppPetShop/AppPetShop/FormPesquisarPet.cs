using MySql.Data.MySqlClient;
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
    public partial class FormPesquisarPet : Form
    {
        string cpf, nome_pet, codigo_pet, raca_pet, genero_pet, especie_pet, nascimento_pet;
        Utilidades utils = new Utilidades();
        Conexao conexao_bd = new Conexao();
        StringBuilder comandoSql = new StringBuilder();
        DataSet conjuntoDeDados;
        DataTable tabelaDados;
        MySqlDataReader sqlDataReader;

        public FormPesquisarPet()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // captura o cpf do tutor
            try
            {
                setCpf(inputCpf.Text);
            }
            catch (Exception ex)
            {
                utils.notificarUsuario(ex.Message);
                return; // encerra em caso de falha
            }

            try
            {
                // limpa o stringbuilder
                comandoSql.Remove(0, comandoSql.Length);

                // insere o comando de busca
                comandoSql.Append("SELECT ");
                comandoSql.Append("cod_pet as 'Código', ");
                comandoSql.Append("cpf_tutor as 'CPF Tutor', ");
                comandoSql.Append("nascimento_pet as 'Data de nascimento', ");
                comandoSql.Append("genero_pet as 'Genero', ");
                comandoSql.Append("raca_pet as 'Raça', ");
                comandoSql.Append("nome_pet as 'Nome', ");
                comandoSql.Append("especie_pet as 'Especie', ");
                comandoSql.Append("foto_pet as 'Foto' ");
                comandoSql.Append("FROM tb_pet ");
                comandoSql.Append("WHERE cpf_tutor = @cpf;");

                // limpa os parametros anteriores da conexão
                conexao_bd.comandoSql.Parameters.Clear();

                // adiciona o cpf como parametro na conexão
                conexao_bd.comandoSql.Parameters.AddWithValue("@cpf", getCpf());

                // adiciona a string de comando na conexão
                conexao_bd.setStrComandoSql(comandoSql.ToString());

                // captura os dados retornados
                conjuntoDeDados = conexao_bd.getDataSet();

                // monta a tabela de dados
                tabelaDados = conjuntoDeDados.Tables[0];

                // envia a tabela para o grid
                gridPet.DataSource = tabelaDados;
            }
            catch (Exception ex) {
                utils.notificarUsuario(ex.ToString());
            }
        }


        /*
         armazenar dados em getters e setters
         */
        private void setCpf(string cpf)
        {
            if (utils.campoVazio(cpf))
            {
                throw new Exception("Campo cpf Obrigatorio !!!");
            }
            else if (utils.totalCaracteres(11, cpf))
            {
                throw new Exception("Cpf deve ter 11 Caracteres !!!");
            }
            else
            {
                this.cpf = cpf;
            }
        }

        private string getCpf()
        {
            return this.cpf;
        }
    }
}
