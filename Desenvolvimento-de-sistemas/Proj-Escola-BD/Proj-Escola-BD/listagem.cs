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

namespace Proj_Escola_BD
{
    public partial class listagem : Form
    {
        Conexao Conexao = new Conexao();
        StringBuilder cmdSql = new StringBuilder();
        DataSet conjuntoDeDados;
        DataTable DT;
        //MySqlDataReader Sqlreader;

        public listagem()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnAlunos_Click(object sender, EventArgs e)
        {
            cmdSql.Remove(0, cmdSql.Length);
            cmdSql.Append("select *");
            cmdSql.Append("from alunos order by Nome_Alu");

            Conexao.StrSql = cmdSql.ToString();
            conjuntoDeDados = Conexao.RetornarDataSet();

            DT = conjuntoDeDados.Tables[0];
            gridLista.DataSource = DT;
        }

        private void btnPagamentos_Click(object sender, EventArgs e)
        {
            int Mes = dtpInput.Value.Month;
            cmdSql.Remove(0, cmdSql.Length);
            cmdSql.Append("SELECT alunos.Matricula_Alu, Nome_Alu, Nasc_Alu, Email_Alu, CPF_Alu, DtPag_Mens, VlPag_Mens, Juros_Mens, Desconto_Mens,");
            cmdSql.Append("IF(Juros_Mens > 0 && Desconto_Mens = 0,VlPag_Mens+(VlPag_Mens*(Juros_Mens/100)),IF(Desconto_Mens > 0 && Juros_Mens = 0,VlPag_Mens-(VlPag_Mens*(Desconto_Mens/100)),VlPag_Mens)) as Valor_total ");
            cmdSql.Append("from mensalidade INNER JOIN Alunos ON mensalidade.Matricula_Alu = alunos.Matricula_Alu ");
            cmdSql.Append("where Month(DtPag_Mens) = @DtPag_Mens;");


            Conexao.Comandos.Parameters.Clear();
            Conexao.Comandos.Parameters.AddWithValue("@DtPag_Mens", Mes);

            Conexao.StrSql = cmdSql.ToString();
            conjuntoDeDados = Conexao.RetornarDataSet();

            DT = conjuntoDeDados.Tables[0];
            gridLista.DataSource = DT;

        }

        private void btnAniver_Click(object sender, EventArgs e)
        {
            int Mes = dtpInput.Value.Month;
            cmdSql.Remove(0, cmdSql.Length);
            cmdSql.Append("SELECT * ");
            cmdSql.Append("from alunos where Month(Nasc_Alu) = @Nasc_Alu order by Nasc_Alu, Nome_Alu");


            Conexao.Comandos.Parameters.Clear();
            Conexao.Comandos.Parameters.AddWithValue("@Nasc_Alu", Mes);

            Conexao.StrSql = cmdSql.ToString();
            conjuntoDeDados = Conexao.RetornarDataSet();

            DT = conjuntoDeDados.Tables[0];
            gridLista.DataSource = DT;
        }

        private void btnDesconto_Click(object sender, EventArgs e)
        {
            int Mes = dtpInput.Value.Month;
            cmdSql.Remove(0, cmdSql.Length);
            cmdSql.Append("SELECT alunos.Matricula_Alu, Nome_Alu, Nasc_Alu, Email_Alu, CPF_Alu, DtPag_Mens, VlPag_Mens, Juros_Mens, Desconto_Mens ");
            cmdSql.Append("from mensalidade INNER JOIN Alunos ON mensalidade.Matricula_Alu = alunos.Matricula_Alu ");
            cmdSql.Append("where Desconto_Mens > 0 and Month(DtPag_Mens) = @DtPag_Mens order by Nome_Alu, Day(VlPag_Mens);");


            Conexao.Comandos.Parameters.Clear();
            Conexao.Comandos.Parameters.AddWithValue("DtPag_Mens", Mes);

            Conexao.StrSql = cmdSql.ToString();
            conjuntoDeDados = Conexao.RetornarDataSet();

            DT = conjuntoDeDados.Tables[0];
            gridLista.DataSource = DT;
        }
    }
}
