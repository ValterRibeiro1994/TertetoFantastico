using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

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

        public bool removerPet(CodigoBanco codigo)
        {
            comandoSql.Clear();
            comandoSql.Append("DELETE FROM tb_pet ");
            comandoSql.Append("WHERE cod_pet = @codigo;");
            try
            {
                conexao.comandoSql.Parameters.Clear();
                conexao.comandoSql.Parameters.AddWithValue("@codigo", codigo.getCodigo());
                conexao.setStrComandoSql(comandoSql.ToString());
                return conexao.executarComando() > 0;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool cadastrarPet(Pet pet)
        {
            comandoSql.Clear();
            comandoSql.Append("INSERT INTO tb_pet(cpf_tutor, nascimento_pet, genero_pet, raca_pet, foto_pet, nome_pet, especie_pet) ");
            comandoSql.Append("VALUES (@cpf, @data, @genero, @raca, @foto, @nome, @especie) ");

            try
            {
                // classe de conexão
                conexao.comandoSql.Parameters.Clear();
                conexao.comandoSql.Parameters.AddWithValue("@cpf", pet.getCpf());
                conexao.comandoSql.Parameters.AddWithValue("@data", pet.getNascimento());
                conexao.comandoSql.Parameters.AddWithValue("@genero", pet.getGenero());
                conexao.comandoSql.Parameters.AddWithValue("@raca", pet.getRaca());
                conexao.comandoSql.Parameters.AddWithValue("@foto", pet.getFoto());
                conexao.comandoSql.Parameters.AddWithValue("@nome", pet.getNome());
                conexao.comandoSql.Parameters.AddWithValue("@especie", pet.getEspecie());

                // modifica a string de colsulta da classe conexão
                conexao.setStrComandoSql(comandoSql.ToString());
                return conexao.executarComando() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable listarPet()
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

            try
            {
                // limpa os parametros anteriores da conexão
                conexao.comandoSql.Parameters.Clear();

                // adiciona a string de comando na conexão
                conexao.setStrComandoSql(comandoSql.ToString());

                DataSet dados = conexao.getDataSet();
                DataTable tabela = dados.Tables[0];
                return tabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable buscarPetCpf(Cpf cpf)
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
            comandoSql.Append("WHERE cpf_tutor = @cpf;");

            try
            {
                // limpa os parametros anteriores da conexão
                conexao.comandoSql.Parameters.Clear();

                // adiciona o cpf como parametro na conexão
                conexao.comandoSql.Parameters.AddWithValue("@cpf", cpf.getCpf());

                // adiciona a string de comando na conexão
                conexao.setStrComandoSql(comandoSql.ToString());

                DataSet dados = conexao.getDataSet();
                DataTable tabela = dados.Tables[0];
                return tabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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
                    throw new Exception("Pet não encontrado na base de dados");
                }

                // captura os dados
                DataRow linha = tabelaDados.Rows[0];
                CodigoBanco codigoPet = new CodigoBanco(linha["Código"].ToString());
                Cpf cpfTutor = new Cpf(linha["CPF Tutor"].ToString());
                DateTime dataNascimento = (DateTime)linha["Data de nascimento"];
                string genero = linha["Genero"].ToString();
                Texto raca = new Texto(linha["Raça"].ToString());
                Texto nome = new Texto(linha["Nome"].ToString());
                Texto especie = new Texto(linha["Especie"].ToString());
                byte[] foto = (byte[])linha["Foto"];

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
        public void buscarPets(DataGridView grid)
        {
            comandoSql.Clear();
            comandoSql.Append("SELECT ");
            comandoSql.Append("cod_pet as 'Código', ");
            comandoSql.Append("cpf_tutor as 'CPF Tutor', ");
            comandoSql.Append("nascimento_pet as 'Data de nascimento', ");
            comandoSql.Append("genero_pet as 'Genero', ");
            comandoSql.Append("raca_pet as 'Raça', ");
            comandoSql.Append("nome_pet as 'Nome', ");
            comandoSql.Append("especie_pet as 'Especie', ");
            comandoSql.Append("foto_pet as 'Foto' ");
            comandoSql.Append("FROM tb_pet; ");

            try
            {
                conexao.comandoSql.Parameters.Clear();
                conexao.setStrComandoSql(comandoSql.ToString());

                DataSet dados = conexao.getDataSet();
                DataTable tabela = dados.Tables[0];
                grid.DataSource = tabela;

                DataSet conjuntoDeDados = conexao.getDataSet();

                // monta a tabela de dados
                DataTable tabelaDados = conjuntoDeDados.Tables[0];

                // verificar se teve retorno
                if (tabelaDados.Rows.Count == 0)
                {
                    throw new Exception("Pet não encontrado na base de dados");
                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool editarPet(Pet pet)
        {
            comandoSql.Clear();
            comandoSql.Append("UPDATE tb_pet SET ");
            comandoSql.Append("nascimento_pet = @nascimento_pet, ");
            comandoSql.Append("genero_pet = @genero_pet, ");
            comandoSql.Append("raca_pet = @raca_pet, ");
            comandoSql.Append("nome_pet = @nome_pet, ");
            comandoSql.Append("especie_pet = @especie_pet, ");
            comandoSql.Append("foto_pet = @foto_pet ");
            comandoSql.Append("where cod_pet = @cod_pet");

            try
            {
                conexao.comandoSql.Parameters.Clear();
                conexao.comandoSql.Parameters.AddWithValue("@nascimento_pet", pet.getNascimento());
                conexao.comandoSql.Parameters.AddWithValue("@genero_pet", pet.getGenero());
                conexao.comandoSql.Parameters.AddWithValue("@raca_pet", pet.getRaca());
                conexao.comandoSql.Parameters.AddWithValue("@nome_pet", pet.getNome());
                conexao.comandoSql.Parameters.AddWithValue("@especie_pet", pet.getEspecie());
                conexao.comandoSql.Parameters.AddWithValue("@foto_pet", pet.getFoto());
                conexao.comandoSql.Parameters.AddWithValue("@cod_pet", pet.getCodigo());
                conexao.setStrComandoSql(comandoSql.ToString());
                return conexao.executarComando() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
