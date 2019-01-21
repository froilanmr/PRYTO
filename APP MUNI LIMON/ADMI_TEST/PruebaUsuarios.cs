using System;
using ADMI_TEST.Pruebas;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ADMI_TEST
{
    [TestClass]
    public class PruebaUsuarios
    {
        [TestMethod]
        public void InsertarUsuario()
        {
            //Arrange
            String Nombre = "Froilan Moya Robles";
            String Correo = "froilan@gmail.com";
            String Contraseña = "Froilan";
            int Telefono = 85893707;

            Boolean resultadoEsperado = true;
            Usuario UsuarioNuevo = new Usuario();

            //Act
            var resultadoActual = UsuarioNuevo.Insertar(Nombre, Correo, Contraseña, Telefono);

            //Assert
            Assert.AreEqual(resultadoEsperado, resultadoActual);
        }
    }
}
