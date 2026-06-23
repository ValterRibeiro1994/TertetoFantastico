using System;
using System.Data;
using System.Text;

namespace AppPetShop
{
    internal class RepositorioFiltros
    {
        private Conexao conexao;
        private StringBuilder comando;

        public RepositorioFiltros()
        {
            conexao = new Conexao();
            comando = new StringBuilder();
        }

        public DataTable BuscarEspecie(Texto especie)
        {
            comando.Clear();
            comando.Append("select nome_pet as 'Nome',");
            comando.Append("especie_pet as 'Especie', ");
            comando.Append("raca_pet as 'Raça' FROM tb_pet ");
            comando.Append("where especie_pet = @especie;");

            try
            {
                conexao.comandoSql.Parameters.Clear();
                conexao.comandoSql.Parameters.AddWithValue("@especie", especie.getTexto());
                conexao.setStrComandoSql(comando.ToString());

                DataSet dados = conexao.getDataSet();
                return dados.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
            public DataTable buscarDataServico(Data data, TipoServiço servico)
        {
            comando.Clear();

            comando.Append("SELECT ");
            comando.Append("tipo_servico AS 'Tipo', ");
            comando.Append("data_servico AS 'Data', ");
            comando.Append("nome_tutor AS 'Tutor', ");
            comando.Append("nome_pet AS 'Nome' ");

            comando.Append("FROM tb_pet ");

            comando.Append("INNER JOIN tb_tutor ");
            comando.Append("ON tb_pet.cpf_tutor = tb_tutor.cpf_tutor ");

            comando.Append("INNER JOIN tb_servicos ");
            comando.Append("ON tb_servicos.cod_pet = tb_pet.cod_pet ");

            comando.Append("WHERE tipo_servico = @tipo ");
            comando.Append("AND data_servico = @data ");

            comando.Append("ORDER BY nome_tutor, nome_pet ASC");

            try
            {
                conexao.comandoSql.Parameters.Clear();

                conexao.comandoSql.Parameters.AddWithValue("@tipo", servico.getTipo());
                conexao.comandoSql.Parameters.AddWithValue("@data", data.getData());

                conexao.setStrComandoSql(comando.ToString());

                DataSet dados = conexao.getDataSet();

                return dados.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
    }

