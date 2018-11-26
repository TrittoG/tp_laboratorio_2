using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class TrackingIDRepetidoException : Exception
    {
        /// <summary>
        /// constructor publico que recibe un mensaje
        /// </summary>
        /// <param name="mensaje"></param>
        public TrackingIDRepetidoException(string mensaje) : this(mensaje, null)
        {

        }

        /// <summary>
        /// constructor publico que recibe un mensaje y el inner de una excepcion
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="inner"></param>
        public TrackingIDRepetidoException(string mensaje, Exception inner) :base(mensaje, inner)
        {

        }

    }
}
