using System;
using System.Drawing;
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
            // Reseta o texto e define o tema escuro inicial (fundo preto com letras brancas)
            label1.Text = string.Empty;
            label1.ForeColor = Color.White;
            this.BackColor = Color.Black;

            // Define a mensagem multilinha que será exibida gradualmente na tela
            string texto = "Seja Bem Vindo " +
                "\nAula: Desenvolvimento de Sistemas" +
                "\nProfessor: Marcelo Della Torre" +
                "\nProjeto: Sistema PetShop" +
                "\nDevs = {" +
                "\n\tLucas Braz," +
                "\n\tFelipe Rodrigo," +
                "\n\tValter Tertuliano" +
                "\n\t}" +
                "\nCarregando ...";

            int n = texto.Length; // Obtém a quantidade total de caracteres do texto
            await Task.Delay(100); // Aguarda 1 segundo antes de iniciar a digitação
            // Percorre o texto caractere por caractere, criando o efeito de máquina de escrever
            for (int x = 0; x < n; x++)
            {
                label1.Text += texto[x];
                await Task.Delay(1); // Pausa de 100 milissegundos entre cada letra
            }
            await Task.Delay(100);
            // Instancia, exibe a Tela Inicial e esconde a Tela Splash atual
            TelaInicial tela = new TelaInicial();
            tela.Show();
            this.Hide();
        }


    }
}
