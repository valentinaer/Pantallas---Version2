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

        // public static List 
        //agrego saldo acá. Busco las facturas impagas con el ID, las sumo y obtengo el valor.

        List<Cliente> ListaClientes = new List<Cliente>(); //Va a almacenar todos los datos que se encuentra en Cliente.Txt

        public void CargarClientes()
        {
            //Estructura archivo:
            // CUIT | RAZON SOCIAL | DIRECCION | SALDO

            using var archivo = new StreamReader("Clientes.txt");
            while(!archivo.EndOfStream)
            {
                var proximaLinea = archivo.ReadLine();
                string[] datosSeparados = proximaLinea.Split("|");

                Cliente cliente = new Cliente();
                cliente.Cuit = datosSeparados[0];
                cliente.RazonSocial = datosSeparados[1];
                cliente.DireccionFacturacion = datosSeparados[2];
                cliente.SaldoFactura = float.Parse(datosSeparados[3]);

                ListaClientes.Add(cliente);
            }
        }

        public Cliente BuscarCliente(string cuit)
        {
            CargarClientes();

            return ListaClientes!.Find(c => c.Cuit == cuit);
            
        }

        //BuscarFacturasImpagas (string cuit)

        public static void CrearCUITUsuarioActual(string cuit)
        {
            CuitUsuarioActual = cuit;
        }

    }
}
