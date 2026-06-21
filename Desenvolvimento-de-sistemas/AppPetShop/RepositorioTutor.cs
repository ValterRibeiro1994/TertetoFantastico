using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppPetShop
{
    internal class RepositorioTutor
    {
        private Conexao conexao;
        private StringBuilder string_comando;

        public RepositorioTutor()
        {
            conexao = new Conexao();
            string_comando = new StringBuilder();

        }

        public bool salvarTutor(Tutor tutor)
        {
            // comando de inserção para tutor
            string_comando.Clear();
            string_comando.Append("INSERT into tb_tutor ");
            string_comando.Append("(nome_tutor, cpf_tutor, celular_tutor, email_tutor) ");
            string_comando.Append("VALUES (@nome, @cpf, @celular, @email);");

            try
            {
                // adiciona os parametros da consulta
                conexao.comandoSql.Parameters.Clear(); // limpa os paramtros anteriores
                conexao.comandoSql.Parameters.AddWithValue("@nome", tutor.getNome());
                conexao.comandoSql.Parameters.AddWithValue("@cpf", tutor.getCpf());
                conexao.comandoSql.Parameters.AddWithValue("@celular", tutor.getTelefone());
                conexao.comandoSql.Parameters.AddWithValue("@email", tutor.getEmail());

                // modifica a string de consulta da classe conexão
                conexao.setStrComandoSql(string_comando.ToString());

                // executa o comando
                return conexao.executarComando() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool removerTutor(Cpf cpf)
        {
            // comando de remoção
            string_comando.Clear();
            string_comando.Append("DELETE FROM tb_tutor ");
            string_comando.Append("WHERE cpf_tutor = @cpf;");

            try
            {
                conexao.comandoSql.Parameters.Clear();
                conexao.comandoSql.Parameters.AddWithValue("@cpf", cpf.getCpf());
                conexao.setStrComandoSql(string_comando.ToString());
                
                return conexao.executarComando() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void listarTutores(DataGridView grid)
        {
            string_comando.Clear();
            string_comando.Append("SELECT ");
            string_comando.Append("nome_tutor as Nome, ");
            string_comando.Append("cpf_tutor as CPF, ");
            string_comando.Append("email_tutor as Email, ");
            string_comando.Append("celular_tutor as Contato ");
            string_comando.Append("FROM tb_tutor; ");

            try
            {
                conexao.comandoSql.Parameters.Clear();
                conexao.setStrComandoSql(string_comando.ToString());

                DataSet dados = conexao.getDataSet();
                DataTable tabela = dados.Tables[0];
                grid.DataSource = tabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Tutor buscarTutor(Cpf cpf, DataGridView grid)
        {
            // comando de localização
            string_comando.Clear();
            string_comando.Append("SELECT ");
            string_comando.Append("nome_tutor as Nome, ");
            string_comando.Append("cpf_tutor as CPF, ");
            string_comando.Append("email_tutor as Email, ");
            string_comando.Append("celular_tutor as Contato ");
            string_comando.Append("FROM tb_tutor ");
            string_comando.Append("WHERE cpf_tutor = @cpf;");

            try
            {
                conexao.comandoSql.Parameters.Clear();
                conexao.comandoSql.Parameters.AddWithValue("@cpf", cpf.getCpf());
                conexao.setStrComandoSql(string_comando.ToString());

                DataSet dados = conexao.getDataSet();
                DataTable tabela = dados.Tables[0];
                grid.DataSource = tabela;
                if (tabela.Rows.Count == 0)
                {
                    throw new Exception("Tutor não localizado na base de dados !!!");
                }

                DataRow linha = tabela.Rows[0];
                Nome nomeBanco = new Nome(linha["Nome"].ToString());
                Email emailBanco = new Email(linha["Email"].ToString());
                Telefone contatoBanco = new Telefone(linha["Contato"].ToString());

                Tutor tutor = new Tutor();
                tutor.setCpf(cpf);
                tutor.setNome(nomeBanco);
                tutor.setEmail(emailBanco);
                tutor.setTelefone(contatoBanco);

                return tutor;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
            
        public bool alterarTutor(Tutor tutor)
        {
            string_comando.Clear();

            string_comando.Append("UPDATE tb_tutor set ");
            string_comando.Append("nome_tutor = @nome, ");
            string_comando.Append("celular_tutor = @contato, ");
            string_comando.Append("email_tutor = @email ");
            string_comando.Append("WHERE cpf_tutor = @cpf");

            try
            {
                conexao.comandoSql.Parameters.Clear();
                conexao.comandoSql.Parameters.AddWithValue("@nome", tutor.getNome());
                conexao.comandoSql.Parameters.AddWithValue("@contato", tutor.getTelefone());
                conexao.comandoSql.Parameters.AddWithValue("@email", tutor.getEmail());
                conexao.comandoSql.Parameters.AddWithValue("@cpf", tutor.getCpf());

                conexao.setStrComandoSql(string_comando.ToString());
                return conexao.executarComando() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void limparTutor(TextBox campoCpf, TextBox campoNome, TextBox campoEmail, TextBox campoTelefone)
        {
            campoCpf.Text = "";
            campoNome.Text = "";
            campoEmail.Text = "";
            campoTelefone.Text = "";
        }
}
}
