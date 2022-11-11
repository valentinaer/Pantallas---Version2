namespace Version_2___Pantallas
{
    internal static class ArchivoCiudadesNacionales
    {
        static List<CiudadadesNacionales> ListaCiudadesNacionales = new List<CiudadadesNacionales>();
        internal static void CargarCiudadesNacionales()
        {
            using var archivoCiudadesNacionales = new StreamReader("ArchivoCiudadesNacionales.txt");

            while (!archivoCiudadesNacionales.EndOfStream)
            {
                var proximaLinea = archivoCiudadesNacionales.ReadLine();
                string[] datosSeparados = proximaLinea!.Split("|");

                var CiudadesNacional = new CiudadadesNacionales();
                CiudadesNacional.Provincia = datosSeparados[0];
                CiudadesNacional.Ciudad = datosSeparados[1];
                CiudadesNacional.Region = datosSeparados[2];

                ListaCiudadesNacionales.Add(CiudadesNacional);
            }
        }
        public static string BuscarRegionNacional(string ciudad)
        {
            foreach(CiudadadesNacionales lugar in ListaCiudadesNacionales)
            {
                if (lugar.Ciudad.ToLower() == ciudad.ToLower())
                {
                    return lugar.Region;
                }

            }

            /*
            for (int i = 0; i < ListaCiudadesNacionales.Count; i++)
            {
                if (ListaCiudadesNacionales[i].Ciudad.ToLower() == ciudad.ToLower())
                {
                    MessageBox.Show(ListaCiudadesNacionales[i].Region);
                    return ListaCiudadesNacionales[i].Region;
                }
                
            }*/
            throw new ApplicationException("Codigo de Ciudad Nacional inesperado");
        }

        
        public static List<CiudadadesNacionales> BuscarCiudades(string provincia)
        {
            List<CiudadadesNacionales> ciudadesProvincia = new List<CiudadadesNacionales>();

            foreach (CiudadadesNacionales ciudades in ListaCiudadesNacionales)
            {
                if(ciudades.Provincia != null) {
                    if (ciudades.Provincia.ToLower() == provincia.ToLower())
                    {
                        ciudadesProvincia.Add(ciudades);
                    }
                } 
                else 
                {
                    MessageBox.Show("No se encontraron ciudades para la provincia seleccionada");
                }
            }
            return ciudadesProvincia;
            
        }
    }
}