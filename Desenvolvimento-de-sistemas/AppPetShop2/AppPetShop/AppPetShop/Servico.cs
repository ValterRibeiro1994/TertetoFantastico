using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPetShop
{
    internal class Servico
    {
        private CodigoBanco codigo;
        private TipoServiço tipo;
        private DataServico data;
        private ValorServico valor;

        public void setCodigo(CodigoBanco codigo)
        {
            this.codigo = codigo;
        }

        public void setTipo(TipoServiço tipo)
        {
            this.tipo = tipo;
        }

        public void setData(DataServico data)
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
            return this.data.getDataServico();
        }

        public double getValor()
        {
            return this.valor.getValorServico();
        }
    }
}
