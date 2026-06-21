using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppPetShop
{
    internal class ValorServico
    {
        private double valorServico;

        public ValorServico(TextBox valorServico)
        {
            if (validarValorServico(valorServico))
            {
                this.valorServico = Convert.ToDouble(valorServico.Text);
            }
        }

        public double getValorServico()
        {
            return valorServico;
        }

        public bool validarValorServico(TextBox valorServico)
        {
            String StringValor;
            double valor;

            try
            {
                StringValor = valorServico.Text.Replace(",", ".");
                valor =  Convert.ToDouble(StringValor);

            }
            catch (Exception ex)
            {
                throw new Exception("Valor do serviço deve ser um número !!!");
            }

            if (valor <= 0)
                {
                    throw new Exception("Valor do serviço deve ser maior que zero !!!");
                    return false;
                }
                int tamanho = StringValor.Length;
                if (tamanho > 6)
                {
                    throw new Exception("Valor do serviço deve ser menor que 10 Mil");
                    return false;
                }

            

                
            return true;
        }
    }
}
