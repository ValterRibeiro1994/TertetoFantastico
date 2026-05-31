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

namespace Proj_Escola_BD
{
    public partial class ListarAlunos : Form
    {

        Conexao conexao = new Conexao();
        StringBuilder comando_sql = new StringBuilder();
        DataSet conjunto_dados;
        DataTable tabela_dados;
        MySqlDataReader data_reader;

        public ListarAlunos()
        {
            InitializeComponent();
        }

        private void btnListarAlunos_Click(object sender, EventArgs e)
        {
            // comando para obter dados de alunos
            comando_sql.Remove(0, comando_sql.Length);
            comando_sql.Append("SELECT ");
            comando_sql.Append("Matricula_Alu as 'Matricula', ");
            comando_sql.Append("Nome_Alu as 'Nome', ");
            comando_sql.Append("Email_Alu as 'Email', ");
            comando_sql.Append("Nasc_Alu as 'Data de nascimento', ");
            comando_sql.Append("CPF_Alu as 'CPF', ");
            comando_sql.Append("Foto_Alu as 'Foto Aluno' ");
            comando_sql.Append("FROM alunos order by Nome_Alu");

            // prepara o comando para execução
            conexao.StrSql = comando_sql.ToString();

            // captura o conjunto de dados
            conjunto_dados = conexao.RetornarDataSet();

            // cria tabela de dados
            tabela_dados = conjunto_dados.Tables[0];

            // envia os dados para gridView
            gridAlunos.DataSource = tabela_dados;
        }


        private void gridAlunos_MouseClick(object sender, MouseEventArgs e)
        {
            exibirFoto();
        }

        private void btnAniversariantes_Click(object sender, EventArgs e)
        {
            // capturar o mês informado
            int mes = inputData.Value.Month;

            // comando para obter dados de alunos
            comando_sql.Remove(0, comando_sql.Length);
            comando_sql.Append("SELECT ");
            comando_sql.Append("Matricula_Alu as 'Matricula', ");
            comando_sql.Append("Nome_Alu as 'Nome', ");
            comando_sql.Append("Email_Alu as 'Email', ");
            comando_sql.Append("Nasc_Alu as 'Data de nascimento', ");
            comando_sql.Append("CPF_Alu as 'CPF', ");
            comando_sql.Append("Foto_Alu as 'Foto Aluno' ");
            comando_sql.Append("FROM alunos where Month(Nasc_Alu) = @Nasc_Alu order by Nasc_Alu, Nome_Alu");

            // apaga os parametros anteriores
            conexao.Comandos.Parameters.Clear();
            
            // adiciona o mês como parametro
            conexao.Comandos.Parameters.AddWithValue("@Nasc_Alu", mes);

            // prepara o comando para execução
            conexao.StrSql = comando_sql.ToString();

            // obtem o conjunto de dados retornado
            conjunto_dados = conexao.RetornarDataSet();

            // envia os dados para tabela do grid
            tabela_dados = conjunto_dados.Tables[0];
            gridAlunos.DataSource = tabela_dados;


        }

        private void exibirFoto()
        {
            try
            {
                // captura a string de bytes do blob armazenado no banco e converte para bytes
                byte[] blob_aluno = (byte[])gridAlunos.CurrentRow.Cells[5].Value;

                using (MemoryStream ms = new MemoryStream(blob_aluno))
                {
                    Image img_aluno = Image.FromStream(ms);

                    outputFoto.Image = img_aluno;
                }
            }
            catch (Exception ex)
            {
                outputFoto.Image = null;

            }
        }
    }
}
