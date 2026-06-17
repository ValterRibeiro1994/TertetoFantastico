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
        private Cpf cpf;
        private Nome nome;
        private Email email;
        private Telefone telefone;

        public void setCpf(Cpf cpf)
        {
            this.cpf = cpf;
        }

        public void setNome(Nome nome)
        {
            this.nome = nome;
        }

        public void setEmail(Email email)
        {
            this.email = email;
        }

        public void setTelefone(Telefone telefone)
        {
            this.telefone = telefone;
        }
        
        public string getNome()
        {
            return this.nome.getNome();
        }

        public string getEmail()
        {
            return this.email.getEmail(); 
        }

        public string getCpf()
        {
            return this.cpf.getCpf();
        }

        public string getTelefone()
        {
            return this.telefone.getTelefone();
        }

    }
}
