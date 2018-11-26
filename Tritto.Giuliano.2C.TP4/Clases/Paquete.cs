using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Paquete : IMostrar<Paquete>
    {

        public enum EEstado
        {
            Ingresando,
            EnViaje,
            Entregado
        }

        public delegate void DelegadoEstado(object a, EventArgs e);
        public event DelegadoEstado InformaEstado;

        public delegate void DelegateSQLError(string mensaje);
        public event DelegateSQLError SQLError;

        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        /// <summary>
        /// constructor publico que recibe la direccion y el  tracking id
        /// </summary>
        /// <param name="direccionEntrega"></param>
        /// <param name="trackingID"></param>
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.DireccionEntrega = direccionEntrega;
            this.TrackingID = trackingID;
        }

        /// <summary>
        /// propiedad de lectura escritura para el trackingid
        /// </summary>
        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }
            set
            {
                this.trackingID = value;
            }
        }

        /// <summary>
        /// propiedad de lectura escritura para la direccion de entrega
        /// </summary>
        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }
            set
            {
                this.direccionEntrega = value;
            }
        }

        /// <summary>
        /// propiedad de lectura escritura para el estado del paquete
        /// </summary>
        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }

        /// <summary>
        /// metodo que cambia el estado del paquete e invoca a informar estado
        /// </summary>
        public void MockCicloDeVida()
        {
            
            while(this.Estado != EEstado.Entregado)
            {
                System.Threading.Thread.Sleep(500);

                if (this.Estado == EEstado.Ingresando)
                {
                    this.Estado = EEstado.EnViaje;
                }
                else
                {
                    this.Estado = EEstado.Entregado;
                }

                InformaEstado.Invoke(new object { }, EventArgs.Empty);
            }

            try
            {
                PaqueteDAO.Insertar(this);
            }
            catch(Exception e)
            {
                SQLError.Invoke(e.Message);
            }

        }

        /// <summary>
        /// metodo que muestra los datos de un paquete
        /// </summary>
        /// <returns></returns>
        public string MostrarDatos()
        {
            StringBuilder st = new StringBuilder();
          
            st.AppendLine(this.ToString() + " " + this.Estado);

            return st.ToString();
            
        }

        /// <summary>
        /// metodo que muestra el tracking id y la direccion
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder st = new StringBuilder();

            st.AppendLine(this.TrackingID + " Para " + this.DireccionEntrega);

            return st.ToString();
        }

    
        /// <summary>
        /// sobrecarga del operador == para comparar si dos paquetes son iguales segun el tracking id
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            if(p1.TrackingID == p2.TrackingID)
            {
                return true;
            }
            return false;
        }
       
        /// <summary>
        /// sobrecarga del != para ver si dos paquetes son distintos
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }

    }
}
