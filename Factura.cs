using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_TP4
{
    internal class Factura
    {
        public int NroFactura { get; set; }
        public string CUIT { get; set; }
        public DateTime FechaFactura { get; set; }
        public string Pagado { get; set; }
        public int MontoFactura { get; set; }

        List<Factura> ListaFacturas = new List<Factura>();
    public void CargarFacturas()
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
        public List<Factura> BuscarFacturaCliente(string cuit)
        {
            CargarFacturas();

            return ListaFacturas.FindAll(f => f.CUIT == cuit);
        }

        public List<Factura> BuscarFacturasImpagas(string cuit)
        {
            CargarFacturas();

            return ListaFacturas.FindAll(f => f.CUIT == cuit && f.Pagado == "NO PAGADO");
        }

    }

}


