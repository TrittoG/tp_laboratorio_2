using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;
using ClasesAbstractas;

namespace Clases_Instaniables
{
    public class Universidad
    {
        /// <summary>
        /// enumerado publico de las clases
        /// </summary>
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }

        /// <summary>
        /// fields
        /// </summary>
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        /// <summary>
        /// propiedad publica de lectura y escritura para profesores
        /// </summary>
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
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
        /// propiedad publica de lectura y escritura para Jornadas
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }

        /// <summary>
        /// propiedad que retorna una jornada en la posicion i, si la posicion i no existe, toma la ultima posicion valida
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Jornada this[int i]
        {
            get
            {
                if (i <= this.jornada.Count)
                {
                    return this.jornada[i];
                }
                else
                {
                    return this.jornada.Last();
                }
            }
            set
            {
                    this.jornada[i] = value;
            }
        }

        /// <summary>
        /// constructor sin parametros
        /// </summary>
        public Universidad()
        {
            this.Alumnos = new List<Alumno>();
            this.Instructores = new List<Profesor>();
            this.Jornadas = new List<Jornada>();
        }

        /// <summary>
        /// sobrecarga del == que valida si un alumno esta en la universidad
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad u, Alumno a)
        {
            foreach (Alumno al in u.Alumnos)
            {
                if (a == al)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// sobrecarga del operador != entre universidad y alumno
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad u, Alumno a)
        {
            return !(u == a);
        }


        /// <summary>
        /// sobrecarga del operador == entre universidad y profesor si el profesor esta en la universidad retorna true
        /// </summary>
        /// <param name="u">universidad</param>
        /// <param name="p">profesor</param>
        /// <returns></returns>
        public static bool operator ==(Universidad u, Profesor p)
        {
            foreach (Profesor pr in u.Instructores)
            {
                if (p == pr)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// sobrecarga del operador != entre universidad y profesor
        /// </summary>
        /// <param name="u">universidad</param>
        /// <param name="p">profesor</param>
        /// <returns></returns>
        public static bool operator !=(Universidad u, Profesor p)
        {
            return !(u == p);
        }

        /// <summary>
        /// sobrecarga del operador == entre universidad y clase, retorna el profesor que puede dar la clase
        /// </summary>
        /// <param name="u">universidad</param>
        /// <param name="c">clase</param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad u, EClases c)
        {
            foreach (Profesor p in u.Instructores)
            {
                if (p == c)
                {
                    return p;
                }
            }
            throw new SinProfesorException();
        }


        /// <summary>
        /// sobrecarga del operador != entre universidad y clase
        /// </summary>
        /// <param name="u">universidad</param>
        /// <param name="c">clase</param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad u, EClases c)
        {
            foreach (Profesor p in u.Instructores)
            {
                if (p != c)
                {
                    return p;
                }
            }
            throw new SinProfesorException();
        }

        /// <summary>
        /// sobrecarga del operador + entre universidad y clase para agregar una clase
        /// </summary>
        /// <param name="u">universidad</param>
        /// <param name="c">clase</param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, EClases c)
        {
            //creo un profesor
            Profesor p = new Profesor();
            //le asigno el profesor que puede dar la clase
            p = u == c;
            //creo una nueva jornada con esa clase y el profesor que puede darla
            Jornada j = new Jornada(c, p);

            //busco alumnos que tomen esa clase y los agrego a la jornada siempre reutilizando codigo
            foreach (Alumno a in u.Alumnos)
            {
                if (a == c)
                {
                    j = j + a;
                }
            }
            //agrego esa jornada ya cargada con alumnos y profesor a la universidad
            u.Jornadas.Add(j);
            //retorno la universidad con la jornada cargada
            return u;
        }

        /// <summary>
        /// sobrecarga del operador + entre universidad y alumno, para agregar un alumno a la universidad
        /// </summary>
        /// <param name="u">universidad</param>
        /// <param name="a">alumno</param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
            {
                u.Alumnos.Add(a);
                return u;
            }
            throw new AlumnoRepetidoException();
        }

        /// <summary>
        /// sobrecarga del operador + entre universidad y profesor, para agregar un profesor a la universidad
        /// </summary>
        /// <param name="u">universidad</param>
        /// <param name="p">profesor</param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Profesor p)
        {
            if (u != p)
            {
                u.Instructores.Add(p);
            }
            return u;
        }

        /// <summary>
        /// metodo privado para mostrar los datos de la universidad
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder st = new StringBuilder();

            st.AppendLine("JORNADAS: ");

            foreach (Jornada j in uni.Jornadas)
            {
                st.AppendLine(j.ToString());
            }


            st.AppendLine("PROFESORES: ");

            foreach (Profesor p in uni.Instructores)
            {
                st.AppendLine(p.ToString());
            }


            st.AppendLine("ALUMNOS: ");

            foreach (Alumno al in uni.Alumnos)
            {
                st.AppendLine(al.ToString());
            }

            return st.ToString();
        }

        /// <summary>
        /// metodo publico para mostrar los datos de la universidad
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }

        /// <summary>
        /// metodo que guarda una universidad serializada, deberia recibir tambien un path y se elije donde se desea guardar
        /// </summary>
        /// <param name="uni">objeto a serializar</param>
        /// <returns></returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> xml = new Xml<Universidad>();

            return xml.Guardar("Universidad.xml", uni);
        }


        /// <summary>
        /// metodo que lee una universidad serialiada, recibe una unversidad que la carga y la retorna
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        public static Universidad Leer(Universidad uni)
        {
            Xml<Universidad> xml = new Xml<Universidad>();

            bool leer = xml.Leer("Universidad.xml", out uni);

            return uni;

        }
    }
}



