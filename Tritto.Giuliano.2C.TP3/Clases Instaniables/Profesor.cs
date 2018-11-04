using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesAbstractas;

namespace Clases_Instaniables
{
    public sealed class Profesor : Universitario 
    {
        /// <summary>
        /// fields
        /// </summary>
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        /// <summary>
        /// constructor estatico que inicializa el random
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }

        /// <summary>
        /// constructor por defecto
        /// </summary>
        public Profesor()
        {

        }

        /// <summary>
        /// constructor publico que recibe todos los parametros
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id,nombre,apellido,dni,nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            _randomClases();
        }

        /// <summary>
        /// metodo protegido heredado que dice que clases toma el profesor
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder st = new StringBuilder();

            foreach(Universidad.EClases clase in clasesDelDia)
            {
                st.AppendLine("CLASES DEL DIA: " + clase.ToString());
            }
            return st.ToString();
        }

        /// <summary>
        /// metodo protegido heredado que muestra los datos del profesor
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            return base.MostrarDatos() + ParticiparEnClase();
        }

        /// <summary>
        /// metodo publico heredado que muestra todos los datos del profesor
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos();
        }

        /// <summary>
        /// metodo privado para agregar dos clases al profesor
        /// </summary>
        private void _randomClases()
        {
            this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 3));
            this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 3));
        }

        /// <summary>
        /// sobrecarga del == para ver si un profesor da la clase
        /// </summary>
        /// <param name="p"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Profesor p, Universidad.EClases clase)
        {
            if(p.clasesDelDia.Contains(clase))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// sobrecarga del != para ver si un profesor no da la clase
        /// </summary>
        /// <param name="p"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Profesor p , Universidad.EClases clase)
        {
            return !(p == clase);
        }

    }
}
