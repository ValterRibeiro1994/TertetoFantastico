using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPetShop
{
    internal class RepositorioPet
    {
        Conexao conexao;
        StringBuilder comandoSql;
        Pet pet;

        public RepositorioPet()
        {
            conexao = new Conexao();
            pet = null;
            comandoSql = new StringBuilder();
        }

        public Pet buscarPetCodigo(string codigo)
        {
            pet = new Pet();

            // Validar Código de Pet
            try
            {
                pet.setCodigo(codigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            // Criar comando de busca
            comandoSql.Clear();
            // insere o comando de busca
            comandoSql.Append("SELECT ");
            comandoSql.Append("cod_pet as 'Código', ");
            comandoSql.Append("cpf_tutor as 'CPF Tutor', ");
            comandoSql.Append("nascimento_pet as 'Data de nascimento', ");
            comandoSql.Append("genero_pet as 'Genero', ");
            comandoSql.Append("raca_pet as 'Raça', ");
            comandoSql.Append("nome_pet as 'Nome', ");
            comandoSql.Append("especie_pet as 'Especie', ");
            comandoSql.Append("foto_pet as 'Foto' ");
            comandoSql.Append("FROM tb_pet ");
            comandoSql.Append("WHERE cod_pet = @codigo;");

            try
            {
                // limpa os parametros anteriores da conexão
                conexao.comandoSql.Parameters.Clear();

                // adiciona o cpf como parametro na conexão
                conexao.comandoSql.Parameters.AddWithValue("@cpf", getCpf());

                // adiciona a string de comando na conexão
                conexao.setStrComandoSql(comandoSql.ToString());

                // captura os dados retornados
                DataSet conjuntoDeDados = conexao.getDataSet();

                // monta a tabela de dados
                DataTable tabelaDados = conjuntoDeDados.Tables[0];

                // captura os dados

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
