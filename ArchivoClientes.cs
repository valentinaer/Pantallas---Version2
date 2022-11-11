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
            CargarClientes();

            return ListaClientes!.Find(c => c.Cuit == cuit);

        }






    }
}