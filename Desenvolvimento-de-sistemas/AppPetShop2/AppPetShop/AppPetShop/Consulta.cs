using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPetShop
{
    internal class Consulta
    {
        private CodigoBanco codigoPet;
        private CodigoBanco idConsulta;
        private DataConsulta data;
        private DescConsulta descConsulta;


        public void setCodigo(CodigoBanco codigoPet)
        {
            this.codigoPet = codigoPet;
        }

        public void setId(CodigoBanco idConsulta)
        {
            this.idConsulta = idConsulta;
        }

        public void setData(DataConsulta data)
        {
            this.data = data;
        }

        public void setDesc(DescConsulta descConsulta)
        {
            this.descConsulta = descConsulta;
        }

        public int getCodigo()
        {
            return this.codigoPet.getCodigo();

        }

        public int getId()
        {
            return this.idConsulta.getCodigo();
        }

        public DateTime getData()
        {
            return this.data.getDataConsulta();
        }

        public string getDesc()
        {
            return this.descConsulta.getDesc();
        }
    }
}
