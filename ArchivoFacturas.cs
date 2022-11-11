using Clases_TP4;

namespace Version_2___Pantallas
{
    internal static class ArchivoFacturas
    {
        static List<Factura> ListaFacturas = new List<Factura>();
        public static void CargarFacturas()
        {
            using var archivo = new StreamReader("Factura.txt");
            while (!archivo.EndOfStream)
            {
                var proximaLinea = archivo.ReadLine();
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

        public static List<Factura> BuscarFacturaCliente(string cuit)
        {
            CargarFacturas();

            return ListaFacturas.FindAll(f => f.CUIT == cuit);
        }

        public static List<Factura> BuscarFacturasImpagas(string cuit)
        {
            CargarFacturas();

            return ListaFacturas.FindAll(f => f.CUIT == cuit && f.Pagado == "NO PAGADO");
        }
    }
}