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

        public DataTable buscarConsultas()
        {
            comando.Clear();
            comando.Append("SELECT tb_consulta.cod_pet as 'codigo do pet', ");
            comando.Append("nome_pet as 'nome do pet', ");
            comando.Append("nome_tutor as 'Nome do tutor', ");
            comando.Append("data_consulta as 'data da consulta', ");
            comando.Append("prescricao_consulta as 'Prescrição' ");
            comando.Append("FROM tb_pet ");
            comando.Append("INNER JOIN tb_tutor ON tb_tutor.cpf_tutor = tb_pet.cpf_tutor ");
            comando.Append("INNER JOIN tb_consulta ON tb_consulta.cod_pet = tb_pet.cod_pet;");

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

        public DataTable buscarPetTutor()
        {
            comando.Clear();
            comando.Append("SELECT nome_tutor as 'Nome do Tutor', ");
            comando.Append("celular_tutor as 'Celular', ");
            comando.Append("nome_pet as 'Nome do Pet', ");
            comando.Append("genero_pet as 'Gênero', ");
            comando.Append("raca_pet as 'Raça' ");
            comando.Append("FROM tb_pet ");
            comando.Append("INNER JOIN tb_tutor ON tb_pet.cpf_tutor = tb_tutor.cpf_tutor;");

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

        public DataTable ordenarPetNascimento()
        {
            comando.Clear();
            comando.Append("SELECT nome_pet as 'Nome do Pet', ");
            comando.Append("nascimento_pet as 'Data de nascimento', ");
            comando.Append("nome_tutor as 'Nome do tutor' ");
            comando.Append("FROM tb_pet ");
            comando.Append("INNER JOIN tb_tutor ON tb_pet.cpf_tutor = tb_tutor.cpf_tutor ");
            comando.Append("ORDER BY nascimento_pet;");

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

        public DataTable buscarData(Data data)
        {
            comando.Clear();
            comando.Append("SELECT ");
            comando.Append("tipo_servico as 'Tipo', ");
            comando.Append("data_servico as 'Data', ");
            comando.Append("nome_tutor as 'Tutor', ");
            comando.Append("nome_pet as 'Nome' ");
            comando.Append("FROM tb_pet ");
            comando.Append("INNER JOIN tb_tutor on tb_pet.cpf_tutor = tb_tutor.cpf_tutor ");
            comando.Append("INNER JOIN tb_servicos on tb_servicos.cod_pet = tb_pet.cod_pet ");
            comando.Append("WHERE data_servico = @data ");
            comando.Append("ORDER BY nome_tutor ");
            comando.Append("ASC");

            try
            {
                conexao.comandoSql.Parameters.Clear();
                conexao.comandoSql.Parameters.AddWithValue("@data", data.getData().Date);
                conexao.setStrComandoSql(comando.ToString());
                DataSet dados = conexao.getDataSet();
                return dados.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable buscarServico(TipoServiço servico)
        {
            comando.Clear();
            comando.Append("SELECT ");
            comando.Append("tipo_servico as 'Tipo', ");
            comando.Append("data_servico as 'Data', ");
            comando.Append("nome_tutor as 'Tutor', ");
            comando.Append("nome_pet as 'Nome' ");
            comando.Append("FROM tb_pet ");
            comando.Append("INNER JOIN tb_tutor on tb_pet.cpf_tutor = tb_tutor.cpf_tutor ");
            comando.Append("INNER JOIN tb_servicos on tb_servicos.cod_pet = tb_pet.cod_pet ");
            comando.Append("WHERE tipo_servico = @servico ");
            comando.Append("ORDER BY nome_tutor ");
            comando.Append("ASC");

            try
            {
                conexao.comandoSql.Parameters.Clear();
                conexao.comandoSql.Parameters.AddWithValue("@servico", servico.getTipo());
                conexao.setStrComandoSql(comando.ToString());
                DataSet dados = conexao.getDataSet();
                return dados.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable BuscarEspecie(Texto especie)
        {
            comando.Clear();
            comando.Append("SELECT nome_pet as 'Nome', ");
            comando.Append("especie_pet as 'Especie', ");
            comando.Append("raca_pet as 'Raça' ");
            comando.Append("FROM tb_pet ");
            comando.Append("WHERE especie_pet = @especie; ");

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
            comando.Append("ORDER BY nome_tutor, nome_pet ASC;");

            try
            {
                conexao.comandoSql.Parameters.Clear();
                conexao.comandoSql.Parameters.AddWithValue("@tipo", servico.getTipo());
                conexao.comandoSql.Parameters.AddWithValue("@data", data.getData().Date);

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