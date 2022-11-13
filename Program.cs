using grupoB_TP;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.IO;



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
            ArchivoPadronClientes.CargarClientes();
            //ArchivoFacturas.CargarFacturas();
            ArchivoOrdenDeServicios.CargarOrdenDeServicio();
            ArchivoSucursales.CargarSucursales();
            ArchivoTarifas.CargasTarifas();
            ArchivoUsuario.CargarUsuarios();
            ArchivoPaisesInternacionales.CargarPaisesInternacionales();
            
            ApplicationConfiguration.Initialize();

            Application.Run(new AccesoAlSistema());

            ArchivoOrdenDeServicios.Grabar();
            
            //Application.Run(new EstadoDeCuenta());
            //Application.Run(new SolicitudDeServicio());
            //Application.Run(new EstadoDeServicio());
        }
    }
}