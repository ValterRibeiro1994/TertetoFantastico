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
        private double valor;

        public ValorServico(TextBox valorForm = null , String valorBanco = null)
        {
            if (valorForm != null)
            {
                validarValorServico(valorForm.Text);
            } else
            {
                validarValorServico(valorBanco);
            }
        }

        public double getValorServico()
        {
            return valor;
        }

        public bool validarValorServico(string valorServico)
        {
            string valor = valorServico;
            int limite = "10000.00".Length; // limite maximo de caracteres
            // verifica o comprimento da string de valor recebido
            if (valor.Length > limite) {
                throw new Exception("Valor de Serviço passou do limite permitido !!!");
            }

            // troca pontos por virgulas
            valor = valorServico.Replace(".", ","); 

            // tenta converter a entrada para numeros
            try
            {
                double n = double.Parse(valor);
                if (n <= 0)
                {
                    throw new Exception("Valor do serviço deve ser positivo");
                }
                this.valor = n;
                return true;
            } catch (Exception ex) {
                throw new Exception("Número invalido !!! \n" + ex.Message);
            }
        }
    }
}
