using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class SinProfesorException : Exception
    {
        /// <summary>
        /// constructor sin parametros que envia un mensaje a la base
        /// </summary>
        public SinProfesorException() : base("falta profesor para la clase")
        {

        }
    }
}
