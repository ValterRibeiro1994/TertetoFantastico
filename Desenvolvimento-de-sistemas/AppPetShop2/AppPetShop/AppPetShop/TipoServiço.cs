using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppPetShop
{
    internal class TipoServiço
    {
        private string tipo;

        public TipoServiço(ComboBox tipoS = null, String tipoString = null)
        {
            // se tem um combobox 
            if (tipoS != null)
            {
                string[] servicos = { "banho", "tosa" };

                string texto = tipoS.Text.Trim().ToLower();

                // verifica se ele tem um valor selecionado
                if (texto.Equals("") || texto.Equals("selecione um serviço"))
                {
                    throw new Exception("Selecione o tipo de Serviço");
                } else
                {
                    bool encontrado = false;
                    int n = servicos.Length;
                    for (int i = 0; i < n; i++)
                    {
                        if (texto.Equals(servicos[i]))
                        {
                            tipo = texto;
                            encontrado = true;
                            break;
                        }
                    }

                    if (!encontrado)
                    {
                        throw new Exception("Serviço não cadastrado no Sistema");
                    }
                }
            }
            else // o valor veio do banco 
            {
                if (tipoString != null)
                {
                    tipo = tipoString;
                }
            }
        }

        public string getTipo()
        {
            return this.tipo;
        }
    }
}
