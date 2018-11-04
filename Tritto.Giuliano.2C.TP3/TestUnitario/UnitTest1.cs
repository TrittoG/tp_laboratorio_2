using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Instaniables;
using Excepciones;
using Archivos;

namespace TestUnitario
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestValorNumerico()
        {
            try
            {
                Alumno al = new Alumno(1, "Giuliano", "Tritto", "-1", ClasesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            }
            catch(Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
                //Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }
        }

        [TestMethod]
        public void TestExcepciones()
        {
            try
            {
                Texto txt = new Texto();
                string a = "";

                txt.Leer("noExiste", out a);
            }
            catch(Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(ArchivosException));
            }
        }

        [TestMethod]
        public void TestExcepcionesII()
        {
            try
            {
                Universidad uni = new Universidad();
                Alumno al1 = new Alumno(2, "Giuliano", "Tritto", "123123", ClasesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Legislacion);
                Alumno al2 = new Alumno(2, "Giuliano", "Tritto", "123123", ClasesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Legislacion);

                uni += al1;
                uni += al2;
            }
            catch(Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(AlumnoRepetidoException));
            }
        }

        [TestMethod]
        public void TestValorNulo()
        {
            Alumno al = new Alumno();

            Assert.IsNull(al.Nombre);
            
        }
    }
}
