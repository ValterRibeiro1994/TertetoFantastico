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
            comando.Append("raca_pet as 'Raça' ");
            comando.Append("where especie_pet = @especie;");

            try
            {
                conexao.comandoSql.Parameters.Clear();
                conexao.comandoSql.Parameters.AddWithValue("@especie", especie);
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
