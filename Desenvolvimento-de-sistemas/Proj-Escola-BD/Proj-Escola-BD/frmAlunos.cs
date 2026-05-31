using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proj_Escola_BD
{
    public partial class frmAlunos : Form
    {
        Conexao Conexao = new Conexao();
        StringBuilder cmdSql = new StringBuilder();
        DataSet conjuntoDeDados;
        DataTable DT;
        MySqlDataReader Sqlreader;

        // classe utilitaria para verificação dos campos de entrada
        Utilidades utilidades = new Utilidades();

        public frmAlunos()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            // verifica se todos os campos foram preenchidos
            
            // verifica o campo de matricula
            if (!utilidades.validarCampo(txtMatricula.Text, "Número da matricula do aluno")){
                // se for falso encerra a execução
                return;
            }

            // verifica o campo nome do aluno
            if (!utilidades.validarCampo(txtNome.Text, "Nome do aluno")) { return; }

            // verifica o campo Email do aluno
            if (!utilidades.validarCampo(txtEmail.Text, "E-mail do aluno")){ return; }

            // verifica o campo data de nascimento do aluno
            if (!utilidades.validarCampo(dtpNasc.Text, "Data de nascimento do aluno")) {  return; }

            // verifica o campo CFP do aluno
            if (!utilidades.validarCampo(txtCPF.Text, "Cpf do aluno")) { return; }

            if (!utilidades.validarCampo(outputFoto.ImageLocation, "Imagem do aluno")) { return ; }

            byte[] imagemBytes = File.ReadAllBytes(outputFoto.ImageLocation);
         
            
            // Monta a string builder para construir o comando do sql
            cmdSql.Remove(0, cmdSql.Length);
            cmdSql.Append("insert into Alunos ");
            cmdSql.Append("(Matricula_Alu, Nome_Alu, Email_Alu, Nasc_Alu, CPF_Alu, NomeFoto_Alu, Foto_Alu) ");
            cmdSql.Append("Values ");
            cmdSql.Append("(@Matricula_Alu, @Nome_Alu, @Email_Alu, @Nasc_Alu, @CPF_Alu, @NomeFoto_Alu, @Foto_Alu); ");



            // adiciona os valores da string de comando
            Conexao.Comandos.Parameters.Clear();
            Conexao.Comandos.Parameters.AddWithValue("@Matricula_Alu", txtMatricula.Text);
            Conexao.Comandos.Parameters.AddWithValue("@Nome_Alu", txtNome.Text);
            Conexao.Comandos.Parameters.AddWithValue("@Email_Alu",txtEmail.Text);
            Conexao.Comandos.Parameters.AddWithValue("@Nasc_Alu", dtpNasc.Value);
            Conexao.Comandos.Parameters.AddWithValue("@CPF_Alu", txtCPF.Text);
            Conexao.Comandos.Parameters.AddWithValue("@NomeFoto_Alu", txtNome.Text + "_foto");
            Conexao.Comandos.Parameters.AddWithValue("@Foto_Alu", imagemBytes);
            Conexao.StrSql = cmdSql.ToString();

            // realiza o processo com tratamento e captura de erro
            try {
                if (Conexao.executarComando() > 0)
                {
                    MessageBox.Show("Inclusão com sucesso");

                }
                else
                {
                    MessageBox.Show("Erro na inclusão");
                }

            } catch (Exception ex) {
            
                    // captura o erro em caso de falhas graves
                    MessageBox.Show("Erro (cadastrar aluno): " + ex.Message);
            }


        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            // verifica se o campo matricula foi preenchido
            if (!utilidades.validarCampo(txtMatricula.Text, "número da Matricula do aluno")) { return; }
            
            cmdSql.Remove(0, cmdSql.Length);
            cmdSql.Append("select * ");
            cmdSql.Append("from Alunos");
            cmdSql.Append(" WHERE Matricula_Alu = @Matricula_Alu");

            Conexao.Comandos.Parameters.Clear();
            Conexao.Comandos.Parameters.AddWithValue("@Matricula_Alu", txtMatricula.Text);

            Conexao.StrSql = cmdSql.ToString();



            Sqlreader = Conexao.retornarDataReader();

            if (Sqlreader.Read())
            {
                txtNome.Text = Sqlreader["Nome_Alu"].ToString();
                txtEmail.Text = Sqlreader["Email_Alu"].ToString();
                dtpNasc.Text = Sqlreader["Nasc_Alu"].ToString();
                txtCPF.Text = Sqlreader["CPF_Alu"].ToString();

                string nome_foto = Sqlreader["NomeFoto_Alu"].ToString();
                byte[] blob_aluno =  (byte[])Sqlreader["Foto_Alu"];
                
                using (MemoryStream ms = new MemoryStream(blob_aluno))
                {
                    Image img_aluno = Image.FromStream(ms);

                    outputFoto.Image = img_aluno;
                }
            }
            else
            {
                MessageBox.Show("Não localizado");
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            // verifica se o campo matricula foi preenchido
            if (!utilidades.validarCampo(txtMatricula.Text, "número da Matricula do aluno")) { return; }

            cmdSql.Remove(0, cmdSql.Length);
            cmdSql.Append("delete from Alunos");
            cmdSql.Append(" where Matricula_Alu = @Matricula_Alu");

            Conexao.Comandos.Parameters.Clear();
            Conexao.Comandos.Parameters.AddWithValue("@Matricula_Alu", txtMatricula.Text);
            Conexao.StrSql = cmdSql.ToString();

            if (Conexao.executarComando() > 0)
            {
                MessageBox.Show("Exclusão com sucesso");

            }
            else
            {
                MessageBox.Show("Erro na inclusão");
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            /*
             Esse método retorna todos os alunos registrados
             */
            cmdSql.Remove(0, cmdSql.Length);
            cmdSql.Append("select * ");
            cmdSql.Append("from Alunos");

            Conexao.StrSql = cmdSql.ToString();
            conjuntoDeDados = Conexao.RetornarDataSet();

            DT = conjuntoDeDados.Tables[0];
            dtpAlunos.DataSource = DT;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtMatricula.Text = "";
            txtNome.Text = "";
            txtEmail.Text = "";
            txtCPF.Text = "";
            dtpNasc.Value = DateTime.Now;
            outputFoto.Image = null;
        }

        private void alterarbtn_Click(object sender, EventArgs e)
        {
            cmdSql.Remove(0, cmdSql.Length);
            cmdSql.Append("update alunos set ");
            cmdSql.Append("Nome_Alu = @Nome_Alu , Email_Alu = @Email_Alu , Nasc_Alu = @Nasc_Alu , CPF_Alu = @CPF_Alu, NomeFoto_Alu = @NomeFoto_Alu, Foto_Alu = @Foto_Alu");
            cmdSql.Append(" where Matricula_Alu= @Matricula_Alu");
            //update filme set nome_filme='Teste',data_lanc_filme = curdate() where id_filme = 5;
            byte[] imagemBytes = File.ReadAllBytes(outputFoto.ImageLocation);

            Conexao.Comandos.Parameters.Clear();
            Conexao.Comandos.Parameters.AddWithValue("@Matricula_Alu",txtMatricula.Text);
            Conexao.Comandos.Parameters.AddWithValue("@Nome_Alu", txtNome.Text);
            Conexao.Comandos.Parameters.AddWithValue("@Email_Alu", txtEmail.Text);
            Conexao.Comandos.Parameters.AddWithValue("@Nasc_Alu", dtpNasc.Value);
            Conexao.Comandos.Parameters.AddWithValue("@CPF_Alu", txtCPF.Text);
            Conexao.Comandos.Parameters.AddWithValue("@NomeFoto_Alu", txtNome.Text + "_foto");
            Conexao.Comandos.Parameters.AddWithValue("@Foto_Alu", imagemBytes);
          

            Conexao.StrSql = cmdSql.ToString();



            if (Conexao.executarComando() > 0)
            {
                MessageBox.Show("Alteração com sucesso");

            }
            else
            {
                MessageBox.Show("Erro na Alteração");
            }
        }

        private void dtpAlunos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtpAlunos_MouseClick(object sender, MouseEventArgs e)
        {
            txtMatricula.Text = dtpAlunos.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = dtpAlunos.CurrentRow.Cells[1].Value.ToString();
            txtEmail.Text = dtpAlunos.CurrentRow.Cells[2].Value.ToString();
            dtpNasc.Text = dtpAlunos.CurrentRow.Cells[3].Value.ToString();
            txtCPF.Text = dtpAlunos.CurrentRow.Cells[4].Value.ToString();


            try
            {
                byte[] blob_aluno = (byte[])dtpAlunos.CurrentRow.Cells[6].Value;

                using (MemoryStream ms = new MemoryStream(blob_aluno))
                {
                    Image img_aluno = Image.FromStream(ms);

                    outputFoto.Image = img_aluno;
                }
            }
            catch (Exception ex) {
                outputFoto.Image = null;

            }

        }

        private void btnFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog cxDialogo = new OpenFileDialog();

            cxDialogo.Title = "Selecione imagem";
            cxDialogo.Filter = "Imagens|*.jpg;*.jpeg;*.png;*.gif";
           

            if (cxDialogo.ShowDialog() == DialogResult.OK) 
            { 
                outputFoto.ImageLocation = cxDialogo.FileName;
            }
        }

        private void outputFoto_Click(object sender, EventArgs e)
        {

        }
    }
}
