using System;

namespace AppPetShop
{
    internal class Servico
    {
        private CodigoBanco codigo;
        private TipoServiço tipo;
        private Data data;
        private ValorServico valor;

        public void setCodigo(CodigoBanco codigo)
        {
            this.codigo = codigo;
        }

        public void setTipo(TipoServiço tipo)
        {
            this.tipo = tipo;
        }

        public void setData(Data data)
        {
            this.data = data;
        }

        public void setValor(ValorServico valor)
        {
            this.valor = valor;
        }

        public int getCodigo()
        {
            return this.codigo.getCodigo();
        }

        public string getTipo()
        {
            return this.tipo.getTipo();
        }

        public DateTime getData()
        {
            return this.data.getData();
        }

        public double getValor()
        {
            return this.valor.getValorServico();
        }
    }
}
