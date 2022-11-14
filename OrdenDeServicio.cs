using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grupoB_TP
{
    internal class OrdenDeServicio
    {
        public int NumeroTrackeo { get; set; }
        public DateTime Fecha { get; set; }
        public string Cuit { get; set; } = string.Empty;
        public string TipoDeEnvio { get; set; } = string.Empty;
        public string PaisOrigen { get; set; } = string.Empty;
        public string ProvinciaOrigen { get; set; } = string.Empty;
        public string CiudadOrigen { get; set; } = string.Empty;
        public string CalleOrigen { get; set; } = string.Empty;
        public int AlturaOrigen { get; set; }
        public string PisodeptoOrigen { get; set; } = string.Empty;
        public string PaisDestino { get; set; } = string.Empty;
        public string ProvinciaDestino { get; set; } = string.Empty;
        public string CiudadDestino { get; set; } = string.Empty;
        public string CalleDestino { get; set; } = string.Empty;
        public int AlturaDestino { get; set; }
        public string PisodeptoDestino { get; set; } = string.Empty;
        public string RangoDePeso { get; set; } = string.Empty;
        public int CantidadDeBultos { get; set; }
        public string Urgente { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public string Facturado { get; set; } = string.Empty;

    }
}
