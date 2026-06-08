using System;
using System.Text;
using System.Windows.Forms;

namespace AppPetShop
{
    public partial class FormTutor : Form
    {
        // define as propriedades da classe
        private String nome, cpf, celular, email;
        private Utilidades utils;
        private StringBuilder comandoSql;
        private Conexao conexao;

        // método construtor
        public FormTutor()
        {
            
            InitializeComponent();
            utils = new Utilidades(); //classe utilitaria para reutilização de´processos 
            comandoSql = new StringBuilder(); // classe para comandos sql
            conexao = new Conexao(); // classe de conexão com banco de dados
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                // captura e valida as entradas antes delas serem definidas
                // lança erro caso alguma não passe pelas regras definidas
                setNome(inputNome.Text);
                setCpf(inputCpf.Text);
                setCelular(inputCelular.Text);
                setEmail(inputEmail.Text);
            }
            catch (Exception ex)
            {
                // acrescentar validações de erros para codigos de erro no banco
                // valores duplicados 
                utils.notificarUsuario(ex.Message);
                return;
            }

            try
            {
                // aqui criamos a consulta
                comandoSql.Remove(0, comandoSql.Length); // limpa a string de consulta atual
                comandoSql.Append("USE petshop_db; "); // seleciona o banco a ser usado
                comandoSql.Append("INSERT INTO tb_tutor"); // insere na tabela tutor
                comandoSql.Append("(nome_tutor, cpf_tutor, celular_tutor, email_tutor) "); // colunas da tabela
                comandoSql.Append("VALUES (@nome, @cpf, @celular, @email);"); // valores da tabela

                // adiciona os parametros da consulta
                conexao.comandoSql.Parameters.Clear(); // limpa os paramtros anteriores
                conexao.comandoSql.Parameters.AddWithValue("@nome", getNome());
                conexao.comandoSql.Parameters.AddWithValue("@cpf", getCpf());
                conexao.comandoSql.Parameters.AddWithValue("@celular", getcelular());
                conexao.comandoSql.Parameters.AddWithValue("@email", getEmail());

                // modifica a string de consulta da classe conexão
                conexao.setStrComandoSql(comandoSql.ToString());

                // executa o comando
                if (conexao.executarComando() > 0)
                {
                    utils.notificarUsuario("Tutor cadastrado com sucesso !!!");
                }
                else
                {
                    utils.notificarUsuario("Tutor não cadastrado no banco de dados");
                }

            }
            catch (Exception ex)
            {
                utils.notificarUsuario(ex.Message);
            }
            
        }
        
        private String getNome()
        {
            return nome;
        }

        private String getCpf()
        {
            return cpf;
        }

        private String getcelular()
        {
            return celular;
        }

        private String getEmail()
        {
            return email;
        }

        /*
         Setter validam as regras de entrada, antes de armazenar os valores
         */
        private void setNome(String nomeTutor)
        {
            if (utils.campoVazio(nomeTutor))
            {
                throw new Exception("Campo nome Obrigatorio !!!");
            } else if (utils.limiteTexto(80, nomeTutor))
            {
                throw new Exception("Limite de caracteres excedido para nome do tutor");
            } else
            {
                this.nome = nomeTutor;
            }
        }

        private void setCpf(String cpfTutor)
        {
            if (utils.campoVazio(cpfTutor))
            {
                throw new Exception("Campo cpf Obrigatorio !!!");
            }
            else if (utils.totalCaracteres(11, cpfTutor))
            {
                throw new Exception("Cpf deve ter 11 Caracteres !!!");
            }
            else
            {
                this.cpf = cpfTutor;
            }
        }

        private void setCelular(String celularTutor)
        {
            if (utils.campoVazio(celularTutor))
            {
                throw new Exception("Campo celular Obrigatorio !!!");
            }
            else if (utils.totalCaracteres(11, celularTutor))
            {
                throw new Exception("Celular deve ter 11 Caracteres !!!");
            }
            else
            {
                this.celular = celularTutor;
            }
        }

        private void setEmail(String emailTutor)
        {
            if (utils.campoVazio(emailTutor))
            {
                throw new Exception("Campo Email Obrigatorio !!!");
            }
            else if (utils.limiteTexto(80, emailTutor))
            {
                throw new Exception("limite de caracteres Excedido para Email!!!");
            }
            else
            {
                this.email = emailTutor;
            }
        }

    }
}
