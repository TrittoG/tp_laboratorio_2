using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace ClasesAbstractas
{
    public abstract class Universitario : Persona
    {
        /// <summary>
        /// fields
        /// </summary>
        private int legajo;

        /// <summary>
        /// constructor por defecto
        /// </summary>
        public Universitario()
        {

        }

        /// <summary>
        /// constructor que recibe todos los parametros
        /// </summary>
        /// <param name="legajo"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, nacionalidad, dni)
        {
            this.legajo = legajo;
        }

        /// <summary>
        /// metodo virtual para mostrar los datos del Universitario
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder st = new StringBuilder();


            st.AppendLine("Legajo: " + this.legajo);

            return base.ToString() + st.ToString();
        }





        /// <summary>
        /// metodo abstracto de Participar en clase
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();

        /// <summary>
        /// sobrecarga de Equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Universitario)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// sobrecarga del == para ver si dos universitarios son iguales
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            if (pg1.Equals(pg2) && (pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// sobrecarga del != para ver si dos universitarios no son iguales
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }


    }
}










