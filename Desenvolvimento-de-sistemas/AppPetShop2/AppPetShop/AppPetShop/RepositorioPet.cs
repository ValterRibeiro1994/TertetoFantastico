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

        public Pet buscarPetCodigo(CodigoBanco codigo)
        {
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
                conexao.comandoSql.Parameters.AddWithValue("@codigo", codigo.getCodigo());

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
                CodigoBanco codigoPet = new CodigoBanco(linha["Código"].ToString());
                Cpf cpfTutor = new Cpf(linha["CPF Tutor"].ToString());
                DateTime dataNascimento = (DateTime)linha["nascimento_pet"];
                string genero = linha["Genero"].ToString();
                Nome raca = new Nome(linha["Raça"].ToString());
                Nome nome = new Nome(linha["Nome"].ToString());
                Nome especie = new Nome(linha["Especie"].ToString());
                byte[] foto = (byte[]) linha["Foto"];

                Pet pet = new Pet();
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
