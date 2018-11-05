using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        /// <summary>
        /// constructor sin parametros que llama a la base por defecto
        /// </summary>
        public NacionalidadInvalidaException() : base()
        {

        }

        /// <summary>
        /// constructor que recibe un mensaje y lo envia a la base
        /// </summary>
        /// <param name="mensaje"></param>
        public NacionalidadInvalidaException(string mensaje) : base(mensaje)
        {

        }
    }
}
