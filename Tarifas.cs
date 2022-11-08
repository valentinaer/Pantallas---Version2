namespace Version_2___Pantallas
{
    internal class Tarifas
    {

        public string Peso { get; set; }
        public string Region { get; set; }
        public decimal Precio { get; set; }
        public bool Urgente { get; set; }
        public bool costoFijo { get; set; }


        List<Tarifas> ListaTarifa = new List<Tarifas>();
        public void CargasTarifas(bool urgente)
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


        public Tarifas BuscarTarifa(string peso, string region, bool urgente )
        {
            string regionPrueba = "Local";
            CargasTarifas(urgente);
            Tarifas tarifaPrecio = new Tarifas();
            using var archivo = new StreamReader("Tarifas.txt");
            var encabezado = archivo.ReadLine();
            var regiones = encabezado.Split('|');
            MessageBox.Show("Peso: " + peso + "Region: " + region + "Urgente: " + urgente);
            
            for (int i = 0; i < ListaTarifa.Count; i++)
            {
                for (int j = 0; j < regiones.Length; j++)
                {
                    if (regiones[j] == regionPrueba)
                    {
                        MessageBox.Show("La tarifa es: " + regiones[j]);
                        if (ListaTarifa[i].Peso == peso)
                        {
                            tarifaPrecio = ListaTarifa[i];
                        }
                    }
                }
                
            }
            return tarifaPrecio;

        }
    }
}