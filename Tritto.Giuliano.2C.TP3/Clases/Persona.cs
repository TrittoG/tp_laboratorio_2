using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace ClasesAbstractas
{
    public abstract class Persona
    {
        //enumerado para ver si es argentino o extranjero
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        //campos
        private string nombre;
        private string apellido;
        private ENacionalidad nacionalidad;
        private int dni;

        /// <summary>
        /// constructor sin parametros
        /// </summary>
        public Persona()
        {

        }

        /// <summary>
        /// Constructor sin el parametro dni
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor con el parametro DNI como int 
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="dni"></param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad, int dni) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        /// <summary>
        /// Constructor con el parametro DNI como string
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="dni"></param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad, string dni) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDni = dni;
        }

        /// <summary>
        /// propiedad de lectura/escritura de Nombre
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }

            set
            {
                if (!(ValidarNombreApellido(value) is null))
                    nombre = value;
            }

        }

        /// <summary>
        /// propiedad publica de lectura y escritura para Apellido
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                if (!(ValidarNombreApellido(value) is null))
                    apellido = value;
            }
        }

        /// <summary>
        /// propiedad publica de lectura y escritura para Nacionalidad
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }

        /// <summary>
        /// propiedad publica de lectura y escritura para DNI
        /// </summary>
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = ValidarDni(this.nacionalidad, value);
            }
        }

        /// <summary>
        /// propiedad publica de lectura y escritura para DNI pasado como string
        /// </summary>
        public string StringToDni
        {
            set
            {
                this.dni = ValidarDni(this.nacionalidad, value);
            }
        }



        /// <summary>
        /// Metodo privado que valida el nombre y el apellido
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {

            foreach (char c in dato)
            {
                if (!((c >= 'A' || c <= 'Z') || (c >= 'a' || c <= 'z') || (c == ' ')))
                {
                    return null;
                }
            }
            return dato;
        }

        /// <summary>
        /// Metodo privado que valida el dni pasado como int
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (dato < 1 || dato > 99999999)
            {
                throw new DniInvalidoException("DNI invalido");
            }

            if (nacionalidad == ENacionalidad.Argentino && (dato > 0 && dato < 90000000))
            {
                return dato;
            }
            else
            {
                if (nacionalidad == ENacionalidad.Extranjero && (dato > 89999999 && dato < 100000000))
                {
                    return dato;
                }
                else
                {
                    throw new NacionalidadInvalidaException("nacionalidad invalida");
                }
            }


        }

        /// <summary>
        /// Metodo privado que valida el dni pasado como string
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int aux;
            if (int.TryParse(dato, out aux))
            {
                return ValidarDni(nacionalidad, aux);
            }
            else
            {
                throw new DniInvalidoException();
            }
        }

        /// <summary>
        /// metodo publico que retorna los datos de la persona
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder st = new StringBuilder();

            st.AppendLine("Nombre: " + this.Nombre);
            st.AppendLine("apellido: " + this.Apellido);
            st.AppendLine("Nacionalidad: " + this.nacionalidad.ToString());
            st.AppendLine("DNI: " + this.DNI);

            return st.ToString();
        }





    }
}



