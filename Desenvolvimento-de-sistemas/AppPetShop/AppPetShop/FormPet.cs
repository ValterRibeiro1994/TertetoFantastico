using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
namespace AppPetShop
{
    public partial class FormPet : Form
    {
        /*
         Usar o modelo de getters e setter do mesmo modo que em formTutor, 
         */
        private string nome, cpf, genero, raca, especie;
        Utilidades utils;
        StringBuilder comandoSql;
        Conexao conexao;
        /*
         Construtor
         */
        public FormPet()
        {
            InitializeComponent();
            utils = new Utilidades();
            comandoSql = new StringBuilder();
            conexao = new Conexao();
        }

        /*
         Botões de formulario
         */
        private void btnFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog cxFoto = new OpenFileDialog();
            cxFoto.Title = "Selecione Imagem";
            cxFoto.Filter = "Imagens|*.jpg;*.jpeg;*.png;*.gif";
            if (cxFoto.ShowDialog() == DialogResult.OK)
            {
                inputFoto.ImageLocation = cxFoto.FileName;
            }
        }

        private void btnCadastrarPet_Click(object sender, EventArgs e)
        {
            try
            {
                setCpf(inputCpf.Text);
                setNomePet(inputNome.Text);
                setGenero(rdMacho, rdFemea);
                setRaca(inputRaca.Text);
                setEspecie(inputEspecie.Text);
                setCaminhoFoto(inputFoto.ImageLocation);
            }
            catch (Exception ex)
            {
                utils.notificarUsuario(ex.Message);
                return; // encerra o processo antes de enviar dados para o banco
            }

            // converter foto para bytes
            byte[] fotoPet = File.ReadAllBytes(inputFoto.ImageLocation);

            // comando de inserção na tabela de pets
            comandoSql.Remove(0, comandoSql.Length);
            comandoSql.Append("INSERT INTO tb_pet(cpf_tutor, nascimento_pet, genero_pet, raca_pet, foto_pet, nome_pet, especie_pet) ");
            comandoSql.Append("VALUES (@cpf, @data, @genero, @raca, @foto, @nome, @especie) ");
            
            try
            {
                // classe de conexão
                conexao.comandoSql.Parameters.Clear();
                conexao.comandoSql.Parameters.AddWithValue("@cpf", this.cpf);
                conexao.comandoSql.Parameters.AddWithValue("@data", inputNascimento.Value);
                conexao.comandoSql.Parameters.AddWithValue("@genero", this.genero);
                conexao.comandoSql.Parameters.AddWithValue("@raca", this.raca);
                conexao.comandoSql.Parameters.AddWithValue("@foto", fotoPet);
                conexao.comandoSql.Parameters.AddWithValue("@nome", this.nome);
                conexao.comandoSql.Parameters.AddWithValue("@especie", this.especie);

                // modifica a string de colsulta da classe conexão
                conexao.setStrComandoSql(comandoSql.ToString());
                if (conexao.executarComando() != 0)
                {
                    utils.notificarUsuario("Pet adicionado com sucesso");
                }
                else
                {
                    utils.notificarUsuario("Falha ao adicionar Pet");
                }
            } catch (Exception erro)
            {
                utils.notificarUsuario(erro.Message);
            }
            
        }

        /*
            Getters e setter abaixo - adicionar metodos de eventos e botoes acima desses comentarios
         */

        private void setCaminhoFoto(string caminho)
        {
            if (utils.campoVazio(caminho))
            {
                throw new Exception("Foto do pet é obrigatorio ");
            } 
        }

        private void setEspecie(string especie)
        {
            if (utils.campoVazio(especie))
            {
                throw new Exception("Informe a especie do Pet");
            }
            else if (utils.limiteTexto(30, especie))
            {
                throw new Exception("Limite de caracteres para especie excedido");
            }
            else
            {
                this.especie = especie;
            }
        }

        private void setRaca(string raca)
        {
            if (utils.campoVazio(raca))
            {
                throw new Exception("Informe a raça do pet");
            } else if (utils.limiteTexto(30, raca))
            {
                throw new Exception("Limite de caracteres excedido para raça do pet");
            } else
            {
                this.raca = raca;
            }

        }
        private void setGenero(RadioButton macho, RadioButton femea)
        {
            if (macho.Checked)
            {
                this.genero = "M";
            } else if (femea.Checked)
            {

                this.genero = "F";
            } else
            {
                throw new Exception("Informe o genero do Pet macho ou femea !!!");
            }
        }

        private void setCpf(string cpf)
        {
            if (utils.campoVazio(cpf))
            {
                throw new Exception("Cpf deve ser preenchido !!!");
            } else if (utils.totalCaracteres(11, cpf))
            {
                throw new Exception("Cpf deve ter 11 caracteres");
            } else
            {
                this.cpf = cpf;
            }
        }

        private void setNomePet(string nomePet)
        {
            if (utils.campoVazio(nomePet)){
                throw new Exception("Nome do pet deve ser informado");
            } else if (utils.limiteTexto(30, nomePet)){
                throw new Exception("Limite de caracteres excedido para nome do Pet");
            } else
            {
                this.nome = nomePet;
            }
        }

    }
}
