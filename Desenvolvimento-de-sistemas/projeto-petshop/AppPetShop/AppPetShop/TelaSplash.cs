using System;
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

        private async void iniciarSplash_Shown(object sender, EventArgs e)
        {
            await Task.Delay(3000);
            TelaInicial tela = new TelaInicial();
            tela.Show();
            this.Hide();
            return;
        }
    }
}
