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
            while (!archivo.EndOfStream)
            {
                var line = archivo.ReadLine();
                var values = line.Split('|');

                Peso = values[0];

                for (int i = 1; i < values.Length; i++)
                {
                    Region = i.ToString();
                    Precio = Convert.ToDecimal(values[i]);
                    // if(Region == Paises Limitrofes	America Latina	America del Norte	Europa	Asia) 
                    if(Region == "Paices Limitrofes" || Region == "America Latina" || Region == "America del Norte" || Region == "Europa" || Region == "Asia")
                    {
                            // si es urgente sumamos 20% al precio
                            double precioUrgente = 0;
                            if (urgente)
                            {
                                precioUrgente = Convert.ToDouble(Precio) * Convert.ToDouble(recargosValues[0]);
                            }

                            // tope maximo de urgencia es 50, por eso si es mas alto sobre escribimos 50
                            if (precioUrgente > (Convert.ToDouble(Precio)  * Convert.ToDouble(recargosValues[0])))
                            {
                                precioUrgente = Convert.ToDouble(recargosValues[1]);
                            }

                            // retiro fijo es 30 y destino fijo 40
                            double precioFinal = Convert.ToDouble(Precio) + precioUrgente + Convert.ToDouble(recargosValues[2]) + Convert.ToDouble(recargosValues[3]);
                    }

                    ListaTarifa.Add(new Tarifas { Peso = Peso, Region = Region, Precio = Precio });
                }
            }
        }

        public decimal BuscarTarifa(string peso, string region, bool urgente )
        {
            CargasTarifas(urgente);
            decimal tarifaPrecio = 0;
            using var archivo = new StreamReader("Tarifas.txt");
            var encabezado = archivo.ReadLine();
            var regiones = encabezado.Split('|');
            MessageBox.Show(regiones[0], regiones[3]);
            
            for (int i = 0; i < ListaTarifa.Count; i++)
            {
                // loop regiones para buscar el indice de la region
                for (int j = 0; j < regiones.Length; j++)
                {
                    MessageBox.Show(regiones[j]);
                    if (regiones[j] == region)
                    {
                        if (ListaTarifa[i].Peso == peso)
                        {
                            tarifaPrecio = Convert.ToDecimal(ListaTarifa[i].ToString().Split("|")[j]);
                        }
                    }
                }
                
            }
            MessageBox.Show($"El precio es {tarifaPrecio}");
            return tarifaPrecio;

        }
    }
}