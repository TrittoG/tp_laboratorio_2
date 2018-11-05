using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace Clases_Instaniables
{
    public class Jornada
    {
        /// <summary>
        /// fields
        /// </summary>
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        /// <summary>
        /// constructor privado que inicializa la lista de alumnos
        /// </summary>
        private Jornada()
        {
            this.Alumnos = new List<Alumno>();
        }

        /// <summary>
        /// constructor publico que recibe la clase y el profesor
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }

        /// <summary>
        /// propiedad publica de lectura y escritura para alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }

        /// <summary>
        /// propiedad publica de lectura y escritura para las clases
        /// </summary>
        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }

        /// <summary>
        /// propiedad publica de lectura y escritura para profesores
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }

        /// <summary>
        /// sobrecarga del == para ver si un alumno esta en la jornada
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {

            return a == j.Clase;
        }

        /// <summary>
        /// sobrecarga del != para ver si un alumno no esta en la jornada
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// sobrecarga del + para agregar si se puede un alumno a la jornada
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            foreach (Alumno al in j.alumnos)
            {
                if (al == a)
                    return j;
            }
            j.alumnos.Add(a);
            return j;
        }

        /// <summary>
        /// metodo publico heredado que retorna todos los datos de la jornada
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder st = new StringBuilder();

            st.AppendLine("Clase: " + this.Clase.ToString());
            st.AppendLine("Profesor: " + this.Instructor.ToString());

            st.AppendLine("Alumno: ");
            foreach (Alumno al in this.Alumnos)
            {
                st.AppendLine(al.ToString());
            }

            return st.ToString();
        }





        /// <summary>
        /// metodo publico que guarda los datos de la jornada en un archivo de texto
        /// </summary>
        /// <param name="j"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada j)
        {
            Texto txt = new Texto();

            return txt.Guardar("Jornada.txt", j.ToString());
        }

        /// <summary>
        /// metodo publico que lee los datos de una jornada de un archivo de texto
        /// </summary>
        /// <returns></returns>
        public static string Leer()
        {
            string aux;

            Texto txt = new Texto();

            txt.Leer("Jornada.txt", out aux);
            return aux;
        }
    }
}


