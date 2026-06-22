using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppPetShop
{
    internal class Data
    {
        private DateTime data;

        public Data(DateTimePicker dataForm = null, DateTime dataBanco = new DateTime())
        {
            // verifica se o objeto veio do formulario
            if (dataForm != null)
            {
                data = dataForm.Value;
            } else // veio do banco
            {
                data = dataBanco;
            }
         }

        public DateTime getData()
        {
            return data;
        }

        
    }
}
