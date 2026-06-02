using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppPetShop
{
    public partial class TelaSplash : Form
    {
        public TelaSplash()
        {
            InitializeComponent();
        }

        private void startProgram(object sender, EventArgs e)
        {
           DateTime inicio = DateTime.Now.AddSeconds(5);
           while (true)
            {
                DateTime agora = DateTime.Now;
                if (agora > inicio)
                {
                    TelaInicial tela = new TelaInicial();
                    tela.Show();
                    this.Hide();
                    return;
                }

            }
        }
    }
}
