using System;

namespace AppPetShop
{
    internal class Consulta
    {
        private CodigoBanco codigoPet;
        private Data data;
        private Texto descConsulta;


        public void setCodigo(CodigoBanco codigoPet)
        {
            this.codigoPet = codigoPet;
        }

        public void setData(Data data)
        {
            this.data = data;
        }

        public void setDesc(Texto descConsulta)
        {
            this.descConsulta = descConsulta;
        }

        public int getCodigo()
        {
            return this.codigoPet.getCodigo();

        }

        public DateTime getData()
        {
            return this.data.getData();
        }

        public string getDesc()
        {
            return this.descConsulta.getNome();
        }
    }
}
