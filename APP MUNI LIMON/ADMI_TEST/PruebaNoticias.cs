using System;
using ADMI_TEST.Pruebas;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ADMI_TEST
{
    [TestClass]
    public class PruebaNoticias
    {
        [TestMethod]
        public void InsertarNoticia()
        {
            //Arrange
            String titulo = "Titulo 1";
            String descripcion = "Descripcion 1";
            String galeria = "/Imagen1.jpg";
            String fechaPublicacion = "25/01/2019";

            Boolean resultadoEsperado = true;
            Noticia NoticiaNueva = new Noticia();

            //Act
            var resultadoActual = NoticiaNueva.Insertar(titulo, descripcion, galeria, fechaPublicacion);

            //Assert
            Assert.AreEqual(resultadoEsperado, resultadoActual);
        }

        [TestMethod]
        public void LeerNoticia()
        {
            // Arrange
            Boolean resultadoEsperado = true;
            Noticia NoticiaNueva = new Noticia();

            // Act
            var resultadoActual = NoticiaNueva.Leer();

            // Assert
            Assert.AreEqual(resultadoEsperado, resultadoActual);
        }

        [TestMethod]
        public void BorrarNoticia()
        {
            //Arrange
            String titulo = "Titulo 1";
            Boolean resultadoEsperado = true;
            Noticia NoticiaNueva = new Noticia();

            //Act
            var resultadoActual = NoticiaNueva.Borrar(titulo);

            //Assert
            Assert.AreEqual(resultadoEsperado, resultadoActual);
        }
    }
}
