using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace grupoB_TP
{
    internal class Tarifa
    {
        public Dictionary<decimal, RangoDePesos> RangoDePesos { get; set; }
        public decimal RecargoUrgente { get; set; }
        public decimal RecargoRetiroEnPuerta { get; set; }
        public decimal RecargoEntregaEnPuerta { get; set; }
    }
    public static class ArchivoTarifas
    {
        private static void Cargar()
        {
            var datosTarifa = File.ReadLines("tarifas.txt").First().split(",");
            tarifa = new Tarifa
            {
                RecargoUrgente = decimal.Parse(datosTarifa[0]),
                RecargoRetiroEnPuerta = decimal.Parse(datosTarifa[1]),
                RecargoEntregaEnPuerta = decimal.Parse(datosTarifa[2]),
            };
            foreach (var linea in File.ReadLines("rangodepesos.txt"))
            {
                var datos = linea.Split(",");
                var min = decimal.Parse(datos[0]);
                tarifa.RangoDePesos[min] = new RangoDePeso
                {
                    [TipoPrecio.Local] = decimal.Parse(datos[2]),
                    [TipoPrecio.Provincial] = decimal.Parse(datos[3]),
                    [TipoPrecio.Regional] = decimal.Parse(datos[4]),
                    [TipoPrecio.Nacional] = decimal.Parse(datos[5]),
                };
            };
        }
    }
}
