using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Archivos
{
    public interface IArchivo<T>
    {
        /// <summary>
        /// metodo de la interfas para guardar archivos genericos
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        bool Guardar(string archivo, T datos);

        /// <summary>
        /// metodo de la interfaz para leer archivos genericos
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        bool Leer(string archivo,out  T datos);
    }
}
