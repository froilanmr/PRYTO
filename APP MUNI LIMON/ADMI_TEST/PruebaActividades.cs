using System;
using ADMI_TEST.Pruebas;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ADMI_TEST
{
    [TestClass]
    public class PruebaActividades
    {
        [TestMethod]
        public void InsertarActividad()
        {
            //Arrange
            String nombre = "Actividad 1";
            String tipo = "Tipo 1";
            String fecha = "01/12/2019";
            String direccion = "Direccion 1";
            String descripcion = "Descripcion 1";
            String galeria = "/Imagen1.jpg";
            int cupos = 50;

            Boolean resultadoEsperado = true;
            Actividad ActividadNueva = new Actividad();

            //Act
            var resultadoActual = ActividadNueva.Insertar(nombre, tipo, fecha,
                direccion, descripcion, galeria, cupos);

            //Assert
            Assert.AreEqual(resultadoEsperado, resultadoActual);
        }

        [TestMethod]
        public void LeerActividad()
        {
            // Arrange
            Boolean resultadoEsperado = true;
            Actividad TipoNuevo = new Actividad();

            // Act
            var resultadoActual = TipoNuevo.Leer();

            // Assert
            Assert.AreEqual(resultadoEsperado, resultadoActual);
        }

        [TestMethod]
        public void BorrarActividad()
        {
            //Arrange
            String nombre = "Tipo 1";
            Boolean resultadoEsperado = true;
            Actividad TipoNuevo = new Actividad();

            //Act
            var resultadoActual = TipoNuevo.Borrar(nombre);

            //Assert
            Assert.AreEqual(resultadoEsperado, resultadoActual);
        }
    }
}
