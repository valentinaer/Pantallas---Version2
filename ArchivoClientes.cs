using Clases_TP4;

namespace Version_2___Pantallas
{
    internal static class ArchivoClientes
    {
        // Genera los objectos Clientes apartir del Archivo "ArchivoClientes.txt" y almacena en ListaClientes
        static List<Cliente> ListaClientes = new List<Cliente>();
        public static void CargarClientes()
        {
            using var archivo = new StreamReader("ArchivoClientes.txt");
            while (!archivo.EndOfStream)
            {
                var proximaLinea = archivo.ReadLine();
                if(string.IsNullOrEmpty(proximaLinea)) 
                {
                    Console.WriteLine("Error en clientes, excepcion null");
                    continue;
                }
                string[] datosSeparados = proximaLinea.Split("|");

                Cliente cliente = new Cliente();
                cliente.Cuit = datosSeparados[0];
                cliente.RazonSocial = datosSeparados[1];
                cliente.DireccionFacturacion = datosSeparados[2];
                cliente.SaldoFactura = float.Parse(datosSeparados[3]);

                ListaClientes.Add(cliente);
            }
        }

        // Busca el cliente apartir del CUIT ingresado
        public static Cliente BuscarCliente(string cuit)
        {
            return ListaClientes.Find(cliente => cliente.Cuit == cuit) ?? new Cliente();
        }

        // Genera el CUIT que sera utilizado dentro de la aplicacion
        public static void CrearCUITUsuarioActual(string cuit) 
        {
            Cliente.CuitUsuarioActual = cuit;
        }

    }
}