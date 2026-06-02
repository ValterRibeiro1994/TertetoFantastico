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
        public MySqlCommand comandoSql;
        private string strComandoSql;
        private string strConexao = "datasource=localhost;username=root;password=;database=petshop_db";

        private MySqlConnection abrirBanco()
        {
            conexaoDb = new MySqlConnection();
            conexaoDb.ConnectionString = strConexao;
            conexaoDb.Open();
            return conexaoDb;
        }

        private void fecharBanco(SqlConnection conexao)
        {
            if (conexao.State == System.Data.ConnectionState.Open) {
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
                comandoSql.CommandText = strComandoSql;
                comandoSql.CommandType = CommandType.Text;
                comandoSql.Connection = conexaoDb;
                adaptadorSql.SelectCommand = comandoSql;
                adaptadorSql.Fill(conjuntoDados);
                return conjuntoDados;
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
                comandoSql.CommandText = strComandoSql;
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
                comandoSql.CommandText = strComandoSql;
                comandoSql.CommandType = CommandType.Text;
                comandoSql.Connection = conexaoDb;
                return comandoSql.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao executar consulta: " + ex.Message);
            }
            finally
            {
                conexaoDb.Close();
            }
        }
    }
}
