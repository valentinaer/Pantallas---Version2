using Clases_TP4;

namespace Version_2___Pantallas
{
    internal static class ArchivoFacturas
    {

        // Genera los objectos Facturas apartir del Archivo "ArchivoFacturas.txt" y almacena en ListaFacturas
        static List<Factura> ListaFacturas = new List<Factura>();
        public static void CargarFacturas()
        {
            using var archivo = new StreamReader("ArchivoFacturas.txt");
            while (!archivo.EndOfStream)
            {

                var proximaLinea = archivo.ReadLine();
                if (string.IsNullOrEmpty(proximaLinea))
                {
                    Console.WriteLine("Error en facturas, excepcion null");
                    continue;
                }
                string[] datosSeparados = proximaLinea.Split("|");

                Factura factura = new Factura();
                factura.NroFactura = int.Parse(datosSeparados[0]);
                factura.FechaFactura = DateTime.Parse(datosSeparados[1]);
                factura.CUIT = datosSeparados[2];
                factura.Pagado = datosSeparados[3];
                factura.MontoFactura = int.Parse(datosSeparados[4]);

                ListaFacturas.Add(factura);
            }

        }

        // Busca las facturas apartir del cuit ingresado
        public static List<Factura> BuscarFacturaCliente(string cuit)
        {
            return ListaFacturas.FindAll(factura => factura.CUIT == cuit);
        }

        // Busca las facturas Impagas apartir del cuit ingresado
        public static List<Factura> BuscarFacturasImpagas(string cuit)
        {
            return ListaFacturas.FindAll(factura => factura.CUIT == cuit && factura.Pagado == "NO PAGADO");
        }
    }
}