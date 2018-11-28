using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clases;

namespace MainCorreo
{
    public partial class FrmPpal : Form
    {
        Correo c ;

        public FrmPpal()
        {
            InitializeComponent();
            c = new Correo();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete p = new Paquete(txtDireccion.Text, mtxtTrackingID.Text);

            try
            {
                p.SQLError += SQLError;
                c += p;
                p.InformaEstado += paq_informar;        
                ActualizarEstados();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
        }

        private void FrmPpal_Load(object sender, EventArgs e)
        {

        }

        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            c.FinEntregas();
        }

     
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if(elemento != null)
            {
                rtbMostrar.Text = elemento.MostrarDatos(elemento);

                try
                {
                    GuardaString.Guardar(elemento.MostrarDatos(elemento), "salida.txt");
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.Message);
                }


            }
        }
   

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)c);
        }




        private void ActualizarEstados()
        {
            
                lstEstadoEntregado.Items.Clear();
                lstEstadoEnViaje.Items.Clear();
                lstEstadoIngresando.Items.Clear();

                foreach (Paquete p in c.Paquetes)
                {
                    switch (p.Estado)
                    {
                        case Paquete.EEstado.Entregado:
                            lstEstadoEntregado.Items.Add(p);
                            break;
                        case Paquete.EEstado.EnViaje:
                            lstEstadoEnViaje.Items.Add(p);
                            break;
                        case Paquete.EEstado.Ingresando:
                            lstEstadoIngresando.Items.Add(p);
                            break;
                    }
                }
            
          
        }


        private void paq_informar(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_informar);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                ActualizarEstados();
            }
        }

        private void SQLError(string mensaje)
        {
            MessageBox.Show(mensaje);
        }

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }

    }
}
