using grupoB_TP;

namespace Version_2___Pantallas
{
    internal static class ArchivoSucursales
    {

        // Genera los objectos Sucursales apartir del Archivo "ArchivoSucursales.txt" y almacena en listaSucursales
        static List<Sucursales> listaSucursales = new List<Sucursales>();
        internal static void CargarSucursales()
        {
            //Estructura archivo:
            //NÚMERO | SUCURSAL | PROVINCIA | CIUDAD | REGIÓN | DIRECCIÓN

            using var archivo = new StreamReader("ArchivoSucursales.txt");
            while (!archivo.EndOfStream)
            {
                var proximaLinea = archivo.ReadLine();
                if (string.IsNullOrEmpty(proximaLinea))
                {
                    continue;
                }
                string[] datosSeparados = proximaLinea.Split("|");

                Sucursales sucursal = new Sucursales();
                sucursal.NroSucursal = int.Parse(datosSeparados[0]);
                sucursal.Provincia = datosSeparados[1];
                sucursal.Ciudad = datosSeparados[2];
                sucursal.NombreCalle = datosSeparados[3];
                sucursal.AlturaCalle = int.Parse(datosSeparados[4]);
                sucursal.Region = datosSeparados[5];


                listaSucursales.Add(sucursal);
            }
            archivo.Close();
        }


        // Busca las sucursales apartir del id de la provincia ingresada
        public static Sucursales BuscarSucursales(int id)
        {
            foreach (Sucursales sucursalBuscada in listaSucursales)
            {
                if (sucursalBuscada.NroSucursal == id)
                {
                    return sucursalBuscada;
                }
            }
            throw new ApplicationException("Codigo de Sucursal inexistente");

        }

        // Devuelve el listado completo de sucursales
        public static List<Sucursales> PedirLista()
        {
            return listaSucursales;
        }

    }
}