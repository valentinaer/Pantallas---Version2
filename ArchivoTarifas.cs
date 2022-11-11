namespace Version_2___Pantallas
{
    internal static class ArchivoTarifas
    {
        static List<Tarifas> ListaTarifa = new List<Tarifas>();
        internal static void CargasTarifas()
        {
            using var archivo = new StreamReader("Tarifas.txt");
            var encabezado = archivo.ReadLine();
            var regiones = encabezado.Split('|');
            //for (int i = 1; i<) ;
            while (!archivo.EndOfStream)
            {
                var linea = archivo.ReadLine();
                var DatosTarifas = linea!.Split('|');                        

                string Peso = DatosTarifas[0];

                for (int i = 1; i < regiones.Length; i++)
                {
                    Tarifas tarifas = new Tarifas();
                    tarifas.Peso = Peso;
                    tarifas.Region = regiones[i];
                    tarifas.Precio = Convert.ToDecimal(DatosTarifas[i]);

                    ListaTarifa.Add(tarifas);
                }
            }
        }
        public static string BuscarTarifa(string peso, string region)
        {
            string tarifaPrecio = "";
            using var archivo = new StreamReader("Tarifas.txt");
            var encabezado = archivo.ReadLine();
            var regiones = encabezado.Split('|');
            int regionIndex = 0;

            for (int j = 0; j < regiones.Length; j++)
            {
                if (regiones[j].ToLower() == region.ToLower())
                {
                    regionIndex = j;
                }
            }

            List<string> ListaTarifasIndividuales = new List<string>();
            for (int i = 0; i < ListaTarifa.Count; i++)
            {

                if (ListaTarifa[i].Peso.ToLower() == peso.ToLower())
                {
                    tarifaPrecio = Convert.ToString(ListaTarifa[i].Precio);
                    ListaTarifasIndividuales.Add(tarifaPrecio);
                }

            }
            return ListaTarifasIndividuales[regionIndex];

        }

    }
}