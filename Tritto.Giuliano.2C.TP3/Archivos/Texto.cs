using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// metodo publico que guarda un archivo de texto
        /// </summary>
        /// <param name="archivo">path</param>
        /// <param name="datos">datos a guardar</param>
        /// <returns></returns>
        public bool Guardar(string archivo, string datos)
        {
            try
            {
                StreamWriter st = new StreamWriter(archivo);
                st.WriteLine(datos);
                st.Close();
                return true;
            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }
        }

        /// <summary>
        /// metodo publico que lee un archivo de texto
        /// </summary>
        /// <param name="archivo">path</param>
        /// <param name="datos">datos a leer</param>
        /// <returns></returns>
        public bool Leer(string archivo,out string datos)
        {
            try
            {
                StreamReader sr = new StreamReader(archivo);
                datos = sr.ReadToEnd();
                sr.Close();
                return true;
            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }

        }
    }
}
