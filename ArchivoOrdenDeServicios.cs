using grupoB_TP;

namespace Version_2___Pantallas
{
    internal static class ArchivoOrdenDeServicios
    {
        static List<OrdenDeServicio> listaOrdenesDeServicio = new List<OrdenDeServicio>();
        internal static void CargarOrdenDeServicio()
        {
            //Archivo
            //N°Trackeo|Fecha|CUIT Cliente|Tipo DE ENVIO NACIONAL O INTERNACIONAL|PAÍS DE ORIGEN|PROVINCIA ORIGEN|CIUDAD ORIGEN|
            //CALLE ORIGEN|ALTURA ORIGEN|PISO|DPTO ORIGEN|PAÍS DE DESTINO|PROVINCIA DESTINO|CIUDAD DESTINO|CALLE DESTINO|ALTURA DESTINO|
            //PISO|DEPTO DESTINO|RANGO DE PESO|CANTIDAD DE BULTOS|URGENTE (SI|NO)|ESTADO|FACTURADO (SI|NO)

            using var archivo = new StreamReader("ArchivoOrdenDeServicios.txt");
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
                //ordenDeServicio.fecha = DateTime.Parse(datosSeparados[1]);
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
        //METODO BUSCAR CUIT (Devuelve una lista) 
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

        public static int BuscarUltimoNumeroTrackeo()
        {
            var ultimaOrdenDeServicio = listaOrdenesDeServicio.Last();
            return ultimaOrdenDeServicio.numeroTrackeo;
        }

        public static void GuardarAlFinal(string datos)
        {
            using var archivo = new StreamWriter("ArchivoOrdenDeServicios.txt", true);
            archivo.WriteLine(datos);
            MessageBox.Show("Se guardo su Orden De Servicio correctamente ");

        }
    }
}