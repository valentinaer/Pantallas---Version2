using grupoB_TP;

namespace Version_2___Pantallas
{
    internal static class ArchivoOrdenDeServicios
    {
        // Genera los objectos OrdenDeServicio apartir del Archivo "ArchivoOrdenDeServicios.txt" y almacena en ListaOrdenDeServicios
        static List<OrdenDeServicio> listaOrdenesDeServicio = new List<OrdenDeServicio>();
        internal static void CargarOrdenDeServicio()
        {
            listaOrdenesDeServicio.Clear();
            //Archivo
            //N°Trackeo|Fecha|CUIT Cliente|Tipo DE ENVIO NACIONAL O INTERNACIONAL|PAÍS DE ORIGEN|PROVINCIA ORIGEN|CIUDAD ORIGEN|
            //CALLE ORIGEN|ALTURA ORIGEN|PISO|DPTO ORIGEN|PAÍS DE DESTINO|PROVINCIA DESTINO|CIUDAD DESTINO|CALLE DESTINO|ALTURA DESTINO|
            //PISO|DEPTO DESTINO|RANGO DE PESO|CANTIDAD DE BULTOS|URGENTE (SI|NO)|ESTADO|FACTURADO (SI|NO)

            using var archivo = new StreamReader("./ArchivoOrdenDeServicios.txt");
            while (!archivo.EndOfStream)
            {
                var proximaLinea = archivo.ReadLine();
                if (string.IsNullOrEmpty(proximaLinea))
                {
                    continue;
                }
                string[] datosSeparados = proximaLinea.Split("|");

                OrdenDeServicio ordenDeServicio = new OrdenDeServicio();

                ordenDeServicio.NumeroTrackeo = int.Parse(datosSeparados[0]);
                //ordenDeServicio.Fecha = DateTime.Parse(datosSeparados[1]);
                ordenDeServicio.Cuit = datosSeparados[2];
                ordenDeServicio.TipoDeEnvio = datosSeparados[3];
                ordenDeServicio.PaisOrigen = datosSeparados[4];
                ordenDeServicio.ProvinciaOrigen = datosSeparados[5];
                ordenDeServicio.CiudadOrigen = datosSeparados[6];
                ordenDeServicio.CalleOrigen = datosSeparados[7];
                ordenDeServicio.AlturaOrigen = int.Parse(datosSeparados[8]);
                ordenDeServicio.PisodeptoOrigen = datosSeparados[9];
                ordenDeServicio.PaisDestino = datosSeparados[10];
                ordenDeServicio.ProvinciaDestino = datosSeparados[11];
                ordenDeServicio.CiudadDestino = datosSeparados[12];
                ordenDeServicio.CalleDestino = datosSeparados[13];
                ordenDeServicio.AlturaDestino = int.Parse(datosSeparados[14]);
                ordenDeServicio.PisodeptoDestino = datosSeparados[15];
                ordenDeServicio.RangoDePeso = datosSeparados[16];
                ordenDeServicio.CantidadDeBultos = int.Parse(datosSeparados[17]);
                ordenDeServicio.Urgente = datosSeparados[18];
                ordenDeServicio.Estado = datosSeparados[19];
                ordenDeServicio.Facturado = datosSeparados[20];

                listaOrdenesDeServicio.Add(ordenDeServicio);
            }
            archivo.Close();
        }


        // Busca las ordenes de servicio apartir del Numero de Trackeo ingresado
        public static OrdenDeServicio BuscarNumeroTrack(int trackid)
        {
            foreach (var ordenDeServicio in listaOrdenesDeServicio)
            {
                if (ordenDeServicio.NumeroTrackeo == trackid)
                {
                    return ordenDeServicio;
                }
            }
            return null!;
        }

        // Busca la ultima orden de servicio ingresada para conseguir el numero de trackeo
        public static int BuscarUltimoNumeroTrackeo()
        {
            var ultimaOrdenDeServicio = listaOrdenesDeServicio.Last();
            return ultimaOrdenDeServicio.NumeroTrackeo;
        }

        // Guardar una nueva orden de servicio al final del txt
        /*
        public static void GuardarAlFinal(string datos)
        {
            /* using var archivo = new StreamWriter("./ArchivoOrdenDeServicios.txt", true); // true es para que adjunte al final (nueva fila) en vez de sobre escribir
            archivo.WriteLine(datos);
            MessageBox.Show("Se guardo su Orden De Servicio correctamente ");
 
            File.AppendAllText("./ArchivoOrdenDeServicios.txt", datos + Environment.NewLine);
        }*/

        internal static void GuardarEnLista(OrdenDeServicio solicitud)
        {
            listaOrdenesDeServicio.Add(solicitud);
        }
        public static void Grabar()
        {
            File.Delete("./ArchivoOrdenDeServicios.txt");
            var archivoOrdenServicio = new StreamWriter("ArchivoOrdenDeServicios.txt");
            string lineas = "";
            foreach (var solicitud in listaOrdenesDeServicio)
            {
                string linea = $"{solicitud.NumeroTrackeo}|{solicitud.Fecha}|{solicitud.Cuit}|" +
                    $"{solicitud.TipoDeEnvio}|{solicitud.PaisOrigen}|{solicitud.ProvinciaOrigen}|" +
                    $"{solicitud.CiudadOrigen}|{solicitud.CalleOrigen}|{solicitud.AlturaOrigen}|" +
                    $"{solicitud.PisodeptoOrigen}|{solicitud.PaisDestino}|{solicitud.ProvinciaDestino}|" +
                    $"{solicitud.CiudadDestino}|{solicitud.CalleDestino}|{solicitud.AlturaDestino}|" +
                    $"{solicitud.PisodeptoDestino}|{solicitud.RangoDePeso}|{solicitud.CantidadDeBultos}|" +
                    $"{solicitud.Urgente}|{solicitud.Estado}|{solicitud.Facturado}";

                    lineas += $"{solicitud.NumeroTrackeo}|{solicitud.Fecha}|{solicitud.Cuit}|" +
                    $"{solicitud.TipoDeEnvio}|{solicitud.PaisOrigen}|{solicitud.ProvinciaOrigen}|" +
                    $"{solicitud.CiudadOrigen}|{solicitud.CalleOrigen}|{solicitud.AlturaOrigen}|" +
                    $"{solicitud.PisodeptoOrigen}|{solicitud.PaisDestino}|{solicitud.ProvinciaDestino}|" +
                    $"{solicitud.CiudadDestino}|{solicitud.CalleDestino}|{solicitud.AlturaDestino}|" +
                    $"{solicitud.PisodeptoDestino}|{solicitud.RangoDePeso}|{solicitud.CantidadDeBultos}|" +
                    $"{solicitud.Urgente}|{solicitud.Estado}|{solicitud.Facturado} \n";

                archivoOrdenServicio.WriteLine(linea);
                MessageBox.Show(linea);
            }
            MessageBox.Show("Se grabo Correctamente");
            File.WriteAllText("Backup ArchivoOrdenDeServicios.txt", lineas);

            archivoOrdenServicio.Close();
        }


    }
}