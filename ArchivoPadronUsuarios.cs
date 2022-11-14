namespace Version_2___Pantallas
{
    internal static class ArchivoPadronUsuarios
    {
        static List<PadronUsuario> ListaUsuario = new List<PadronUsuario>();
        internal static void CargarUsuarios()
        {
            //Archivo
            //DNI |CUIT| Apellido y Nombre | Contraseña

            using var archivo = new StreamReader("ArchivoPadronUsuarios.txt");
            while (!archivo.EndOfStream)
            {
                var proximaLinea = archivo.ReadLine();
                if (string.IsNullOrEmpty(proximaLinea))
                {
                    continue;
                }
                string[] datosSeparados = proximaLinea.Split("|");

                PadronUsuario usuario = new PadronUsuario(
                    int.Parse(datosSeparados[0]),
                    datosSeparados[1],
                    datosSeparados[2],
                    datosSeparados[3]
                );
                ListaUsuario.Add(usuario);
            }
            archivo.Close();
        }

        // Busca el usuario apartir del DNI ingresado
        public static PadronUsuario BuscarDNI(int dni)
        {
            foreach (var personaEnLaLista in ListaUsuario)
            {
                if (personaEnLaLista.DNIAutorizados == dni)
                {
                    return personaEnLaLista;
                }
            }
            return null!;
        }

    }
}