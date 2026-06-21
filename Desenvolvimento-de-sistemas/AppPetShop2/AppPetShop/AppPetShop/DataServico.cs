using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppPetShop
{
    internal class DataServico
    {
        private DateTime dataServico;

        public DataServico(DateTimePicker dataServico)
        {
            if (validarDataServico(dataServico))
            {
                this.dataServico = dataServico.Value;
            }
        }

        public DateTime getDataServico()
        {
            return dataServico;
        }

        public bool validarDataServico(DateTimePicker dataServico)
        {

            //Fiz, porem não consigo pensar como isso aconteceria. 
            if (dataServico == null)
            {
                throw new Exception("Campo data do serviço não pode estar vazio !!!");
            }
                        
            return true;
        }
    }
}
