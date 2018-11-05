using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class AlumnoRepetidoException : Exception
    {
        /// <summary>
        /// constructor por defecto que envia un mensaje a la base
        /// </summary>
        public AlumnoRepetidoException() : base("El alumno esta repetido")
        {

        }
    }
}
