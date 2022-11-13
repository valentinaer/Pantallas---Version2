using Clases_TP4;

namespace Version_2___Pantallas
{
    internal static class ArchivoPadronClientes
    {
        // Genera los objectos Clientes apartir del Archivo "ArchivoClientes.txt" y almacena en ListaClientes
        static List<PadronClientes> ListaClientes = new List<PadronClientes>();
        public static void CargarClientes()
        {
            using var archivo = new StreamReader("ArchivoPadronClientes.txt");
            while (!archivo.EndOfStream)
            {
                var proximaLinea = archivo.ReadLine();
                if(string.IsNullOrEmpty(proximaLinea)) 
                {
                    Console.WriteLine("Error en clientes, excepcion null");
                    continue;
                }
                string[] datosSeparados = proximaLinea.Split("|");

                PadronClientes cliente = new PadronClientes();
                cliente.Cuit = datosSeparados[0];
                cliente.RazonSocial = datosSeparados[1];
                cliente.DireccionFacturacion = datosSeparados[2];

                ListaClientes.Add(cliente);
            }
            archivo.Close();
        }

        // Busca el cliente apartir del CUIT ingresado
        public static PadronClientes BuscarCliente(string cuit)
        {
            return ListaClientes.Find(cliente => cliente.Cuit == cuit) ?? new PadronClientes();
        }

        // Genera el CUIT que sera utilizado dentro de la aplicacion
        public static void CrearCUITUsuarioActual(string cuit) 
        {
            PadronClientes.CuitUsuarioActual = cuit;
        }

    }
}