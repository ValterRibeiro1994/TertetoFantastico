using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;


namespace Proj_Escola_BD
{
    public partial class frmMensalidade : Form
    {
        Conexao Conexao = new Conexao();
        StringBuilder cmdSql = new StringBuilder();
        DataSet conjuntoDeDados;
        DataTable DT;
        MySqlDataReader Sqlreader;
        Utilidades utilidades = new Utilidades();


        public frmMensalidade()
        {
            InitializeComponent();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtMat.Text = "";
            txtVPag.Text = "";
            dtpPag.Value = DateTime.Now;
            lbljurus.Text = "";
            lblDesconto.Text = "";
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            cmdSql.Remove(0, cmdSql.Length);
            cmdSql.Append("delete from mensalidade");
            cmdSql.Append(" where Matricula_Alu = @Matricula_Alu");

            Conexao.Comandos.Parameters.Clear();
            Conexao.Comandos.Parameters.AddWithValue("@Matricula_Alu", txtMat.Text);
            Conexao.StrSql = cmdSql.ToString();
           

            if (Conexao.executarComando() > 0)
            {
                MessageBox.Show("Exclusão com sucesso");
                ChamarGrid();

            }
            else
            {
                MessageBox.Show("Erro na Exclusão");
            }
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {

            try
            {
                if (!utilidades.validarCampo(txtMat.Text, "Matricula da mensalidade"))
                {
                    return;
                }
                if (!utilidades.validarCampo(txtVPag.Text, "Valor a pagar"))
                {
                    return;
                }


                calcularMudanca(dtpPag.Value.Day);


                cmdSql.Remove(0, cmdSql.Length);
                cmdSql.Append("insert into mensalidade ");
                cmdSql.Append("(Matricula_Alu ,DtPag_Mens , VlPag_Mens , Juros_Mens , Desconto_Mens) ");
                cmdSql.Append("Values ");
                cmdSql.Append("(@Matricula_Alu, @DtPag_Mens , @VlPag_Mens , @Juros_Mens , @Desconto_Mens); ");

                Conexao.Comandos.Parameters.Clear();
                Conexao.Comandos.Parameters.AddWithValue("@Matricula_Alu", txtMat.Text);
                Conexao.Comandos.Parameters.AddWithValue("@DtPag_Mens", dtpPag.Value);
                Conexao.Comandos.Parameters.AddWithValue("@VlPag_Mens", Double.Parse(txtVPag.Text));
                Conexao.Comandos.Parameters.AddWithValue("@Juros_Mens", Double.Parse(lbljurus.Text));
                Conexao.Comandos.Parameters.AddWithValue("@Desconto_Mens", Double.Parse(lblDesconto.Text));

                Conexao.StrSql = cmdSql.ToString();



                if (Conexao.executarComando() > 0)
                {

                    double valorAPagar = double.Parse(txtVPag.Text.ToString());
                    double juros = double.Parse(lbljurus.Text.ToString());
                    double desc = double.Parse(lblDesconto.Text.ToString());

                    exibirTotal(calcularTotal(valorAPagar, juros, desc));
                    ChamarGrid();

                    MessageBox.Show("Inclusão com sucesso");


                }
                else
                {
                    MessageBox.Show("Erro na inclusão");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("A matricula precisa ser igual a do aluno");
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {

          

            calcularMudanca(dtpPag.Value.Day);
            

            cmdSql.Remove(0, cmdSql.Length);
            cmdSql.Append("select * ");
            cmdSql.Append("from mensalidade");
            cmdSql.Append(" WHERE Matricula_Alu = @Matricula_Alu");

            Conexao.Comandos.Parameters.Clear();
            Conexao.Comandos.Parameters.AddWithValue("@Matricula_Alu", txtMat.Text);

            Conexao.StrSql = cmdSql.ToString();



            Sqlreader = Conexao.retornarDataReader();

            if (Sqlreader.Read())
            {
              
                txtVPag.Text = Sqlreader["VlPag_Mens"].ToString();
                dtpPag.Text = Sqlreader["DtPag_Mens"].ToString();
                lbljurus.Text = Sqlreader["Juros_Mens"].ToString();
                lblDesconto.Text = Sqlreader["Desconto_Mens"].ToString();

                double valorAPagar = double.Parse(txtVPag.Text.ToString());
                double juros = double.Parse(lbljurus.Text.ToString());
                double desc = double.Parse(lblDesconto.Text.ToString());
                exibirTotal(calcularTotal(valorAPagar, juros, desc));
                ChamarGrid();


            }
            else
            {
                MessageBox.Show("Não localizado");
            }
        }
        

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            cmdSql.Remove(0, cmdSql.Length);
            cmdSql.Append("select *, VlPag_Mens+(VlPag_Mens*(Juros_Mens/100)) as Total_Juros, VlPag_Mens-(VlPag_Mens*(Desconto_Mens/100)) as Total_Desc ");
            cmdSql.Append("from mensalidade");

            Conexao.StrSql = cmdSql.ToString();
            conjuntoDeDados = Conexao.RetornarDataSet();

            DT = conjuntoDeDados.Tables[0];
            gridMens.DataSource = DT;
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (!utilidades.validarCampo(txtMat.Text, "Matricula do aluno"))
            {
                return;
            }
            if (!utilidades.validarCampo(txtVPag.Text, "Valor a pagar"))
            {
                return;
            }

            double valorAPagar = double.Parse(txtVPag.Text.ToString());
            double juros = double.Parse(lbljurus.Text.ToString());
            double desc = double.Parse(lblDesconto.Text.ToString());

            calcularMudanca(dtpPag.Value.Day);
            exibirTotal(calcularTotal(valorAPagar, juros, desc));

            cmdSql.Remove(0, cmdSql.Length);
            cmdSql.Append("update mensalidade set ");
            cmdSql.Append("DtPag_Mens =  @DtPag_Mens , VlPag_Mens = @VlPag_Mens , Juros_Mens = @Juros_Mens  , Desconto_Mens = @Desconto_Mens");
            cmdSql.Append(" where Matricula_Alu= @Matricula_Alu");
            //update filme set nome_filme='Teste',data_lanc_filme = curdate() where id_filme = 5;


            Conexao.Comandos.Parameters.Clear();
            Conexao.Comandos.Parameters.AddWithValue("@Matricula_Alu", txtMat.Text);
            Conexao.Comandos.Parameters.AddWithValue("@DtPag_Mens", dtpPag.Value);
            Conexao.Comandos.Parameters.AddWithValue("@VlPag_Mens", Double.Parse(txtVPag.Text));
            Conexao.Comandos.Parameters.AddWithValue("@Juros_Mens", Double.Parse(lbljurus.Text));
            Conexao.Comandos.Parameters.AddWithValue("@Desconto_Mens", Double.Parse(lblDesconto.Text));

            
            Conexao.StrSql = cmdSql.ToString();
            



            if (Conexao.executarComando() > 0)
            {
                ChamarGrid();
                MessageBox.Show("Alteração com sucesso");
                
            }
            else
            {
                MessageBox.Show("Erro na Alteração");
            }
        }

        private void lbljurus_Click(object sender, EventArgs e)
        {

        }

        private void calcularMudanca (int dataPagamento)
        {

            if (dataPagamento > 5)
            {

                double jurus = 7.25;
                lbljurus.Text = "7,25";

                double desc = 0;
                lblDesconto.Text = "0";

            }
            else if (dataPagamento < 5)
            {
                double desc = 5;
                double jurus = 0;
                lblDesconto.Text = "5";
                lbljurus.Text = "0";


            }
            else
            {
                double desc = 0;
                double jurus = 0;
                lblDesconto.Text = "0";
                lbljurus.Text = "0";
            }
        }

        private double calcularTotal (double valorApagar, double jurosCal, double descCal )
        {
            valorApagar = Double.Parse(txtVPag.Text);
            jurosCal = Double.Parse(lbljurus.Text);
            descCal = Double.Parse(lblDesconto.Text);

            double total;

            if (descCal > 0 && jurosCal == 0)
            {
                total =  valorApagar - (valorApagar * (descCal / 100));
                return total;
            }
            else if (jurosCal > 0 && descCal == 0)
            {
                total = valorApagar + (valorApagar * (jurosCal / 100));
                return total;
            }
            else
            {
                total = valorApagar;
                return total;
            }
        }

        private void exibirTotal (double total)
        {
            lblTotal.Text = total.ToString();
        }

        private double converterValores ()
        {
            double valorAPagar = double.Parse(txtVPag.Text.ToString());
            double juros = double.Parse(lbljurus.Text.ToString());
            double desc = double.Parse(lblDesconto.Text.ToString());
            return valorAPagar;
            return juros;
            return desc;
        }

        private void ChamarGrid()
        {
 
            
                cmdSql.Remove(0, cmdSql.Length);
                cmdSql.Append("select *, VlPag_Mens+(VlPag_Mens*(Juros_Mens/100)) as Total_Juros, VlPag_Mens-(VlPag_Mens*(Desconto_Mens/100)) as Total_Desc ");
                cmdSql.Append("from mensalidade");

                Conexao.StrSql = cmdSql.ToString();
                conjuntoDeDados = Conexao.RetornarDataSet();

                DT = conjuntoDeDados.Tables[0];
                gridMens.DataSource = DT;
           
        }
    }
}
