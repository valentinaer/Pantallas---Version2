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
        public string Direccion { get; set; } = string.Empty;

        public Sucursales(int nroSucursal, string sucursal, string provincia,
            string ciudad, string region, string direccion)
        {
            NroSucursal = nroSucursal;
            Provincia = provincia;
            Ciudad = ciudad;
            Region = region;
            Direccion = direccion;
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
                Direccion);
        }



    }
}
