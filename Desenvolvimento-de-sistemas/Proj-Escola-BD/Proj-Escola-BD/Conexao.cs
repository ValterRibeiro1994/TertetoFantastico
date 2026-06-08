using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            catch (MySqlException ex)
            {
                if (ex.Number == 1452)
                {
                    // chave estrangeira não existe na tabela principal
                    // ou seja na tabela mensalidade a matricula informada não existe na tabela alunos
                    if (ex.Message.Contains("Matricula_Alu"))
                    {
                        throw new Exception("Aluno não registrado no banco de dados");
                    }
                } 
                // captura erro de valores duplicados
                else if (ex.Number == 1062)
                {
                    // email, cpf ou matricula já foram adicionados
                    if (ex.Message.Contains("alunos.PRIMARY"))
                    {
                        // Matricula já existe
                        throw new Exception("Matricula já existe no banco de dados");
                    } 
                    else if (ex.Message.Contains("alunos.CPF_Alu"))
                    {
                        // CPF já Existe
                        throw new Exception("Cpf já existe no banco de dados");
                    } 
                    else if (ex.Message.Contains("alunos.Email_Alu"))
                    {
                        // Email já Existe
                        throw new Exception("Email já existe no banco de dados");
                    }
                }

                // erro desconhecido
                throw new Exception("ERRO DESCONHECIDO: " + ex.Message);
            }
            finally
            {

                conexao.Close();
            }
        }




    }

}
