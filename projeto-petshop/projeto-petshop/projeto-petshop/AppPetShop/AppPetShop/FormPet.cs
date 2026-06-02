using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppPetShop
{
    public partial class FormPet : Form
    {
        Utilidades util = new Utilidades();
        public FormPet()
        {
            InitializeComponent();

        }


        public static void PegarDados(TextBox Nome, TextBox Nasc, RadioButton M, RadioButton F, TextBox Raca, TextBox Especie)
        {
            String nome = Nome.Text;
            String nasc = Nasc.Text;
            String genero;
            if ( M.Checked == true)
            {
               genero = "masculino";
            } 
            else
            {
                genero = "feminino";
            };
            String raca = Raca.Text;
            String especie = Especie.Text;

            

        }
    }
}
