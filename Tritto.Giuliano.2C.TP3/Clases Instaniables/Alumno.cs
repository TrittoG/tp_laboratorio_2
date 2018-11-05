using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesAbstractas;

namespace Clases_Instaniables
{
    public sealed class Alumno : Universitario
    {
        /// <summary>
        /// enumerado publico del estado de cuenta del alumno
        /// </summary>
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }

        /// <summary>
        /// fields
        /// </summary>
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        /// <summary>
        /// constructor sin parametros
        /// </summary>
        public Alumno()
        {

        }

        /// <summary>
        /// constructor que recive parametros y los asigna a la base
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="clasesQueToma"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases clasesQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = clasesQueToma;
        }

        /// <summary>
        /// constructor que recive todos los parametros
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="clasesQueToma"></param>
        /// <param name="estadoCuenta"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases clasesQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, clasesQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }



        /// <summary>
        /// metodo que retorna las clases que toma el alumno
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder st = new StringBuilder();
            //no se si se pone el ToString()
            st.AppendLine(" TOMA CLASES DE: " + claseQueToma.ToString());
            return st.ToString();

        }

        /// <summary>
        /// metodo protegido que muestra los datos del alumno
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {         
            return base.MostrarDatos() + this.ParticiparEnClase() + " " + this.estadoCuenta.ToString();
        }




        /// <summary>
        /// metodo publico heredado que muestra todos los datos del alumno
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// sobrecarga del == para ver si un alumno esta en la clase
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            if (a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// sobrecarga del != para ver si un alumno no esta en la clase
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return !(a == clase);
        }
    }
}







