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
                var proximoLinea = archivoCiudadesNacionales.ReadLine();
                string[] datosSeparados = proximoLinea.Split("|");

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
            foreach (CiudadadesNacionales c in ListaCiudadesNacionales)
            {
                if (c.Provincia.ToLower() == provincia.ToLower())
                {
                    ciudadesProvincia.Add(c);
                }
            }
            return ciudadesProvincia;
        }
    }
}