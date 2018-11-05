﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        /// <summary>
        /// constructor que recibe un inner que es enviado a la base junto con un mensaje
        /// </summary>
        /// <param name="innerException"></param>
        public ArchivosException(Exception innerException) : base("error en el archivo", innerException)
        {

        }
    }
}
