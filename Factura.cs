using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_TP4
{
    internal class Factura
    {
        public int Id_Factura { get; set; } //para identificarla
        public Cliente CUIT { get; set; }
        public DateTime Fecha { get; set; }
        public Cotizacion Id_Cotizacion { get; set; }
        public bool Pagado { get; set; }

    }
}
