namespace Version_2___Pantallas
{
    internal static class ArchivoCiudadesInternacionales
    {
        static List<CiudadesInternacionales> ListaCiudadesI = new List<CiudadesInternacionales>();

        public static void CargarCiudadesInternacionales()
        {
            using var archivoCiudadesInternacionales = new StreamReader("CiudadesInternacionales.txt");

            while (!archivoCiudadesInternacionales.EndOfStream)
            {
                var proximaLinea = archivoCiudadesInternacionales.ReadLine();
                string[] datosSeparados = proximaLinea.Split("|");

                var CiudadInternacional = new CiudadesInternacionales();
                CiudadInternacional.Pais = datosSeparados[0];
                CiudadInternacional.Ciudad = datosSeparados[1];

                ListaCiudadesI.Add(CiudadInternacional);

            }
        }

        static List<CiudadesInternacionales> ciudadesPais = new List<CiudadesInternacionales>();

        public static List<CiudadesInternacionales> BuscarCiudades(string pais)
        {
            CiudadesInternacionales ciudades = new CiudadesInternacionales();
            foreach (CiudadesInternacionales c in ListaCiudadesI)
            {
                if (c.Pais.ToLower() == pais.ToLower())
                {
                    ciudadesPais.Add(c);
                }
            }
            return ciudadesPais;

        }
    }
}