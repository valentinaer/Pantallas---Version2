using grupoB_TP;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Version_2___Pantallas
{
    internal static class Program
    {
        //Repositorio: https://github.com/valentinaer/Pantallas---Version2
        [STAThread]
        static void Main()
        {

            //Recargos.CargarRecargos();
            //Tarifas.CargasTarifas();



            //                CargaOrdendeServicio();
            //    CargarCiudadesNacionales();
            //   CargarClientes();
            /* Tenemos que cargar    Planillas
            Orden de Servicio
            Usuario Factura

            tarifa
            cliente

            *
            */


            ApplicationConfiguration.Initialize();

            //Application.Run(new AccesoAlSistema());

            //Application.Run(new EstadoDeCuenta());

            Application.Run(new SolicitudDeServicio());
            //Application.Run(new EstadoDeServicio());

            //Application.Run(new SolicitudDeServicio());

        } 
    }
}