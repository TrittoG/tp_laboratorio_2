using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases;

namespace TestsUnitarios
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Test que verifica que no se puedan cargar dos Paquetes con el mismo Tracking ID.
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            try
            {
                Paquete p = new Paquete("casa", "123");
                Paquete p2 = new Paquete("casa2", "123");

                Correo c = new Correo();

                c += p;
                c += p2;
            }
            catch(Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(TrackingIDRepetidoException));
            }
        }

        /// <summary>
        /// Test que prueba que la lista de paquetes esta instanciada
        /// </summary>
        [TestMethod]
        public void TestMethod2()
        {
            Correo c = new Correo();
            
            Assert.IsTrue(c.Paquetes != null);
           
        }
    }
}
