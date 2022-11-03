using grupoB_TP;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Version_2___Pantallas
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            //Repositorio: https://github.com/valentinaer/Pantallas---Version2

            static void CargarElementos()
            {
                CargaOrdendeServicio();
                CargarCiudadesNacionales();
                CargarClientes();
                /* Tenemos que cargar    Planillas
                Orden de Servicio
                Usuario Factura

                tarifa
                cliente

                *
                */
            }
            ApplicationConfiguration.Initialize();
            Application.Run(new EstadoDeCuenta());

            //Application.Run(new EstadoDeCuenta());
            //Application.Run(new SolicitudDeServicio());
            
            static void Grabar()
            {

            }

        }

        private static void CargarClientes()
        {
            throw new NotImplementedException();
        }

        static List<CiudadadesNacionales> CiudadesNacionales = new List<CiudadadesNacionales>();

        private static void CargarCiudadesNacionales()
        {
            using var archivoCiudadesNacionales = new StreamReader("./CiudadesNacionales.txt");

            while (!archivoCiudadesNacionales.EndOfStream)
            {
                var proximoLinea = archivoCiudadesNacionales.ReadLine();
                string[] datosSeparados = proximoLinea.Split("|");

                var ciudadNacional = new CiudadadesNacionales();
                ciudadNacional.Ciudad = datosSeparados[0];

                ciudadNacional.Provincia = datosSeparados[1];

                ciudadNacional.Region = datosSeparados[2];

                CiudadesNacionales.Add(ciudadNacional);
            }
            MessageBox.Show("El archivo Ciudades se cargo correctamente");
        }

        private static void CargaOrdendeServicio()
        {
            throw new NotImplementedException();
        }
    }
}