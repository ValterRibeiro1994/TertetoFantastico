using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPetShop
{
    internal class Texto
    {
        private string nome;
        public Texto(string nome, int limite_min = 3, int limite_max = 80) {
        
            if (validarNome(nome, limite_min, limite_max))
            {
                this.nome = nome;
            }
        
        }

        public string getNome()
        {
            return this.nome; 
        }

        private bool validarNome(string nome, int limite_min = 3, int limite_max = 80)
        {
            if (String.IsNullOrEmpty(nome))
            {
                throw new Exception("Nome deve ser informado !!!");
            }

            int n = nome.Length;

            if (n > limite_max)
            {
                throw new Exception("Limite de caracteres excedido para nome do Tutor");
            }
            if (n < limite_min)
            {
                throw new Exception("Caracteres insuficiente para nome Tutor");
            }
            return true;
        }
    }
}
