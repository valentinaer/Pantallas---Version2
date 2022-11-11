using grupoB_TP;

namespace Version_2___Pantallas
{
    internal static class ArchivoSucursales
    {
        static List<Sucursales> listaSucursales = new List<Sucursales>();
        internal static void CargarSucursales()
        {
            //Estructura archivo:
            //NÚMERO | SUCURSAL | PROVINCIA | CIUDAD | REGIÓN | DIRECCIÓN

            using var archivo = new StreamReader("ArchivoSucursales.txt");
            while (!archivo.EndOfStream)
            {
                var proximaLinea = archivo.ReadLine();
                if(string.IsNullOrEmpty(proximaLinea)) 
                {
                    continue;
                }
                string[] datosSeparados = proximaLinea.Split("|");

                Sucursales sucursal = new Sucursales();
                sucursal.Numero = int.Parse(datosSeparados[0]);
                sucursal.Sucursal = datosSeparados[1];
                sucursal.Provincia = datosSeparados[2];
                sucursal.Ciudad = datosSeparados[3];
                sucursal.Region = datosSeparados[4];
                sucursal.Direccion = datosSeparados[5];

                listaSucursales.Add(sucursal);
            }
        }

        public static Sucursales BuscarSucursales(int id)
        {
            return listaSucursales.Find(sucursal => sucursal.Numero == id) ?? new Sucursales();
        }

        public static List<Sucursales> PedirLista()
        {
            return listaSucursales;
        }

    }
}