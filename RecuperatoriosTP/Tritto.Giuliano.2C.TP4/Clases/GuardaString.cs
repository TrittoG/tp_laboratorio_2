using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Clases
{
    public static class GuardaString
    {
        /// <summary>
        /// metodo de extension para string que guarda los datos en un txt en escritorio
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="archivo"></param>
        /// <returns></returns>
        public static bool Guardar(this string texto, string archivo)
        {
           string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            StreamWriter sw = null;

            try
            {
                sw = new StreamWriter(path + "\\" + archivo);
                sw.WriteLine(texto);
                return true;
            }
            catch(FileNotFoundException e)
            {
                throw e;
            }
            finally
            {
                if(sw != null)
                    sw.Close();
            }
            
        }
    }
}
