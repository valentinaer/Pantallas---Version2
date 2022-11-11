using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_TP4
{
    internal class Direccion
    {

        public int Id_Direccion { get; set; } //contador. guarda en el momento 
        public string? Provincia { get; set; }
        public string? Ciudad { get; set; }
        public string? NombreCalle { get; set; }
        public int Altura { get; set; }
        public string? PisoDepto { get; set; }
        public string? Region { get; set; }
        public string? Tipo { get; set; } //sucursal, centro de distribución o domicilio
        public string? Destinatario { get; set; }


    }
}
