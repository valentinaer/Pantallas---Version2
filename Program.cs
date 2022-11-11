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
            //Cargo TODOS LOS ARCHIVOS
            ArchivoCiudadesNacionales.CargarCiudadesNacionales();
            ArchivoCiudadesInternacionales.CargarCiudadesInternacionales();
            ArchivoClientes.CargarClientes();
            //ArchivoFacturas.CargarFacturas();
            ArchivoOrdenDeServicio.CargarOrdenDeServicio();
            ArchivoRecargos.CargarRecargos();         
            ArchivoSucursales.CargarSucursales();
            ArchivoTarifas.CargasTarifas();
            ArchivoUsuario.CargarUsuarios();



            ApplicationConfiguration.Initialize();

            //Application.Run(new AccesoAlSistema());
            //Application.Run(new EstadoDeCuenta());
            Application.Run(new SolicitudDeServicio());
            //Application.Run(new EstadoDeServicio());

            //GRABO TODOS LOS ARCHIVOS


        } 
    }
}