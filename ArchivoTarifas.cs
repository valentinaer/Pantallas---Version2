namespace Version_2___Pantallas
{
    internal static class ArchivoTarifas
    {
        static List<Tarifas> ListaTarifa = new List<Tarifas>();
        internal static void CargasTarifas()
        {
            var lineasLeer = File.ReadLines("ArchivoTarifas.txt");
            var encabezado = lineasLeer.First();
            var regiones = encabezado.Split('|');
            foreach (var linea in lineasLeer.Skip(1))
            {
                var datos = linea.Split('|');
                string Peso = datos[0];

                for (int i = 1; i < datos.Length; i++)
                {
                    var tarifa = new Tarifas();
                    tarifa.Peso = Peso;
                    tarifa.Region = regiones[i];
                    tarifa.Precio = decimal.Parse(datos[i]);
                    ListaTarifa.Add(tarifa);
                }
            }
        }

        public static string BuscarTarifa(string peso, string region)
        {
            foreach (var tarifa in ListaTarifa)
            {
                if (tarifa.Peso.ToLower() == peso.ToLower() && tarifa.Region.ToLower() == region.ToLower())
                {
                    return tarifa.Precio.ToString();
                }
            }
            return "0";
        }
    }
}