namespace Version_2___Pantallas
{
    internal static class ArchivoPaisesInternacionales
    {
        // Genera los objectos PaisesInternacionales apartir del Archivo "ArchivoPaisesInternacionales.txt" y almacena en PaisesInternacionales
        static List<string> PaisesInternacionales = new List<string>();
        internal static void CargarPaisesInternacionales()
        {
            using var archivoPaisesInternacionales = new StreamReader("ArchivoPaisesInternacionales.txt");

            while (!archivoPaisesInternacionales.EndOfStream)
            {
                var proximaLinea = archivoPaisesInternacionales.ReadLine();

                var PaisInternacional = new CiudadesInternacionales();
                PaisInternacional.Pais = proximaLinea;

                PaisesInternacionales.Add(proximaLinea!);
            }
            archivoPaisesInternacionales.Close();
        }
        public static List<string> SoloPaises()
        {
            return PaisesInternacionales;
        }
    }
}