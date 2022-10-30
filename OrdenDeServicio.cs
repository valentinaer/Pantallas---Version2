﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_TP4
{
    internal class OrdenDeServicio
    {
        public int Id_Cotizacion { get; set; }
        public bool Aprobado { get; set; }
        public string Estado { get; set; }
        public int Id_Trackeo { get; set; } //Correlativo (1,2,3...)
        public Cliente CUIT { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public Direccion Origen { get; set; }
        public Direccion Destino { get; set; }
        public bool Urgente { get; set; }
        public bool TipoDeEnvio{ get; set; } //NACIONAL = TRUE  y INTERNACIONAL =FALSE si es false, entonces internacional (este siempre tiene que estar en true)
        public string RangoPeso { get; set; }
        public int CantidadBultos { get; set; }

    }
}
