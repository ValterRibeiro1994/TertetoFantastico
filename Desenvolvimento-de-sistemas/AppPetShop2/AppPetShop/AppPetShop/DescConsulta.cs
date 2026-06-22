using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPetShop
{
    internal class DescConsulta
    {
        private String Descrição;

        public DescConsulta(String descrição)
        {
            if (validarDesc(descrição))
            {
                this.Descrição = descrição;
            }
        }

        public String getDesc()
        {
            return Descrição;
        }

        private bool validarDesc(String descrição)
        {
            if (String.IsNullOrEmpty(descrição))
            {
                throw new Exception("Descrição deve ser informada !!!");
            }

            // Text suporta até 65 mil  caracteres no banco de dados
            if (descrição.Length >= 65.000)
            {
                throw new Exception("Limite de caracteres excedido");
            }
            return true;
        }
    }
}
