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
                sucursal.NroSucursal = int.Parse(datosSeparados[0]);
                sucursal.Provincia = datosSeparados[1];
                sucursal.Ciudad = datosSeparados[2];
                sucursal.Direccion = datosSeparados[3];
                sucursal.Region = datosSeparados[4];
                

                listaSucursales.Add(sucursal);
            }
        }


        public static Sucursales BuscarSucursales(int id)
        {
            foreach ( Sucursales sucursalBuscada in listaSucursales)
            {
                if (sucursalBuscada.NroSucursal== id)
                {
                    return sucursalBuscada;
                }
            }
            throw new ApplicationException("Codigo de Sucursal inexistente");

        }

        public static List<Sucursales> PedirLista()
        {
            return listaSucursales;
        }

    }
}