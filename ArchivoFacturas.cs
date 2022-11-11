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
                if(string.IsNullOrEmpty(proximaLinea)) 
                {
                    Console.WriteLine("Error en facturas, excepcion null"); 
                    continue;
                }
                string[] datosSeparados = proximaLinea.Split("|");

                Factura factura = new Factura();
                factura.NroFactura = int.Parse(datosSeparados[0]);

                // ERROR ACA ENTONCES ROMPE PROGRAM, PROBABLEMENTE PORQUE NO FUNCIONA EL PARSE
                //factura.FechaFactura = DateTime.ParseExact(datosSeparados[1],"MM/DD/YYYY",null);
                factura.CUIT = datosSeparados[2];
                factura.Pagado = datosSeparados[3];
                factura.MontoFactura = int.Parse(datosSeparados[4]);

                ListaFacturas.Add(factura);
            }

        }

        public static List<Factura> BuscarFacturaCliente(string cuit)
        {
            return ListaFacturas.FindAll(factura => factura.CUIT == cuit);
        }

        public static List<Factura> BuscarFacturasImpagas(string cuit)
        {
            return ListaFacturas.FindAll(factura => factura.CUIT == cuit && factura.Pagado == "NO PAGADO");
        }
    }
}