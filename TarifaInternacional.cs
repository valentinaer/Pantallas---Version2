using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grupoB_TP
{
    internal class TarifaInternacional
    {
        public Regiones Region { get; set; }
        public Dictionary<decimal, RangoDePeso> RangoDePesos { get; set; }
    }
}
