using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppPetShop
{
    internal class Utilidades
    {
        public bool validarCampo(string campo, string nome_campo)
        {
            /*
                Método para validar campos de entrada
                Retorna False se o campo estiver vazio 
                Feito por: Valter
             */
            if (String.IsNullOrEmpty(campo))
            {
                MessageBox.Show("Campo " + nome_campo + " não pode estar vazio !!!");
                return false;
            }
            return true;
        }
    }




}
