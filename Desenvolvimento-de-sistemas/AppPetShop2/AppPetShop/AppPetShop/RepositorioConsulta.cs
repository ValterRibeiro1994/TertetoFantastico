using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            comando.Append("(id_consulta, cod_pet, data_consulta, prescricao_consulta) ");
            comando.Append("VALUES (@id,@codigo, @data, @desc);");
            try
            {
                // adiciona os parametros da consulta
                conexao.comandoSql.Parameters.Clear(); // limpa os paramtros anteriores
                conexao.comandoSql.Parameters.AddWithValue("@id", consulta.getId());
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

        public void listarConsultas(DataGridView grid)
        {
            // comando de consulta
            comando.Clear();
            comando.Append("SELECT id_consulta, cod_pet, data_consulta, prescricao_consulta ");
            comando.Append("FROM tb_consulta;");
            try
            {
                conexao.comandoSql.Parameters.Clear();
                conexao.setStrComandoSql(comando.ToString());

                DataSet dados = conexao.getDataSet();
                DataTable tabela = dados.Tables[0];
                grid.DataSource = tabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Consulta buscarConsulta(CodigoBanco id, DataGridView grid)
        {
            comando.Clear();
            comando.Append("Select id_consulta as 'Numero da consulta', cod_pet as 'Codigo do pet', data_consulta as Data, prescricao_consulta as Prescrição");
            comando.Append(" from tb_consulta where id_consulta = @id;");

            try
            {
                conexao.comandoSql.Parameters.Clear();
                conexao.comandoSql.Parameters.AddWithValue("@id", id.getCodigo());
                conexao.setStrComandoSql(comando.ToString());

                DataSet dados = conexao.getDataSet();
                DataTable tabela = dados.Tables[0];
                grid.DataSource = tabela;
                if (tabela.Rows.Count == 0)
                {
                    throw new Exception("Consulta não localizado na base de dados !!!");
                }

                DataRow linha = tabela.Rows[0];
                CodigoBanco codigoPet = new CodigoBanco(linha["Codigo do pet"].ToString());
                DataConsulta data = new DataConsulta(dataBanco: (DateTime)linha["Data"]);
                DescConsulta desc = new DescConsulta(linha["Prescrição"].ToString());

                Consulta Consulta = new Consulta();
                Consulta.setId(id);
                Consulta.setCodigo(codigoPet);                
                Consulta.setData(data);
                Consulta.setDesc(desc);

                return Consulta;
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
            comando.Append("cod_pet = @cod, ");
            comando.Append("data_consulta = @data, ");
            comando.Append("prescricao_consulta = @desc ");
            comando.Append("WHERE id_consulta = @id");

            try
            {
                conexao.comandoSql.Parameters.Clear();
                conexao.comandoSql.Parameters.AddWithValue("@id", consulta.getId());
                conexao.comandoSql.Parameters.AddWithValue("@cod", consulta.getCodigo());
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

        public void limparConsulta(TextBox campoId, TextBox campoCod, DateTimePicker campoData, TextBox campoDescr)
        {
            campoId.Text = "";
            campoCod.Text = "";
            campoData.Value = DateTime.Now;
            campoDescr.Text = "";
        }
    }
}
