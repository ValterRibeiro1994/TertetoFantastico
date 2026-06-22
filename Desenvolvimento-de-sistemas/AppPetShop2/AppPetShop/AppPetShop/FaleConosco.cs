using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppPetShop
{
    internal class FaleConosco
    {
        private Email email;
        private Texto nome;
        private Texto msg;
        private bool status;

        public FaleConosco(Email email, Texto nome, Texto msg)
        {
            this.email = email;
            this.nome = nome;
            this.msg = msg;
            this.status = false;
        }

        public bool getStatusResposta()
        {
            return status; 
        }

        public void setStatusResposta(bool reposta)
        {
            status = reposta;
        }

    }
}
