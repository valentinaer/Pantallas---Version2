﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_TP4
{
    internal class Cliente
    {
        public int Cuit { get; set; }
        public string RazonSocial { get; set; }
        public Direccion DireccionFacturacion { get; set; }
        public float Saldo { get; set; }
        
        //agrego saldo acá. Busco las facturas impagas con el ID, las sumo y obtengo el valor.


    }
}
