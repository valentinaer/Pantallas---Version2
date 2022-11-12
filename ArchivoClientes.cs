using Clases_TP4;

namespace Version_2___Pantallas
{
    internal static class ArchivoClientes
    {
        static List<Cliente> ListaClientes = new List<Cliente>();
        public static void CargarClientes()
        {
            using var archivo = new StreamReader("Clientes.txt");
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

        public static Cliente BuscarCliente(string cuit)
        {
            return ListaClientes.Find(cliente => cliente.Cuit == cuit) ?? new Cliente();
        }

        public static void CrearCUITUsuarioActual(string cuit) 
        {
            Cliente.CuitUsuarioActual = cuit;
        }

    }
}