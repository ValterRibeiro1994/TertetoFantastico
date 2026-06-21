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
            if (tipoString != null) 
            {

                tipoS.Text = tipoString;

            }

            if (validarTipo(tipoS)) 
            {
                this.tipo = tipoS.SelectedItem.ToString();
            }

        }

        public string getTipo()
        {
            return this.tipo;
        }

        public bool validarTipo(ComboBox tipoS)
        {
            if (tipoS.SelectedItem == null)
            {
                throw new Exception("Selecione um tipo de serviço !!!");
            }
            return true;
        }
    }

}
