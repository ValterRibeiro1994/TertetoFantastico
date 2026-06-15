using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPetShop
{
    internal class Pet
    {
        int codigo;
        string cpf_tutor;
        string nome_pet;
        string especie;
        string raca;
        char genero;
        DateTime nascimento;
        byte[] foto;

        public void setCodigo(string codigoStr)
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
                this.codigo = codigoInt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
