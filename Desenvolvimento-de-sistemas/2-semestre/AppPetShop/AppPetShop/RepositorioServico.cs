using System;
using System.Data;
using System.Text;

namespace AppPetShop
{
    internal class RepositorioServico
    {
        private Conexao conexao;
        private StringBuilder comando;

        public RepositorioServico()
        {
            conexao = new Conexao();
            comando = new StringBuilder();
        }

        public bool salvarServico(Servico servico)
        {
            // comando de inserção para Servico
            comando.Clear();
            comando.Append("INSERT into tb_servicos ");
            comando.Append("(cod_pet,tipo_servico,data_servico,valor_servico) ");
            comando.Append("VALUES (@codigo, @tipo, @data, @valor);");

            try
            {
                // adiciona os parametros da consulta
                conexao.comandoSql.Parameters.Clear(); // limpa os paramtros anteriores
                conexao.comandoSql.Parameters.AddWithValue("@codigo", servico.getCodigo());
                conexao.comandoSql.Parameters.AddWithValue("@tipo", servico.getTipo());
                conexao.comandoSql.Parameters.AddWithValue("@data", servico.getData());
                conexao.comandoSql.Parameters.AddWithValue("@valor", servico.getValor());

                // modifica a string de consulta da classe conexão
                conexao.setStrComandoSql(comando.ToString());

                // executa o comando
                return conexao.executarComando() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool removerServico(CodigoBanco id)
        {
            // comando de remoção
            comando.Clear();
            comando.Append("DELETE FROM tb_Servicos ");
            comando.Append("WHERE id_servico = @id");

            try
            {
                conexao.comandoSql.Parameters.Clear();
                conexao.comandoSql.Parameters.AddWithValue("@id", id.getCodigo());
                conexao.setStrComandoSql(comando.ToString());

                return conexao.executarComando() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable listarServicos()
        {
            comando.Clear();
            comando.Append("SELECT ");
            comando.Append("id_servico as 'ID serviço', ");
            comando.Append("cod_pet as 'codigo do pet', ");
            comando.Append("tipo_servico as Tipo, ");
            comando.Append("data_servico as Data, ");
            comando.Append("valor_servico as Valor ");
            comando.Append("FROM tb_Servicos; ");

            try
            {
                conexao.comandoSql.Parameters.Clear();
                conexao.setStrComandoSql(comando.ToString());

                DataSet dados = conexao.getDataSet();
                return dados.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable buscarServicosPet(CodigoBanco codigoPet)
        {
            // comando de localização
            comando.Clear();
            comando.Append("SELECT ");
            comando.Append("id_servico as 'ID serviço', ");
            comando.Append("cod_pet as 'codigo do pet', ");
            comando.Append("tipo_servico as Tipo, ");
            comando.Append("data_servico as Data, ");
            comando.Append("valor_servico as Valor ");
            comando.Append("FROM tb_servicos ");
            comando.Append("WHERE cod_pet = @codigo");

            try
            {
                conexao.comandoSql.Parameters.Clear();
                conexao.comandoSql.Parameters.AddWithValue("@codigo", codigoPet.getCodigo());
                conexao.setStrComandoSql(comando.ToString());

                DataSet dados = conexao.getDataSet();
                return dados.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool alterarServico(Servico Servico)
        {
            /*
                Metodo getCodigo está recebendo o ID do serviço no FormBuscarServiços
             */
            comando.Clear();
            comando.Append("UPDATE tb_Servicos set ");
            comando.Append("tipo_Servico = @tipo, ");
            comando.Append("data_Servico = @data, ");
            comando.Append("valor_Servico = @valor ");
            comando.Append("WHERE id_servico = @id");

            try
            {
                conexao.comandoSql.Parameters.Clear();
                conexao.comandoSql.Parameters.AddWithValue("@tipo", Servico.getTipo());
                conexao.comandoSql.Parameters.AddWithValue("@data", Servico.getData());
                conexao.comandoSql.Parameters.AddWithValue("@valor", Servico.getValor());
                conexao.comandoSql.Parameters.AddWithValue("@id", Servico.getCodigo());

                conexao.setStrComandoSql(comando.ToString());
                return conexao.executarComando() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int obterUltimoId()
        {
            comando.Clear();
            comando.Append("SELECT id_servico FROM tb_servicos ORDER BY id_servico DESC");

            try
            {
                conexao.comandoSql.Parameters.Clear();
                conexao.setStrComandoSql(comando.ToString());

                DataSet dados = conexao.getDataSet();

                // Verifica se o banco retornou alguma linha (se a tabela não estiver vazia)
                if (dados.Tables[0].Rows.Count > 0)
                {
                    // Pega o valor da primeira linha (índice 0) e primeira coluna (índice 0)
                    return Convert.ToInt32(dados.Tables[0].Rows[0][0]);
                }
                else
                {
                    // Retorna 0 caso a tabela esteja completamente vazia
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter o último ID: " + ex.Message);
            }
        }
    }
}