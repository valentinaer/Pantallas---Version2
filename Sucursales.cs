using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grupoB_TP
{
    internal class Sucursales
    {
        public int NroSucursal { get; set; }
        public string Provincia { get; set; } = string.Empty;
        public string Ciudad { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public string NombreCalle { get; set; } = string.Empty;       
        public int  AlturaCalle { get; set; } 

        public Sucursales(int nroSucursal, string sucursal, string provincia,
            string ciudad, string region, string direccion, int alturaCalle)
        {
            NroSucursal = nroSucursal;
            Provincia = provincia;
            Ciudad = ciudad;
            Region = region;
            NombreCalle = direccion;
            AlturaCalle = alturaCalle;
        }
        public Sucursales()
        {

        }
        public override string ToString()
        {
            return string.Format("{0} - {1} - {2} - {3} - {4} - {5} ",
                NroSucursal,
                Provincia,
                Ciudad,
                Region,
                NombreCalle,
                AlturaCalle);
        }
    }
}
