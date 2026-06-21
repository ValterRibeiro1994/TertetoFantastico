using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPetShop
{
    internal class Email
    {
        private string email;

        public Email(string email) {
            if (validarEmail(email))
            {
                this.email = email;
            }
        }

        public string getEmail()
        {
            return email; 
        }

        private bool validarEmail(string email)
        {
            int limite_caracteres = 80;

            if (String.IsNullOrEmpty(email))
            {
                throw new Exception("Email obrigatorio !!!");
            }

            if (email.Length > limite_caracteres)
            {
                throw new Exception("Limite de caracteres excedido para Email");
            }
            return true;
        }


    }
}
