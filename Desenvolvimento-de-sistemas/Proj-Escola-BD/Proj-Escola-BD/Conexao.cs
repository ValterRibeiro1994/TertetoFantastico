using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Proj_Escola_BD
{
    internal class Conexao
    {
        MySqlConnection conexao = new MySqlConnection();
        public MySqlCommand Comandos = new MySqlCommand();

        private string _StrSql;

        public string StrSql
        {
            get { return _StrSql; }
            set { _StrSql = value; }
        }
        private string strconexao = "datasource=localhost;username=root;password=;database=escola";


        private MySqlConnection AbrirBanco()
        {
            MySqlConnection conexao = new MySqlConnection();
            conexao.ConnectionString = strconexao;
            conexao.Open();
            return conexao;
        }

        private void FecharBanco(SqlConnection conexao)
        {
            if (conexao.State == System.Data.ConnectionState.Open)
            {
                conexao.Close();
            }
        }

        public DataSet RetornarDataSet()
        {
            MySqlDataAdapter adaptadorSql = new MySqlDataAdapter();
            DataSet conjuntoDeDados = new DataSet();

            try
            {
                conexao = AbrirBanco();
                Comandos.CommandText = _StrSql;
                Comandos.CommandType = CommandType.Text;
                Comandos.Connection = conexao;
                adaptadorSql.SelectCommand = Comandos;
                adaptadorSql.Fill(conjuntoDeDados);
                return (conjuntoDeDados);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexao.Close();
            }
        }



        public MySqlDataReader retornarDataReader()
        {
            try
            {
                conexao = AbrirBanco();
                Comandos.CommandText = _StrSql;
                Comandos.CommandType = CommandType.Text;
                Comandos.Connection = conexao;
                return Comandos.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public int executarComando()
        {
            try
            {
                conexao = AbrirBanco();
                Comandos.CommandText = _StrSql;
                Comandos.CommandType = CommandType.Text;
                Comandos.Connection = conexao;
                return Comandos.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
            finally
            {

                conexao.Close();
            }
        }




    }

}
