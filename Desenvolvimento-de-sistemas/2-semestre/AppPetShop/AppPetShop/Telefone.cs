using System;
using System.Linq;

namespace AppPetShop
{
    internal class Telefone
    {
        private string telefone;

        public Telefone(string telefone)
        {
            if (validarTelefone(telefone))
            {
                this.telefone = telefone;
            }

        }

        public string getTelefone()
        {
            return telefone;
        }
        private bool validarTelefone(string telefone)
        {
            if (String.IsNullOrEmpty(telefone))
            {
                throw new Exception("Número de Telefone é obrigatorio !!!");
            }

            if (telefone.All(char.IsDigit) == false)
            {
                throw new Exception("Número de Telefone deve ter apenas valores númericos !!!");
            }

            if (telefone.Length != 11)
            {
                throw new Exception("Numero de caracteres invalido para Telefone !!!");
            }

            return true;
        }
    }
}
