using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_TP4
{
    internal class Cliente
    {
        public static string CuitUsuarioActual { get; set; }
        public string Cuit { get; set; }
        public string RazonSocial { get; set; }
        public string DireccionFacturacion { get; set; }
        public float SaldoFactura { get; set; }

        //Método que me permite obtener el CUIT del usuario que utiliza el sistema//
        public static void CrearCUITUsuarioActual(string cuit) 
        {
            Cliente.CuitUsuarioActual = cuit;
        }
    }
}
