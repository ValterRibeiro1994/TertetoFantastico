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
                conexao.comandoSql.Parameters.AddWithValue("@codigo", codigo);

                // adiciona a string de comando na conexão
                conexao.setStrComandoSql(comandoSql.ToString());

                // captura os dados retornados
                DataSet conjuntoDeDados = conexao.getDataSet();

                // monta a tabela de dados
                DataTable tabelaDados = conjuntoDeDados.Tables[0];

                // verificar se teve retorno
                if (tabelaDados.Rows.Count == 0)
                {
                    throw new Exception("Código não encontrado na base de dados");
                }

                // captura os dados
                DataRow linha = tabelaDados.Rows[0];
                string codigoPet = linha["Código"].ToString();
                string cpfTutor = linha["CPF Tutor"].ToString();
                DateTime dataNascimento = (DateTime)linha["nascimento_pet"];
                string genero = linha["Genero"].ToString();
                string raca = linha["Raça"].ToString();
                string nome = linha["Nome"].ToString();
                string especie = linha["Especie"].ToString();
                byte[] foto = (byte[]) linha["Foto"];

                pet.setCodigo(codigoPet);
                pet.setCpfTutor(cpfTutor);
                pet.setNascimento(dataNascimento);
                pet.setGenero(genero[0]);
                pet.setRaca(raca);
                pet.setNomePet(nome);
                pet.setEspecie(especie);
                pet.setFoto(foto);

                // retorna o objeto preenchido
                return pet;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
