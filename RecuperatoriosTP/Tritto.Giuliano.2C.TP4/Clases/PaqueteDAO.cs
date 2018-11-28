using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Clases
{
    public static class PaqueteDAO
    {
         static SqlCommand comando;
         static SqlConnection coneccion;

        /// <summary>
        /// Constructor estatico que inicia la coneccion con el servidor
        /// </summary>
        static PaqueteDAO()
        {
            coneccion = new SqlConnection("Data Source= .\\SQLEXPRESS; Initial Catalog = correo-sp-2017; Integrated Security = True");
            comando = new SqlCommand();

            comando.CommandType = System.Data.CommandType.Text;
            comando.Connection = coneccion;
        }

        /// <summary>
        /// metodo estatico que guarda un paquete dentro de la base de datos
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool Insertar(Paquete p)
        {
            try
            {
                string consulta;

                consulta = "INSERT INTO Paquetes (direccionEntrega, trackingID, alumno)  VALUES('" + p.DireccionEntrega + "', '" + p.TrackingID + "', 'Giuliano Tritto')";

                comando.CommandText = consulta;
                coneccion.Open();
                comando.ExecuteNonQuery();  
                return true;
            }
            catch(Exception e)
            {
                throw new Exception("ERROR AL CARGAR BASE DE DATOS", e.InnerException);
            }
            finally
            {
                coneccion.Close();
            }
        }
    }
}
