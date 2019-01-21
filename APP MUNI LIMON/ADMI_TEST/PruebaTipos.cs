using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ADMI_TEST
{
    [TestClass]
    public class TiposTest
    {
        [TestMethod]
        public void InsertarTipoDeActividades()
        {
            //Arrange
            String nombre = "Tipo 1";
            String descripcion = "Descripcion 1";
            Boolean resultadoEsperado = true;
            TipoActividad TipoNuevo = new TipoActividad();

            //Act
            var resultadoActual = TipoNuevo.Insertar(nombre, descripcion);

            //Assert
            Assert.AreEqual(resultadoEsperado, resultadoActual);
        }

        [TestMethod]
        public void LeerTipoDeActividades()
        {
            // Arrange
            Boolean resultadoEsperado = true;
            TipoActividad TipoNuevo = new TipoActividad();

            // Act
            var resultadoActual = TipoNuevo.Leer();

            // Assert
            Assert.AreEqual(resultadoEsperado, resultadoActual);
        }

        [TestMethod]
        public void BorrarTipoDeActividades()
        {
            //Arrange
            String nombre = "Tipo 1";
            Boolean resultadoEsperado = true;
            TipoActividad TipoNuevo = new TipoActividad();

            //Act
            var resultadoActual = TipoNuevo.Borrar(nombre);

            //Assert
            Assert.AreEqual(resultadoEsperado, resultadoActual);
        }
    }
}
