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
            return true;
        }
    }
}
