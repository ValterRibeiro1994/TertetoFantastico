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
            if (tipoS != null) {
                // verifica se ele tem um valor selecionado
                if (tipoS.SelectedText.Equals(""))
                {
                    throw new Exception("Selecione o tipo de Serviço");
                } else
                {
                    tipo = tipoS.SelectedText;
                }
            } else // o valor veio do banco 
            {
                if (tipoString  != null) {
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
