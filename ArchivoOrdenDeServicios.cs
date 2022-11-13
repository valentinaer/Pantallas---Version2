using grupoB_TP;

namespace Version_2___Pantallas
{
    internal static class ArchivoOrdenDeServicios
    {
        // Genera los objectos OrdenDeServicio apartir del Archivo "ArchivoOrdenDeServicios.txt" y almacena en ListaOrdenDeServicios
        static List<OrdenDeServicio> listaOrdenesDeServicio = new List<OrdenDeServicio>();
        internal static void CargarOrdenDeServicio()
        {
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

                ordenDeServicio.numeroTrackeo = int.Parse(datosSeparados[0]);
                ordenDeServicio.fecha = DateTime.Parse(datosSeparados[1]);
                ordenDeServicio.Cuit = datosSeparados[2];
                ordenDeServicio.tipoDeEnvio = datosSeparados[3];
                ordenDeServicio.paisOrigen = datosSeparados[4];
                ordenDeServicio.provinciaOrigen = datosSeparados[5];
                ordenDeServicio.ciudadOrigen = datosSeparados[6];
                ordenDeServicio.calleOrigen = datosSeparados[7];
                ordenDeServicio.alturaOrigen = int.Parse(datosSeparados[8]);
                ordenDeServicio.pisodeptoOrigen = datosSeparados[9];
                ordenDeServicio.paisDestino = datosSeparados[10];
                ordenDeServicio.provinciaDestino = datosSeparados[11];
                ordenDeServicio.ciudadDestino = datosSeparados[12];
                ordenDeServicio.calleDestino = datosSeparados[13];
                ordenDeServicio.alturaDestino = int.Parse(datosSeparados[14]);
                ordenDeServicio.pisodeptoDestino = datosSeparados[15];
                ordenDeServicio.rangoDePeso = datosSeparados[16];
                ordenDeServicio.cantidadDeBultos = int.Parse(datosSeparados[17]);
                ordenDeServicio.urgente = datosSeparados[18];
                ordenDeServicio.estado = datosSeparados[19];
                ordenDeServicio.facturado = datosSeparados[20];

                listaOrdenesDeServicio.Add(ordenDeServicio);
            }
        }

        // Busca las ordenes de servicio apartir del Numero de Trackeo ingresado
        public static OrdenDeServicio BuscarNumeroTrack(int trackid)
        {
            foreach (var ordenDeServicio in listaOrdenesDeServicio)
            {
                if (ordenDeServicio.numeroTrackeo == trackid)
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
            return ultimaOrdenDeServicio.numeroTrackeo;
        }

        // Guardar una nueva orden de servicio al final del txt
        /*
        public static void GuardarAlFinal(string datos)
        {
            /* using var archivo = new StreamWriter("./ArchivoOrdenDeServicios.txt", true); // true es para que adjunte al final (nueva fila) en vez de sobre escribir
            archivo.WriteLine(datos);
            MessageBox.Show("Se guardo su Orden De Servicio correctamente ");
 
            // save a new line of datos in ./ArchivoOrdenDeServicios.txt at the end
            File.AppendAllText("./ArchivoOrdenDeServicios.txt", datos + Environment.NewLine);
        }*/
     
        internal static void GuardarEnLista(OrdenDeServicio solicitud)
        {
            listaOrdenesDeServicio.Add(solicitud);
        }
        public static async Task Grabar()
        {
            using var archivoOrdenServicio = new StreamWriter("ArchivoOrdenDeServicios.txt", append: true);
            foreach(var solicitud in listaOrdenesDeServicio)
            {
                string linea = $"{solicitud.numeroTrackeo}|{solicitud.fecha}|{solicitud.Cuit}|" +
                    $"{solicitud.tipoDeEnvio}|{solicitud.paisOrigen}|{solicitud.provinciaOrigen}|" +
                    $"{solicitud.ciudadOrigen}|{solicitud.calleOrigen}|{solicitud.alturaOrigen}|" +
                    $"{solicitud.pisodeptoOrigen}|{solicitud.paisDestino}|{solicitud.provinciaDestino}|" +
                    $"{solicitud.ciudadDestino}|{solicitud.calleDestino}|{solicitud.alturaDestino}|" +
                    $"{solicitud.pisodeptoDestino}|{solicitud.rangoDePeso}|{solicitud.cantidadDeBultos}|{solicitud.urgente}|{solicitud.estado}|{solicitud.facturado}";

               await File.WriteAllTextAsync("ArchivoOrdenDeServicios.txt",linea);
            }
            MessageBox.Show("Se grabo Correctamente");

            archivoOrdenServicio.Close();
            
        }


    }
}