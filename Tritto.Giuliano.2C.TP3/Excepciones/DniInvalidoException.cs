using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        /// <summary>
        /// mensaje que se envia
        /// </summary>
        private static string mensajeBase = "EL DNI ES INVALIDO";

        /// <summary>
        /// constructor sin parametros que llama al this con el mensaje
        /// </summary>
        public DniInvalidoException() :this(mensajeBase)
        {

        }

        /// <summary>
        /// constructor que recibe una excepcion y la envia al this junto con el mensaje
        /// </summary>
        /// <param name="e"></param>
        public DniInvalidoException(Exception e) :this(mensajeBase, e)
        {

        }

        /// <summary>
        /// constructor que recibe un mensaje y lo envia a la base
        /// </summary>
        /// <param name="mensaje"></param>
        public DniInvalidoException(string mensaje) : base(mensaje)
        {

        }

        /// <summary>
        /// constructor que recibe un mensaje y una excepcion y las envia a la base
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="e"></param>
        public DniInvalidoException(string mensaje, Exception e) :base(mensaje,e)
        {

        }
    }
}
