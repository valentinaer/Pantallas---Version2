using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grupoB_TP
{
    internal class Sucursales
    {
        public int Numero { get; set; }
        public string Sucursal { get; set; }
        public string Provincia { get; set; }
        public string Ciudad { get; set; }
        public string Region { get; set; }
        public string Direccion { get; set; }

        public Sucursales(
            int _numero,
            string _sucursal,
            string _provincia,
            string _ciudad,
            string _region,
            string _direccion
        )
        {

        }
        public Sucursales()
        {

        } 



    }
}
