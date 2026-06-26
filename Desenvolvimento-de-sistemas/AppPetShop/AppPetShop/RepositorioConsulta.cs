using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace AppPetShop
{
    internal class RepositorioConsulta
    {
        private Conexao conexao;
        private StringBuilder comando;

        public RepositorioConsulta()
        {
            conexao = new Conexao();
            comando = new StringBuilder();
        }

        public bool salvarConsulta(Consulta consulta)
        {
            // comando de inserção para Consulta
            comando.Clear();
            comando.Append("INSERT into tb_consulta ");
            comando.Append("(cod_pet, data_consulta, prescricao_consulta) ");
            comando.Append("VALUES (@codigo, @data, @desc);");
            try
            {
                // adiciona os parametros da consulta
                conexao.comandoSql.Parameters.Clear(); // limpa os paramtros anteriores
                conexao.comandoSql.Parameters.AddWithValue("@codigo", consulta.getCodigo());
                conexao.comandoSql.Parameters.AddWithValue("@data", consulta.getData());
                conexao.comandoSql.Parameters.AddWithValue("@desc", consulta.getDesc());
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

        public bool removerConsulta(CodigoBanco id)
        {
            // comando de remoção
            comando.Clear();
            comando.Append("DELETE FROM tb_consulta ");
            comando.Append("WHERE id_consulta = @id;");
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

        public DataTable listarConsultas()
        {
            // comando de consulta
            comando.Clear();
            comando.Append("SELECT id_consulta as 'Id Consulta', cod_pet as 'Código Pet', data_consulta as 'Data', prescricao_consulta as 'Preescrição' ");
            comando.Append("FROM tb_consulta;");
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

        public DataTable buscarConsultaPet(CodigoBanco codigoPet)
        {
            comando.Clear();
            comando.Append("Select id_consulta as 'ID consulta', cod_pet as 'Codigo do pet', data_consulta as Data, prescricao_consulta as Prescrição");
            comando.Append(" from tb_consulta where cod_pet = @codigoPet");

            try
            {
                conexao.comandoSql.Parameters.Clear();
                conexao.comandoSql.Parameters.AddWithValue("@codigoPet", codigoPet.getCodigo());
                conexao.setStrComandoSql(comando.ToString());

                DataSet dados = conexao.getDataSet();
                return dados.Tables[0];

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool alterarConsulta(Consulta consulta)
        {
            comando.Clear();

            comando.Append("UPDATE tb_consulta set ");
            comando.Append("data_consulta = @data, ");
            comando.Append("prescricao_consulta = @desc ");
            comando.Append("WHERE id_consulta = @id");

            try
            {
                conexao.comandoSql.Parameters.Clear();
                conexao.comandoSql.Parameters.AddWithValue("@id", consulta.getCodigo());
                conexao.comandoSql.Parameters.AddWithValue("@data", consulta.getData());
                conexao.comandoSql.Parameters.AddWithValue("@desc", consulta.getDesc());


                conexao.setStrComandoSql(comando.ToString());
                return conexao.executarComando() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
