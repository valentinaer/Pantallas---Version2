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
                if(string.IsNullOrEmpty(proximaLinea)) 
                {
                    continue;
                }
                string[] datosSeparados = proximaLinea.Split("|");

                var CiudadesNacional = new CiudadadesNacionales();
                CiudadesNacional.Provincia = datosSeparados[0];
                CiudadesNacional.Ciudad = datosSeparados[1];
                CiudadesNacional.Region = datosSeparados[2];

                ListaCiudadesNacionales.Add(CiudadesNacional);
            }
        }
        public static CiudadadesNacionales BuscarRegion(string ciudad)
        {
            //CORREGIR LO HECHO EN CLASE
            CiudadadesNacionales region = new CiudadadesNacionales();
            for (int i = 0; i < ListaCiudadesNacionales.Count; i++)
            {
                if (ListaCiudadesNacionales[i].Ciudad == ciudad)
                {
                    region = ListaCiudadesNacionales[i];
                }
            }
            return region;
        }
        static List<CiudadadesNacionales> ciudadesProvincia = new List<CiudadadesNacionales>();
        public static List<CiudadadesNacionales> BuscarCiudades(string provincia)
        {
            CiudadadesNacionales ciudades = new CiudadadesNacionales();
            foreach (CiudadadesNacionales ciudad in ListaCiudadesNacionales)
            {
                if(ciudad.Provincia != null) {
                    if (ciudad.Provincia.ToLower() == provincia.ToLower())
                    {
                        ciudadesProvincia.Add(ciudad);
                    }
                } else {
                    MessageBox.Show("No se encontraron ciudades para la provincia seleccionada");
                }

            }
            return ciudadesProvincia;
        }
    }
}