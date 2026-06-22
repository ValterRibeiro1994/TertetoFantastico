using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public bool removerServico(CodigoBanco cod)
        {
            // comando de remoção
            comando.Clear();
            comando.Append("DELETE FROM tb_Servicos ");
            comando.Append("WHERE cod_pet = @cod;");

            try
            {
                conexao.comandoSql.Parameters.Clear();
                conexao.comandoSql.Parameters.AddWithValue("@cod", cod.getCodigo());
                conexao.setStrComandoSql(comando.ToString());

                return conexao.executarComando() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void listarServicoes(DataGridView grid)
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
                DataTable tabela = dados.Tables[0];
                grid.DataSource = tabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Servico buscarServico(CodigoBanco codigo, DataGridView grid)
        {
            // comando de localização
            comando.Clear();
            comando.Append("SELECT ");
            comando.Append("cod_pet as 'codigo do pet', ");
            comando.Append("tipo_servico as 'Tipo', ");
            comando.Append("data_servico as 'Data', ");
            comando.Append("valor_servico as 'Valor' ");
            comando.Append("FROM tb_Servicos ");
            comando.Append("WHERE cod_pet = @codigo;");

            try
            {
                conexao.comandoSql.Parameters.Clear();
                conexao.comandoSql.Parameters.AddWithValue("@codigo", codigo.getCodigo());
                conexao.setStrComandoSql(comando.ToString());

                DataSet dados = conexao.getDataSet();
                DataTable tabela = dados.Tables[0];
                grid.DataSource = tabela;
                if (tabela.Rows.Count == 0)
                {
                    throw new Exception("Servico não localizado na base de dados !!!");
                }

                DataRow linha = tabela.Rows[0];
                TipoServiço tipo = new TipoServiço(tipoString: linha["Tipo"].ToString());
                DataServico data = new DataServico(dataBanco: (DateTime)linha["Data"]);
                ValorServico valor = new ValorServico(valorString: linha["Valor"].ToString());

                Servico Servico = new Servico();
                Servico.setCodigo(codigo);
                Servico.setTipo(tipo);
                Servico.setData(data);
                Servico.setValor(valor);

                return Servico;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool alterarServico(Servico Servico)
        {
            comando.Clear();

            comando.Append("UPDATE tb_Servicos set ");
            comando.Append("tipo_Servico = @tipo, ");
            comando.Append("data_Servico = @data, ");
            comando.Append("valor_Servico = @valor ");
            comando.Append("WHERE cod_pet = @codigo");

            try
            {
                conexao.comandoSql.Parameters.Clear();
                conexao.comandoSql.Parameters.AddWithValue("@tipo", Servico.getTipo());
                conexao.comandoSql.Parameters.AddWithValue("@data", Servico.getData());
                conexao.comandoSql.Parameters.AddWithValue("valor", Servico.getValor());
                conexao.comandoSql.Parameters.AddWithValue("@codigo", Servico.getCodigo());

                conexao.setStrComandoSql(comando.ToString());
                return conexao.executarComando() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void limparServico(TextBox campoCodigo, ComboBox campoTipo, DateTimePicker campoData, TextBox campoValor)
        {
            campoCodigo.Text = "";
            campoTipo.SelectedItem = null;
            campoData.Value = DateTime.Now;
            campoValor.Text = "";
        }
    }
}
