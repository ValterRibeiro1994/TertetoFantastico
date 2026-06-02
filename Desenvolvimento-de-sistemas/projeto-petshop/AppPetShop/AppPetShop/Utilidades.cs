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

        public bool campoVazio(String campo)
        {
            return String.IsNullOrEmpty(campo);
        }

        public void notificarUsuario(String msg)
        {
            MessageBox.Show(msg);
        }

        public bool limiteTexto(int limite, String texto)
        {
            return texto.Length > limite;
        }

        public bool totalCaracteres(int total, String texto)
        {
            return texto.Length != total;
        }

    }
}
