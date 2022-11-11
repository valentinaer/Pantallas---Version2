using grupoB_TP;

namespace Version_2___Pantallas
{
    internal static class archivoRegionesInternacionales
    {
        static List<RegionesInternacionales> RegionInternacionales = new List<RegionesInternacionales>();
        public static void CargarRegionesInternacionales()
        {
            using var archivoRegionesInternacionales = new StreamReader("RegionesInternacionales.txt");

            while (!archivoRegionesInternacionales.EndOfStream)
            {
                var proximoLinea = archivoRegionesInternacionales.ReadLine();
                if (string.IsNullOrEmpty(proximoLinea))
                {
                    continue;
                }
                string[] datosSeparados = proximoLinea.Split("|");

                var regionInternacional = new RegionesInternacionales();
                regionInternacional.Pais = datosSeparados[0];

                regionInternacional.Continente = datosSeparados[1];

                RegionInternacionales.Add(regionInternacional);
            }
           // MessageBox.Show("El archivo RegionesInternacionales se cargo correctamente");
        }

        public static string BuscarRegion(string pais)
        {
            RegionesInternacionales region = new RegionesInternacionales();
            for (int i = 0; i < RegionInternacionales.Count; i++)
            {
                if (RegionInternacionales[i].Pais.ToLower() == pais.ToLower())
                {
                    region = RegionInternacionales[i];
                }
            }
            return region.Continente;

        }

        static List<string> ListaPaises = new List<string>();

        public static List<string> SoloPaises()
        {
            CargarRegionesInternacionales();

            foreach(RegionesInternacionales pais in RegionInternacionales)
            {
                ListaPaises.Add(pais.Pais);
            }

            return ListaPaises;

        }
        
    }
}