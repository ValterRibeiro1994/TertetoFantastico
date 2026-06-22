using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
