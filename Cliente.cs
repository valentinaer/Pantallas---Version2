using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_TP4
{
    internal static class Cliente
    {
        public static string CuitUsuarioActual { get; set; }
        public static string Cuit { get; set; }
        public static string RazonSocial { get; set; }
        public static string DireccionFacturacion { get; set; }
        public static float SaldoFactura { get; set; }
        
        // public static List 
        //agrego saldo acá. Busco las facturas impagas con el ID, las sumo y obtengo el valor.
        public  static void CargarClientes()
        {
            throw new NotImplementedException();
        }
        public  static void CrearCUITUsuarioActual(string cuit)
        {
            CuitUsuarioActual = cuit;
        }

    }
}
