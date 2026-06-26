using System;

namespace AppPetShop
{
    internal class CodigoBanco
    {
        private int cod;

        public CodigoBanco(string codigo)
        {
            if (validarCodigo(codigo))
            {
                this.cod = int.Parse(codigo);
            }

        }

        public int getCodigo()
        {
            return this.cod;
        }
        private bool validarCodigo(string codigoStr)
        {
            if (String.IsNullOrEmpty(codigoStr))
            {
                throw new Exception("Campo código não deve estar vazio !!!");
            }

            try
            {
                int codigoInt = int.Parse(codigoStr);
                if (codigoInt <= 0)
                {
                    throw new Exception("Código de Pet Inválido !!!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return true;
        }
    }
}
