using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            // comando de inserção para tutor
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
    }
}
