using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

        private void btnChamarGrid_Click(object sender, EventArgs e)
        {
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

                // limpa os parametros anteriores da conexão
                conexao_bd.comandoSql.Parameters.Clear();

                // adiciona a string de comando na conexão
                conexao_bd.setStrComandoSql(comandoSql.ToString());

                // captura os dados retornados
                conjuntoDeDados = conexao_bd.getDataSet();

                // monta a tabela de dados
                tabelaDados = conjuntoDeDados.Tables[0];

                // envia a tabela para o grid
                gridPet.DataSource = tabelaDados;
            }
            catch (Exception ex)
            {
                utils.notificarUsuario(ex.ToString());
            }
        }

        private void selecionarPet(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                
                campoCodigo.Text =  gridPet.CurrentRow.Cells[0].Value.ToString();
                inputCpf.Text = gridPet.CurrentRow.Cells[1].Value.ToString();
                campoEspecie.Text = gridPet.CurrentRow.Cells[6].Value.ToString();
                campoRaca.Text = gridPet.CurrentRow.Cells[4].Value.ToString();
                campoNome.Text = gridPet.CurrentRow.Cells[5].Value.ToString();

                String genero = gridPet.CurrentRow.Cells[3].Value.ToString();
                if (genero.Equals("F"))
                {
                    campoGenero.Text = "Femea";
                } else
                {
                    campoGenero.Text = "Macho";
                }

                campoData.Text = gridPet.CurrentRow.Cells[2].Value.ToString();

                byte[] blob_pet = (byte[]) gridPet.CurrentRow.Cells[7].Value;

                using (MemoryStream ms = new MemoryStream(blob_pet)) 
                {
                    Image img_pet = Image.FromStream(ms);

                    campoImagem.Image = img_pet;
                }

                

            }
            catch (Exception ex) {
                utils.notificarUsuario(ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                // limpa o stringbuilder
                comandoSql.Remove(0, comandoSql.Length);

                // insere o comando de busca
                comandoSql.Append("Update ");
                comandoSql.Append("tb_pet set ");
                comandoSql.Append("nascimento_pet = @nascimento_pet, ");
                comandoSql.Append("genero_pet = @genero_pet, ");
                comandoSql.Append("raca_pet = @raca_pet, ");
                comandoSql.Append("nome_pet = @nome_pet, ");
                comandoSql.Append("especie_pet = @especie_pet, ");
                comandoSql.Append("foto_pet = @foto_pet ");
                comandoSql.Append("where cod_pet = @cod_pet");

                // limpa os parametros anteriores da conexão
                conexao_bd.comandoSql.Parameters.Clear();

                byte[] foto_pet = File.ReadAllBytes(campoImagem.ImageLocation);
                //muda os parametros
                conexao.comandoSql.Parameters.AddWithValue("@nascimento_pet", campoData.Value);
                conexao.comandoSql.Parameters.AddWithValue("@genero_pet", campoGenero.Text[0]);
                conexao.comandoSql.Parameters.AddWithValue("@raca_pet", campoRaca.Text);
                conexao.comandoSql.Parameters.AddWithValue("@nome_pet", campoNome.Text);
                conexao.comandoSql.Parameters.AddWithValue("@especie_pet", campoEspecie.Text);
                conexao.comandoSql.Parameters.AddWithValue("@foto_pet", foto_pet);
                conexao.comandoSql.Parameters.AddWithValue("@cod_pet", campoCodigo.Text);

                // adiciona a string de comando na conexão
                conexao_bd.setStrComandoSql(comandoSql.ToString());

                if(conexao_bd.executarComando() > 0)
                {
                    utils.notificarUsuario("Foi rapazeada");
                }

            }
            catch (Exception ex)
            {
                utils.notificarUsuario(ex.ToString());
            }
        }

        private void btnFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog cxDialogo = new OpenFileDialog();

            cxDialogo.Title = "Selecione a imagem";
            cxDialogo.Filter = "Imagens|*.jpg;*.jpeg;*.png;*.gif";

            if (cxDialogo.ShowDialog() == DialogResult.OK)
            {
                campoImagem.ImageLocation = cxDialogo.FileName;
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            try
            {
                comandoSql.Clear();

                comandoSql.Append("Delete ");
                comandoSql.Append("From tb_pet ");
                comandoSql.Append("where ");
                comandoSql.Append("cod_pet = @cod_pet;");

                conexao_bd.comandoSql.Parameters.Clear();
                conexao_bd.comandoSql.Parameters.AddWithValue("@cod_pet", campoCodigo.Text);

                conexao_bd.setStrComandoSql(comandoSql.ToString());
                bool status = conexao_bd.executarComando() > 0;
                if (!status)
                {
                    utils.notificarUsuario("Comando Efetuado Mais Sem Resposta !!!");
                    return;
                }

                utils.notificarUsuario("Pet removido com sucesso !!!");

            }
            catch (Exception ex) 
            {
                utils.notificarUsuario(ex.Message);
            }
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
