using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grupoB_TP
{
    internal class Sucursales
    {
        public int numero { get; set; }
        public string sucursal { get; set; }
        public string provincia { get; set; }
        public string ciudad { get; set; }
        public string region { get; set; }
        public string direccion { get; set; }

        public Sucursales(
            int _numero,
            string _sucursal,
            string _provincia,
            string _ciudad,
            string _region,
            string _direccion
        )
        {

        }
        public Sucursales()
        {

        } 

        List<Sucursales> listaSucursales = new List<Sucursales>();

        public void CargarSucursales()
        {
            //Estructura archivo:
            //NÚMERO | SUCURSAL | PROVINCIA | CIUDAD | REGIÓN | DIRECCIÓN

            using var archivo = new StreamReader("Sucursales.txt");
            while (!archivo.EndOfStream)
            {
                var proximaLinea = archivo.ReadLine();
                string[] datosSeparados = proximaLinea.Split("|");

                Sucursales sucursal = new Sucursales();
                sucursal.numero = int.Parse(datosSeparados[0]);
                sucursal.sucursal = datosSeparados[1];
                sucursal.provincia = datosSeparados[2];
                sucursal.ciudad = datosSeparados[3];
                sucursal.region = datosSeparados[4];
                sucursal.direccion = datosSeparados[5];

                listaSucursales.Add(sucursal);
            }
        }

        public Sucursales BuscarSucursales(int id)
        {
            CargarSucursales();

            return listaSucursales.Find(c => c.numero == id);

        }

        public List<Sucursales> PedirLista()
        {
            CargarSucursales();
            return listaSucursales;
        }

    }
}
