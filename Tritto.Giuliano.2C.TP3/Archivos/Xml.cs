using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// metodo que guarda datos serializados
        /// </summary>
        /// <param name="archivo">path</param>
        /// <param name="datos">datos a guardar</param>
        /// <returns></returns>
        public bool Guardar(string archivo, T datos)
        {
            try
            {
                XmlTextWriter writer;
                XmlSerializer ser;

                writer = new XmlTextWriter(archivo, Encoding.UTF8);

                ser = new XmlSerializer(typeof(T));

                ser.Serialize(writer, datos);
                writer.Close();

                return true;
            }
            catch(ArchivosException e)
            {
                throw new ArchivosException(e);
            }

        }

        /// <summary>
        /// metodo que lee un archivo serializado
        /// </summary>
        /// <param name="archivo">path</param>
        /// <param name="datos">datos a leer</param>
        /// <returns></returns>
        public bool Leer(string archivo,out T datos)
        {
            try
            {
                XmlTextReader reader;
                XmlSerializer ser;

                reader = new XmlTextReader(archivo);
                ser = new XmlSerializer(typeof(T));
                datos = (T)ser.Deserialize(reader);
                reader.Close();
                return true;
            }
            catch(ArchivosException e)
            {
                throw new ArchivosException(e);
            }
        }
    }
}
