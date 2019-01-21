using System;
using ADMI_TEST.Pruebas;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ADMI_TEST
{
    [TestClass]
    public class PruebaSugerencias
    {
        [TestMethod]
        public void InsertarSugerencia()
        {
            //Arrange
            
            String Correo = "froilan@gmail.com";
            String TipoTramite = "Planilla";
            String Descripcion = "Descripcion 1";
            int Telefono = 85893707;
            int Valoracion = 50;
            int Anonima = 1;

            Boolean resultadoEsperado = true;
            Sugerencia SugerenciaNueva = new Sugerencia();

            //Act
            var resultadoActual = SugerenciaNueva.Insertar(Correo, TipoTramite, Descripcion,
                Telefono, Valoracion, Anonima);

            //Assert
            Assert.AreEqual(resultadoEsperado, resultadoActual);
        }

        [TestMethod]
        public void LeerSugerencia()
        {
            // Arrange
            Boolean resultadoEsperado = true;
            Actividad SugerenciaNueva = new Actividad();

            // Act
            var resultadoActual = SugerenciaNueva.Leer();

            // Assert
            Assert.AreEqual(resultadoEsperado, resultadoActual);
        }

        [TestMethod]
        public void BorrarSugerencia()
        {
            //Arrange
            String Correo = "froilan@gmail.com";
            String Descripcion = "Descripcion 1";
            Boolean resultadoEsperado = true;
            Sugerencia SugerenciaNueva = new Sugerencia();

            //Act
            var resultadoActual = SugerenciaNueva.Borrar(Correo, Descripcion);

            //Assert
            Assert.AreEqual(resultadoEsperado, resultadoActual);
        }
    }
}
