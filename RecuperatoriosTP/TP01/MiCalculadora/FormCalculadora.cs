using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
  public partial class FormCalculadora : Form
  {

        public FormCalculadora()
        {
          InitializeComponent();
      
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
             
            lblResultado.Text = string.Format("{0}",Operar(txtNumero1.Text,txtNumero2.Text, cmbOperador.Text)); 
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir?", "Saliendo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if(!(lblResultado.Text is null))
                 lblResultado.Text = Numero.DecimalBinario(lblResultado.Text);
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Numero.BinarioDecimal(lblResultado.Text);
        }

        /// <summary>
        /// limpia los contenedores, el label y el combobox
        /// </summary>
        private void Limpiar()
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            cmbOperador.Text = "";
            lblResultado.Text = "";
        }

        /// <summary>
        /// metodo estatico que opera los numeros ingresados con el operador ingresado, llama a c.operar
        /// </summary>
        /// <param name="num1">primer numero a operar</param>
        /// <param name="num2">segundo numero a operar</param>
        /// <param name="operando">operador pasado como string</param>
        /// <returns></returns>
        private static double Operar(string num1, string num2, string operando)
        {
            Calculadora c = new Calculadora();
            Numero n1 = new Numero(num1);
            Numero n2 = new Numero(num2);

            return c.Operar(n1, n2, operando);
        }
    }
}
