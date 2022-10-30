﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace grupoB_TP
{
    internal class Tarifa
    {
        public Dictionary<decimal, RangoDePesos> RangoDePeso { get; set; }
        public decimal RecargoUrgente { get; set; }
        public decimal RecargoRetiroEnPuerta { get; set; }
        public decimal RecargoEntregaEnPuerta { get; set; }
    }
    /*
    public static class ArchivoTarifas
    {
        /*
        private static void Cargar()
        {
            var datosTarifa = File.ReadLines("tarifas.txt").First().Split(",");
            tarifa = new Tarifa()
            {
                RecargoUrgente = decimal.Parse(datosTarifa[0]),
                RecargoRetiroEnPuerta = decimal.Parse(datosTarifa[1]),
                RecargoEntregaEnPuerta = decimal.Parse(datosTarifa[2]),
            };
            foreach (var linea in File.ReadLines("rangodepesos.txt"))
            {
                var datos = linea.Split(",");
                var min = decimal.Parse(datos[0]);
                Tarifa.RangoDePesos[min] = new RangoDePesos
                {
                    [TipoPrecio.Local] = decimal.Parse(datos[2]),
                    [TipoPrecio.Provincial] = decimal.Parse(datos[3]),
                    [TipoPrecio.Regional] = decimal.Parse(datos[4]),
                    [TipoPrecio.Nacional] = decimal.Parse(datos[5]),
                };
            }*/
}
    


