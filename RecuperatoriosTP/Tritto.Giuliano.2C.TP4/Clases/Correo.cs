using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Clases
{
    public class Correo : IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        /// <summary>
        /// Propiedad de lectura y escritura para la lista de paquetes
        /// </summary>
        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }
            set
            {
                this.paquetes = value;
            }
        }

        /// <summary>
        /// Constructor publico que inicializa las listas
        /// </summary>
        public Correo()
        {
            mockPaquetes = new List<Thread>();
            paquetes = new List<Paquete>();
        }

        /// <summary>
        /// metodo que finaliza los treads de la lista de threads
        /// </summary>
        public void FinEntregas()
        {
            foreach(Thread t in mockPaquetes)
            {
                if(t.IsAlive)
                {
                    t.Abort();
                }
            }
        }

        /// <summary>
        /// metodo que muestra los datos de los paquetes
        /// </summary>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            StringBuilder st = new StringBuilder();

            foreach (Paquete p in ((Correo)elementos).paquetes)
            {
                st.AppendLine(string.Format("{0} para {1} ({2})", p.TrackingID, p.DireccionEntrega, p.Estado));
            }

            return st.ToString();
        }

        /// <summary>
        /// sobrecarga del operador   + para agregar un paquete a la lista de paquetes de correo
        /// </summary>
        /// <param name="c"></param>
        /// <param name="p"></param>
        /// <returns>retorna el correo ingresado con o sin el paquete agregado</returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            foreach(Paquete a in c.Paquetes)
            {
                if(a == p)
                {
                    throw new TrackingIDRepetidoException("Item Repetido");
                }
            }

            c.Paquetes.Add(p);

            Thread t = new Thread(p.MockCicloDeVida);
            c.mockPaquetes.Add(t);
            t.Start();

            return c;
        }
            
    }
}
