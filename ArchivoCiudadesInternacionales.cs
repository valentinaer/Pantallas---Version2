namespace Version_2___Pantallas
{
    internal static class ArchivoCiudadesInternacionales
    {
        static List<CiudadesInternacionales> ListaCiudadesI = new List<CiudadesInternacionales>();

        // Genera los objectos CiudadesInternacionales apartir del Archivo "ArchivoCiudadesInternacionales.txt" y almacena en ListaCiudadesI
        public static void CargarCiudadesInternacionales()
        {
            using var archivoCiudadesInternacionales = new StreamReader("ArchivoCiudadesInternacionales.txt");

            while (!archivoCiudadesInternacionales.EndOfStream)
            {
                var proximaLinea = archivoCiudadesInternacionales.ReadLine();
                string[] datosSeparados = proximaLinea!.Split("|");

                var CiudadInternacional = new CiudadesInternacionales();
                CiudadInternacional.Pais = datosSeparados[0];
                CiudadInternacional.Ciudad = datosSeparados[1];
                CiudadInternacional.Region = datosSeparados[2];

                ListaCiudadesI.Add(CiudadInternacional);
            }
            archivoCiudadesInternacionales.Close();
        }

        // Busca la region de la ciudad internacional apartir de la ciudad ingresada
        public static string BuscarRegionInternacional(string ciudad)
        {
            for (int i = 0; i < ListaCiudadesI.Count; i++)
            {
                if (ListaCiudadesI[i].Ciudad.ToLower() == ciudad.ToLower())
                {
                    return ListaCiudadesI[i].Region!;
                }
            }
            throw new ApplicationException("Codigo de Ciudad INTERNACIONAL inesperado");
        }

        // Busca las ciudades Internacionales apartir de un pais ingresado 
        public static List<CiudadesInternacionales> BuscarCiudades(string pais)
        {
            var ciudadesDeUnPais = new List<CiudadesInternacionales>();

            foreach (CiudadesInternacionales ciudadesEnlista in ListaCiudadesI)
            {
                if (ciudadesEnlista.Pais != null)
                {
                    if (ciudadesEnlista.Pais.ToLower() == pais.ToLower())
                    {
                        ciudadesDeUnPais.Add(ciudadesEnlista);
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron ciudades para la provincia seleccionada");
                }
            }
            return ciudadesDeUnPais;

        }
    }
}