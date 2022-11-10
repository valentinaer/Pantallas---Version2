namespace Version_2___Pantallas
{
    internal class Tarifas
    {
        public string Peso { get; set; }
        public string Region { get; set; }
        public decimal Precio { get; set; }
        public bool costoFijo { get; set; }


        List<Tarifas> ListaTarifa = new List<Tarifas>();
        public void CargasTarifas()
        {
            using var recargos = new StreamReader("Recargos.txt");
            var recargosLine = recargos.ReadLine();
            var recargosValues = recargosLine.Split('|');

            using var archivo = new StreamReader("Tarifas.txt");
            var encabezado = archivo.ReadLine();
            var regiones = encabezado.Split('|');
            while (!archivo.EndOfStream)
            {
                var line = archivo.ReadLine();
                var values = line.Split('|');

                Peso = values[0];

                for (int i = 1; i < regiones.Length; i++)
                {
                    Region = regiones[i];
                    Precio = Convert.ToDecimal(values[i]);
                    
                    ListaTarifa.Add(new Tarifas { Peso = Peso, Region = Region, Precio = Precio });
                }
            }
        }

        public string BuscarTarifa(string peso, string region)
        {
            CargasTarifas();
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