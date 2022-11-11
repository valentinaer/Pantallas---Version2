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
        public string CUIT { get; set; } = string.Empty;
        public DateTime FechaFactura { get; set; }
        public string Pagado { get; set; } = string.Empty; //"PAGADO" O "NO PAGADO"
        public int MontoFactura { get; set; }
    }

}


