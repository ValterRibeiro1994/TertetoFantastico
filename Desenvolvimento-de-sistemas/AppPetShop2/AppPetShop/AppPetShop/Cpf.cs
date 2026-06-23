using System;

namespace AppPetShop
{
    internal class Cpf
    {
        private string cpf;
        public Cpf(string cpf)
        {
            if (validarCpf(cpf))
            {
                this.cpf = cpf;
            }
        }
        public string getCpf()
        {
            return this.cpf;
        }

        private bool validarCpf(string cpf)
        {
            if (String.IsNullOrEmpty(cpf))
            {
                throw new Exception("Campo cpf não pode estar vazio !!!");
            }

            // checa se todos os caracteres são numeros
            int n = cpf.Length;
            for (int i = 0; i < n; i++)
            {
                char letra = cpf[i];
                if (!char.IsDigit(letra))
                {
                    throw new Exception("Informe apenas números para o cpf !!!");
                }

            }

            if (n != 11)
            {
                throw new Exception("Campo cpf deve conter 11 números");
            }

            return true;
        }
    }
}
