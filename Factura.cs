using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_TP4
{
    internal class Factura
    {
        public Cotizacion Id_Cotizacion { get; set; }
        public Cliente CUIT { get; set; }
        public DateTime Fecha { get; set; }
        public bool Pagado { get; set; }

    }
}
