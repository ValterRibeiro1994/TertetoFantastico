using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        private async void TelaSplash_Shown(object sender, EventArgs e)
        {
            await Task.Delay(100);
            TelaInicial tela = new TelaInicial();
            tela.Show();
            this.Hide();
            return;
        }


    }
}
