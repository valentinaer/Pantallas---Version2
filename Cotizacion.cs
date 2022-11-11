using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_TP4
{
    internal class Cotizacion
    {
        public int Id_Cotizacion { get; set; }
        public int NumeroTrackeo { get; set; } //Correlativo (1,2,3...)
        public int CUIT { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public Direccion? Origen { get; set; }
        public Direccion? Destino { get; set; }
        public bool Urgente { get; set; }
        public bool Nacional { get; set; } //si es false, entonces internacional (este siempre tiene que estar en true)
        public string? RangoPeso { get; set; }
        public int CantidadBultos { get; set; }

        public int Id_Direccion { get; set; }
        
        //hay diferenciación de precio por ser nacional / internacional?
        public float PrecioCotizado { get; set; }

    }
}
