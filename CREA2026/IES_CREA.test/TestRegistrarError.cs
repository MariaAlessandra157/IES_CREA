using System;
using System.IO;
using IES_CREA.infrastructure.Contexto;
using Xunit;

namespace IES_CREA.test
{
    public class TestRegistrarError
    {
        private readonly string _rutaBase = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ErrorLog");

        [Fact]
        public void RegistrarErrores_DeberiaCrearCarpetaYArchivo()
        {
            var exception = new Exception("Error de prueba");
            var fecha = DateTime.Now;
            var carpetaEsperada = fecha.ToString("yyyy-MM-dd");

            ArchivoLog.RegistrarError(exception);

            string rutaCarpeta = Path.Combine(_rutaBase, carpetaEsperada);
            bool carpetaExiste = Directory.Exists(rutaCarpeta);

            var archivos = Directory.Exists(rutaCarpeta) ? Directory.GetFiles(rutaCarpeta, "*.txt") : Array.Empty<string>();
            bool archivoExiste = archivos.Length > 0;

            Assert.True(carpetaExiste, "La carpeta de logs no se creó.");
            Assert.True(archivoExiste, "No se creó ningun archivo de Log");
        }
    }
}

