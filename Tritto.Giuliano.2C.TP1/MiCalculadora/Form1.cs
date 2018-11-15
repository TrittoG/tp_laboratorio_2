using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using trabajo_practico_1;

namespace MiCalculadora
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("seguro que quiere salir?", "Saliendo....", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btn_operar_Click(object sender, EventArgs e)
        {
            Calculador calc = new Calculador();
            Numero num1 = new Numero(txt_num1.Text);
            Numero num2 = new Numero(txt_num2.Text);

            label1.Text = string.Format("{0}",calc.Operar(num1, num2, comboBox1.Text));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txt_num1.Text = "";
            txt_num2.Text = "";

            label1.Text = "";
            comboBox1.Text = "";
           
        }

        private void btn_binario_Click(object sender, EventArgs e)
        {
            if(label1.Text != null)
            {
                
                label1.Text = Numero.DecimalBinario(label1.Text);
                
            }
           
                
        }

        private void btn_decimal_Click(object sender, EventArgs e)
        {
            if (label1.Text != null)
            {
               
                label1.Text = Numero.BinarioDecimal(txt_num1.Text);
            }
           
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
