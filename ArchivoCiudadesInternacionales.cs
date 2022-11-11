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
                if(string.IsNullOrEmpty(proximaLinea)) 
                {
                    continue;
                }
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
            foreach (CiudadesInternacionales ciudad in ListaCiudadesI)
            {
                if(ciudad.Pais != null) {
                    if (ciudad.Pais.ToLower() == pais.ToLower())
                    {
                        ciudadesPais.Add(ciudad);
                    }
                } else {
                    MessageBox.Show("No se encontraron ciudades para el pais seleccionado");
                }

            }
            return ciudadesPais;
        }

        
    }
}