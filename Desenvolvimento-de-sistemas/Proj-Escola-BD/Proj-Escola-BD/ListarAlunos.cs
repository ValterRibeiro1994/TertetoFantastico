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
            int mes = dataAtual.Value.Month;

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

        private void btnPagamentos_Click(object sender, EventArgs e)
        {

            comando_sql.Remove(0, comando_sql.Length);
            comando_sql.Append("SELECT ");

            // modificando o nome das colunas de apresentação
            comando_sql.Append("alunos.Matricula_Alu as 'Matricula', ");
            comando_sql.Append("Nome_Alu as 'Nome', ");
            comando_sql.Append("Email_Alu as 'Email', ");
            comando_sql.Append("Nasc_Alu as 'Data de nascimento', ");
            comando_sql.Append("CPF_Alu as 'CPF', ");
            comando_sql.Append("Foto_Alu as 'Foto Aluno', ");
            comando_sql.Append("DtPag_Mens as 'Data de Pagamento', ");
            comando_sql.Append("VlPag_Mens as 'Valor do pagamento', ");
            comando_sql.Append("Juros_Mens as 'Juros por atraso', ");
            comando_sql.Append("Desconto_Mens as 'Desconto por adiantamento', ");

            // condição para Juros pago
            comando_sql.Append("IF (Juros_Mens > 0 && Desconto_Mens = 0, ");

            // calcula o valor a ser pago na mensalidade 
            comando_sql.Append("VlPag_Mens + (VlPag_Mens * (Juros_Mens / 100)),");

            // condição para desconto pago
            comando_sql.Append("IF (Desconto_Mens > 0 && Juros_Mens = 0, ");

            // calcular o valor a ser pago
            comando_sql.Append("VlPag_Mens - (VlPag_Mens * (Desconto_Mens / 100)), ");

            // define um alias para o resultado do calculo
            comando_sql.Append("VlPag_Mens)) as 'Valor da mensalidade' ");

            // associa as tabelas para consulta de pagamento
            comando_sql.Append("FROM mensalidade "); // Primeira tabela para associação 
            comando_sql.Append("INNER JOIN Alunos "); // Segunda tabela para associação
            comando_sql.Append("ON mensalidade.Matricula_Alu = alunos.Matricula_Alu "); // condição para associção

            // verifica se o botão de radio foi selecionado
            if (checkFiltro.Checked)
            {
                comando_sql.Append("WHERE DtPag_Mens >= @DataDe AND DtPag_Mens < @DataAte");

                conexao.Comandos.Parameters.Clear();
                conexao.Comandos.Parameters.AddWithValue("@DataDe", new DateTime(inputDataDe.Value.Year, inputDataDe.Value.Month, inputDataDe.Value.Day));
                conexao.Comandos.Parameters.AddWithValue("@DataAte", new DateTime(inputDataAte.Value.Year, inputDataAte.Value.Month, inputDataAte.Value.Day));
            }
            else
            {

                comando_sql.Append("where Month(DtPag_Mens) = @DtPag_Mens;");
                conexao.Comandos.Parameters.Clear(); // limpa os parametros da conexão
                conexao.Comandos.Parameters.AddWithValue("@DtPag_Mens", dataAtual.Value.Month);
            }

            // envia o comando para execução
            conexao.StrSql = comando_sql.ToString();
            conjunto_dados = conexao.RetornarDataSet();

            // envia os dados para tabela do grid
            tabela_dados = conjunto_dados.Tables[0];
            gridAlunos.DataSource = tabela_dados;

        }

        private void checkFiltro_CheckedChanged(object sender, EventArgs e)
        {
            if (checkFiltro.Checked)
            {
                lblDataAte.Visible = true;
                lblDataDe.Visible = true;
                inputDataAte.Visible = true;
                inputDataDe.Visible = true;
            } else
            {
                lblDataAte.Visible = false;
                lblDataDe.Visible= false;
                inputDataAte.Visible = false;
                inputDataDe.Visible = false;
            }
        }

        private void btnDesconto_Click(object sender, EventArgs e)
        {
            comando_sql.Remove(0, comando_sql.Length);
            comando_sql.Append("SELECT ");

            // modificando o nome das colunas de apresentação
            comando_sql.Append("alunos.Matricula_Alu as 'Matricula', ");
            comando_sql.Append("Nome_Alu as 'Nome', ");
            comando_sql.Append("Email_Alu as 'Email', ");
            comando_sql.Append("Nasc_Alu as 'Data de nascimento', ");
            comando_sql.Append("CPF_Alu as 'CPF', ");
            comando_sql.Append("Foto_Alu as 'Foto Aluno', ");
            comando_sql.Append("DtPag_Mens as 'Data de Pagamento', ");
            comando_sql.Append("VlPag_Mens as 'Valor do pagamento', ");
            comando_sql.Append("Desconto_Mens as 'Desconto por adiantamento' ");
            // associa as tabelas para consulta de pagamento
            comando_sql.Append("FROM mensalidade "); // Primeira tabela para associação 
            comando_sql.Append("INNER JOIN alunos "); // Segunda tabela para associação
            comando_sql.Append("ON mensalidade.Matricula_Alu = alunos.Matricula_Alu "); // condição para associção
            // verifica se o botão de radio foi selecionado
            if (checkFiltro.Checked)
            {
                comando_sql.Append("WHERE Desconto_Mens > 0 "); // condição que garante apenas os que tem desconto
                comando_sql.Append("AND DtPag_Mens >= @DataDe AND DtPag_Mens <= @DataAte "); // garante apenas os registros dentro do intervalo de datas
                comando_sql.Append("ORDER by Nome_Alu, DtPag_Mens;"); // ordena pelo nome e pela data
                conexao.Comandos.Parameters.Clear();
                conexao.Comandos.Parameters.AddWithValue("@DataDe", new DateTime(inputDataDe.Value.Year, inputDataDe.Value.Month, inputDataDe.Value.Day));
                conexao.Comandos.Parameters.AddWithValue("@DataAte", new DateTime(inputDataAte.Value.Year, inputDataAte.Value.Month, inputDataAte.Value.Day));
            }
            else
            {

                comando_sql.Append("WHERE Desconto_Mens > 0 AND  Month(DtPag_Mens) = @Mes AND Year(DtPag_Mens) = @Ano ORDER by Nome_Alu, DtPag_Mens;");
                conexao.Comandos.Parameters.Clear(); // limpa os parametros da conexão
                conexao.Comandos.Parameters.AddWithValue("@Mes", dataAtual.Value.Month);
                conexao.Comandos.Parameters.AddWithValue("@Ano", dataAtual.Value.Year);
            }

            // envia o comando para execução
            conexao.StrSql = comando_sql.ToString();
            conjunto_dados = conexao.RetornarDataSet();

            // envia os dados para tabela do grid
            tabela_dados = conjunto_dados.Tables[0];
            gridAlunos.DataSource = tabela_dados;
        }
    }
}
