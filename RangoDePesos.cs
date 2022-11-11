using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grupoB_TP
{
    class RangoDePesos
    {
        public decimal PesoMinimoKg { get; set; }
        public decimal PesoMaximoKg { get; set; }
        public Dictionary<TipoPrecio, decimal>? Precios{ get; set; } 
    }
}
