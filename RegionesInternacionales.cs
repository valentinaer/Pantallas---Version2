// create a class to handle attributes pais and continent from RegionesInternacionales.txt, function to load data and search for
// the region of the country
namespace Version_2___Pantallas
{
    internal class RegionesInternacionales
    {
        public string Pais { get; set; }
        public string Continente { get; set; }

        List<RegionesInternacionales> RegionInternacionales = new List<RegionesInternacionales>();
        public void CargarRegionesInternacionales()
        {
            using var archivoRegionesInternacionales = new StreamReader("./RegionesInternacionales.txt");

            while (!archivoRegionesInternacionales.EndOfStream)
            {
                var proximoLinea = archivoRegionesInternacionales.ReadLine();
                string[] datosSeparados = proximoLinea.Split("|");

                var regionInternacional = new RegionesInternacionales();
                regionInternacional.Pais = datosSeparados[0];

                regionInternacional.Continente = datosSeparados[1];

                RegionInternacionales.Add(regionInternacional);
            }
            MessageBox.Show("El archivo RegionesInternacionales se cargo correctamente");
        }

        public RegionesInternacionales BuscarRegion(string pais)
        {
            CargarRegionesInternacionales();
            RegionesInternacionales region = new RegionesInternacionales();
            for (int i = 0; i < RegionInternacionales.Count; i++)
            {
                if (RegionInternacionales[i].Pais == pais)
                {
                    region = RegionInternacionales[i];
                }
            }
            return region;
        }
    }
}