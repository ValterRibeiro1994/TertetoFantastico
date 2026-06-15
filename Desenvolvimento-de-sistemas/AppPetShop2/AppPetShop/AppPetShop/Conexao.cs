using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Data;
namespace AppPetShop
{
    internal class Conexao
    {
        MySqlConnection conexaoDb;
        public MySqlCommand comandoSql = new MySqlCommand();
        private string strComandoSql;
        private string strConexao = "datasource=localhost;username=root;password=;database=petshop_db";

        public string getStrComandoSql()
        {
            return this.strComandoSql;
        }

        public void setStrComandoSql(string comando)
        {
            this.strComandoSql = comando;
        }


        private MySqlConnection abrirBanco()
        {
            conexaoDb = new MySqlConnection();
            conexaoDb.ConnectionString = strConexao;
            conexaoDb.Open();
            return conexaoDb;
        }

        private void fecharBanco(SqlConnection conexao)
        {
            if (conexao.State == System.Data.ConnectionState.Open)
            {
                conexao.Close();
            }
        }

        public DataSet getDataSet()
        {
            MySqlDataAdapter adaptadorSql = new MySqlDataAdapter();
            DataSet conjuntoDados = new DataSet();
            try
            {
                conexaoDb = abrirBanco();
                comandoSql.CommandText = getStrComandoSql();
                comandoSql.CommandType = CommandType.Text;
                comandoSql.Connection = conexaoDb;
                adaptadorSql.SelectCommand = comandoSql;
                adaptadorSql.Fill(conjuntoDados);
                return (conjuntoDados);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter conjunto de dados: " + ex.Message);
            }
            finally
            {
                conexaoDb.Close();
            }
        }

        public MySqlDataReader getDataReader()
        {
            try
            {
                conexaoDb = abrirBanco();
                comandoSql.CommandText = getStrComandoSql();
                comandoSql.CommandType = CommandType.Text;
                comandoSql.Connection = conexaoDb;
                return comandoSql.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter DataReader: " + ex.Message);
            }
            finally
            {
                conexaoDb.Close();
            }
        }

        public int executarComando()
        {
            try
            {
                conexaoDb = abrirBanco();
                comandoSql.CommandText = getStrComandoSql();
                comandoSql.CommandType = CommandType.Text;
                comandoSql.Connection = conexaoDb;
                return comandoSql.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                // captura o código de erro
                int codigo_erro = ex.Number;
                if (codigo_erro == 1452) // chave estrangeira não existe na tabela pai
                {
                    // caso tente cadastrar pet sem antes cadastrar um tutor
                    if (ex.Message.Contains("cpf_tutor"))
                    {
                        throw new Exception("Erro: Tutor não registrado no sistema");
                    }
                    // para erros dentro do código ainda não descoberto
                    throw new Exception("Erro 1452 ao executar consulta: " + ex.Message + "-> " + ex.Number);
                }
                else if (codigo_erro == 1062) // Registro duplicado
                {
                    if (ex.Message.Contains("tb_tutor.PRIMARY"))
                    {
                        throw new Exception("Cpf já cadastrado no banco de dados");
                    }
                    else if (ex.Message.Contains("tb_tutor.celular_tutor"))
                    {
                        throw new Exception("Celular já registrado no banco de dados");
                    }
                    else if (ex.Message.Contains("tb_tutor.email_tutor"))
                    {
                        throw new Exception("Email já cadastrado no banco de dados");
                    }
                    else
                    {
                        throw new Exception("Campo duplicado: " + ex.Message);
                    }
                }

                // captura erros desconhecidos
                throw new Exception("Erro ao executar consulta: " + ex.Message + "-> " + ex.Number);
            }
            finally
            {
                conexaoDb.Close();
            }
        }
    }
}
