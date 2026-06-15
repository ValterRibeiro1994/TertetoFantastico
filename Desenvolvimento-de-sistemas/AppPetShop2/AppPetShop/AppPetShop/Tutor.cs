using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPetShop
{
    internal class Tutor
    {
        /*
         Classe Tutor
            Representa o tutor do pet
            A classe realiza a validação dos dados fornecidos ao sistema
            ela deve ser instanciada sem passagem de parametros, os dados devem
            ser adicionados com os Setter's que fazem a validação dos dados
         */
        
        // dados a serem armazenados no banco
        private String nome, email, cpf, telefone;
        
        public void setNome(String nome, int limite_minimo = 3, int limite_maximo = 80)
        {
            
            if (String.IsNullOrEmpty(nome))
            {
                throw new Exception("Nome do tutor deve ser informado !!!");
            }

            int n = nome.Length;

            if (n > limite_maximo)
            {
                throw new Exception("Limite de caracteres excedido para nome do Tutor");
            }
            if (n < limite_minimo)
            {
                throw new Exception("Caracteres insuficiente para nome Tutor");
            }

            this.nome = nome;

        }

        public void setEmail(String email, int limite_caracteres = 80)
        {
            if (String.IsNullOrEmpty(email))
            {
                throw new Exception("Email do tutor é obrigatorio para cadastro !!!");
            }

            if (email.Length > limite_caracteres)
            {
                throw new Exception("Limite de caracteres excedido para Email");
            }
            this.email = email;
        }

        public void setCpf(String cpf)
        {
            if (String.IsNullOrEmpty(cpf))
            {
                throw new Exception("Número de CPF é obrigatorio para Tutor !!!");
            }

            // checa se todos os caracteres são numeros
            if (cpf.All(char.IsDigit) == false)
            {
                throw new Exception("CPF do tutor deve possuir apenas números !!!");
            }

            if (cpf.Length != 11)
            {
                throw new Exception("Limite de caracteres invalido para CPF !!!");
            }

            this.cpf = cpf;
        }

        public void setTelefone(String telefone)
        {
            if (String.IsNullOrEmpty(telefone))
            {
                throw new Exception("Número de Telefone do Tutor é obrigatorio !!!");
            }

            if (telefone.All(char.IsDigit) == false)
            {
                throw new Exception("Número de Telefone deve ter apenas valores númericos !!!");
            }

            if (telefone.Length != 11)
            {
                throw new Exception("Numero de caracteres invalido para Telefone !!!");
            }

            this.telefone = telefone;
        }
        
        public string getNome()
        {
            return this.nome;
        }

        public string getEmail()
        {
            return this.email; 
        }

        public string getCpf()
        {
            return this.cpf;
        }

        public string getTelefone()
        {
            return this.telefone;
        }

    }
}
