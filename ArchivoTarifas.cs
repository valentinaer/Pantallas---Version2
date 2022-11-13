namespace Version_2___Pantallas
{
    internal static class ArchivoTarifas
    {

        // Genera los objectos Tarifas apartir del Archivo "ArchivoTarifas.txt" y almacena en ListaTarifas
        static List<Tarifas> ListaTarifa = new List<Tarifas>();
        internal static void CargasTarifas()
        {
            var lineasLeer = File.ReadLines("ArchivoTarifas.txt");
            // Se extrae el encabezado en la primera lines para poder asignar la region
            var encabezado = lineasLeer.First();
            var regiones = encabezado.Split('|');

            // Loop a nivel de linea
            foreach (var linea in lineasLeer.Skip(1))
            {
                var datos = linea.Split('|');
                string Peso = datos[0]; // Peso es el primer valor de la linea y va a ser el mismo para todas las regiones

                // Loop a nivel de columna (Regiones)
                for (int i = 1; i < datos.Length; i++)
                {
                    var tarifa = new Tarifas();
                    tarifa.DescPeso = Peso;
                    tarifa.Region = regiones[i];
                    tarifa.Precio = decimal.Parse(datos[i]);
                    ListaTarifa.Add(tarifa);
                }
            }
        }

        // Busca el precio de la tarifa apartir del peso y la region ingresada
        public static string BuscarTarifa(string peso, string region)
        {
            foreach (var tarifa in ListaTarifa)
            {
                if (tarifa.DescPeso.ToLower() == peso.ToLower() && tarifa.Region.ToLower() == region.ToLower())
                {
                    return tarifa.Precio.ToString();
                }
            }
            return "0";
        }
    }
}