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
        double desconto, juros;


        public frmMensalidade()
        {
            InitializeComponent();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            campoId.Text = "";
            campoMatricula.Text = "";
            campoPagamento.Text = "";
            campoData.Value = DateTime.Now;
            outputJuros.Text = "";
            outputDesconto.Text = "";
            outputTotalPagamento.Text = "";
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            // checa se o campo matricula está preenchido
            if (!utilidades.validarCampo(campoId.Text, "Id da mensalidade"))
            {
                return;
            }

            cmdSql.Remove(0, cmdSql.Length);
            cmdSql.Append("delete from mensalidade");
            cmdSql.Append(" where Id_Mens = @id");

            Conexao.Comandos.Parameters.Clear();
            Conexao.Comandos.Parameters.AddWithValue("@id", campoId.Text);
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

            // valida as entradas necessarias
            if (!utilidades.validarCampo(campoMatricula.Text, "Matricula da mensalidade"))
            {
                return;
            }
            if (!utilidades.validarCampo(campoPagamento.Text, "Valor a pagar"))
            {
                return;
            }

            // define o valor de juros ou desconto partindo do Dia do mês
            calcularMudanca(campoData.Value.Day);

            // cria o comando de inserir 
            cmdSql.Remove(0, cmdSql.Length); // limpa a string de comando
            cmdSql.Append("INSERT INTO mensalidade "); // insere na tabela mensalidade
            cmdSql.Append("(Matricula_Alu ,DtPag_Mens , VlPag_Mens , Juros_Mens , Desconto_Mens) "); // insere nos campos
            cmdSql.Append("Values "); // os seguintes valores
            cmdSql.Append("(@Matricula_Alu, @DtPag_Mens , @VlPag_Mens , @Juros_Mens , @Desconto_Mens); "); // placeholders 

            // tente executar o comando
            try
            {
                Conexao.Comandos.Parameters.Clear(); // limpa os parametros anteriores
                Conexao.Comandos.Parameters.AddWithValue("@Matricula_Alu", campoMatricula.Text); // adiciona a matricula
                Conexao.Comandos.Parameters.AddWithValue("@DtPag_Mens", campoData.Value); // adiciona a data 
                Conexao.Comandos.Parameters.AddWithValue("@VlPag_Mens", Double.Parse(campoPagamento.Text)); // adiciona o valor a ser pago
                Conexao.Comandos.Parameters.AddWithValue("@Juros_Mens", this.juros); // adiciona o juros definido
                Conexao.Comandos.Parameters.AddWithValue("@Desconto_Mens", this.desconto); // adiciona o desconto definido
                Conexao.StrSql = cmdSql.ToString(); // envia a string de comando para o banco

                // executa o comando
                if (Conexao.executarComando() > 0)
                {
                    exibirTotal(calcularTotal());
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
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (!utilidades.validarCampo(campoMatricula.Text, "Matricula do aluno"))
            {
                return;
            }

            cmdSql.Remove(0, cmdSql.Length);
            cmdSql.Append("SELECT ");
            cmdSql.Append("Id_Mens as 'Id', ");
            cmdSql.Append("Matricula_Alu as 'Matricula', ");
            cmdSql.Append("DtPag_Mens as 'Data de Pagamento', ");
            cmdSql.Append("VlPag_Mens as 'Valor da Mensalidade', ");
            cmdSql.Append("Juros_Mens as 'Juros Aplicado', ");
            cmdSql.Append("Desconto_Mens as 'Desconto Aplicado', ");
            cmdSql.Append("VlPag_Mens+(VlPag_Mens*(Juros_Mens/100)) as 'Valor com Juros', ");
            cmdSql.Append("VlPag_Mens-(VlPag_Mens*(Desconto_Mens/100)) as 'Valor com Desconto' ");
            cmdSql.Append("FROM mensalidade WHERE Matricula_Alu = @matricula");

            Conexao.Comandos.Parameters.Clear();
            Conexao.Comandos.Parameters.AddWithValue("@matricula", campoMatricula.Text.ToString());
            Conexao.StrSql = cmdSql.ToString();
            conjuntoDeDados = Conexao.RetornarDataSet();
            DT = conjuntoDeDados.Tables[0];
            gridMensalidade.DataSource = DT;
        }
        

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            ChamarGrid();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {

            if (!utilidades.validarCampo(campoMatricula.Text, "Matricula do aluno"))
            {
                return;
            }
            if (!utilidades.validarCampo(campoPagamento.Text, "Valor a pagar"))
            {
                return;
            }

            calcularMudanca(campoData.Value.Day);
            exibirTotal(calcularTotal());

            try
            {
                cmdSql.Remove(0, cmdSql.Length);
                cmdSql.Append("update mensalidade set ");
                cmdSql.Append("DtPag_Mens =  @DtPag_Mens , VlPag_Mens = @VlPag_Mens , Juros_Mens = @Juros_Mens  , Desconto_Mens = @Desconto_Mens");
                cmdSql.Append(" where Id_Mens= @id");

                Conexao.Comandos.Parameters.Clear();
                Conexao.Comandos.Parameters.AddWithValue("@id", campoId.Text);
                Conexao.Comandos.Parameters.AddWithValue("@DtPag_Mens", campoData.Value);
                Conexao.Comandos.Parameters.AddWithValue("@VlPag_Mens", Double.Parse(campoPagamento.Text));
                Conexao.Comandos.Parameters.AddWithValue("@Juros_Mens", this.juros);
                Conexao.Comandos.Parameters.AddWithValue("@Desconto_Mens", this.desconto);

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void calcularMudanca (int dataPagamento)
        {
            // calcular o dia do pagamento e define as variaveis de desconto e de juros se houver
            this.juros = 0;
            this.desconto = 0;

            if (dataPagamento > 5)
            {
                this.juros = 7.25;
            }
            else if (dataPagamento < 5)
            {
                this.desconto = 5;
            }
            
        }

        private double calcularTotal ()
        {
            double valorApagar = Double.Parse(campoPagamento.Text);
            // não teve desconto nem juros
            if (this.desconto == 0 && this.juros == 0)
            {
                return valorApagar;
            }
            // teve desconto
            else if (this.desconto > 0)
            {
                return valorApagar - (valorApagar * (this.desconto / 100));
            }
            // teve juros
            else if (this.juros > 0)
            {
                return valorApagar + (valorApagar * (this.juros / 100));
            }

            // apenas para evitar erro de tipagem, esse else nunca vai ser executado
            else
            {
                return valorApagar;
            }


        }

        private void exibirTotal (double total)
        {
            outputDesconto.Text = this.desconto + "%";
            outputJuros.Text = this.juros + "%";
            outputTotalPagamento.Text = "R$: " + total;
        }

        private void selecionarMensalidade(object sender, DataGridViewCellEventArgs e)
        {
            campoId.Text = gridMensalidade.CurrentRow.Cells[0].Value.ToString();
            campoMatricula.Text = gridMensalidade.CurrentRow.Cells[1].Value.ToString();
            campoData.Text = gridMensalidade.CurrentRow.Cells[2].Value.ToString();
            campoPagamento.Text = gridMensalidade.CurrentRow.Cells[3].Value.ToString();
            outputJuros.Text = gridMensalidade.CurrentRow.Cells[4].Value.ToString();
            outputDesconto.Text = gridMensalidade.CurrentRow.Cells[5].Value.ToString();
            // checa se o valor real a ser pago é o do juros ou do desconto
            if (Double.Parse(outputJuros.Text) == 0)
            {
                outputTotalPagamento.Text = "R$: " + gridMensalidade.CurrentRow.Cells[7].Value.ToString();
            }

            if (Double.Parse(outputDesconto.Text) == 0)
            {
                outputTotalPagamento.Text = "R$: " + gridMensalidade.CurrentRow.Cells[6].Value.ToString();
            }

            outputDesconto.Text += "%";
            outputJuros.Text += "%";
        }

        private void ChamarGrid()
        {
            cmdSql.Remove(0, cmdSql.Length);
            cmdSql.Append("SELECT ");
            cmdSql.Append("Id_Mens as 'id', ");
            cmdSql.Append("Matricula_Alu as 'Matricula', ");
            cmdSql.Append("DtPag_Mens as 'Data de Pagamento', ");
            cmdSql.Append("VlPag_Mens as 'Valor da Mensalidade', ");
            cmdSql.Append("Juros_Mens as 'Juros Aplicado', ");
            cmdSql.Append("Desconto_Mens as 'Desconto Aplicado', ");
            cmdSql.Append("VlPag_Mens+(VlPag_Mens*(Juros_Mens/100)) as 'Valor com Juros', ");
            cmdSql.Append("VlPag_Mens-(VlPag_Mens*(Desconto_Mens/100)) as 'Valor com Desconto' ");
            cmdSql.Append("FROM mensalidade");
            Conexao.StrSql = cmdSql.ToString();
            conjuntoDeDados = Conexao.RetornarDataSet();
            DT = conjuntoDeDados.Tables[0];
            gridMensalidade.DataSource = DT;

        }
    }
}
