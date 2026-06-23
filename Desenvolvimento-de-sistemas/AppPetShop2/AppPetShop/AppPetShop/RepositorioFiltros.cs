using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            comando.Append("select nome_pet as 'Nome', ");
            comando.Append("especie_pet as 'Especie', ");
            comando.Append("raca_pet as 'Raça' ");
            comando.Append("from tb_pet ");
            comando.Append("where especie_pet = '@especie';");

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

        public DataTable BuscarTipoData(TipoServiço Tipo, Data data)
        {
            comando.Clear();
            comando.Append("select tipo_servico as 'Tipo', data_servico as 'Data', nome_tutor as 'Tutor', nome_pet as 'Nome' ");
            comando.Append("from tb_pet ");
            comando.Append("inner join tb_tutor on tb_pet.cpf_tutor = tb_tutor.cpf_tutor ");
            comando.Append("inner join tb_servico on tb_servico.cod_pet = tb_pet.cod_pet ");
            comando.Append("where (tipo_servico = @tipo && data_servico = @data) order by nome_tutor,nome_pet asc;");

            try
            {
                conexao.comandoSql.Parameters.Clear();
                conexao.comandoSql.Parameters.AddWithValue("@tipo", Tipo);
                conexao.comandoSql.Parameters.AddWithValue("@data", data);
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
