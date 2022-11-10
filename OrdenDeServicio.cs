using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_TP4
{
    internal class OrdenDeServicio
    {
        public int Id_Cotizacion { get; set; }
        public bool Aprobado { get; set; }
        public string Estado { get; set; }
        public int Id_Trackeo { get; set; } //Correlativo (1,2,3...)
        public int CUIT { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public Direccion Origen { get; set; }
        public Direccion Destino { get; set; }
        public bool Urgente { get; set; }
        public bool TipoDeEntrega { get; set; } //NACIONAL = TRUE  y INTERNACIONAL =FALSE si es false,
        public bool TipoDeRecepcion { get; set; }
        public string RangoPeso { get; set; }
        public int CantidadBultos { get; set; }
        public int MontoOrdenDeServicio { get; set; }

        public OrdenDeServicio()
        {

        }

        List<OrdenDeServicio> listaOrdenesDeServicio = new List<OrdenDeServicio>();

        public void CargarOrdenesDeServicio()
        {
            //Archivo
            //N°Trackeo|Fecha|CUIT Cliente|Tipo DE ENVIO NACIONAL O INTERNACIONAL|PAÍS DE ORIGEN|PROVINCIA ORIGEN|CIUDAD ORIGEN|
            //CALLE ORIGEN|ALTURA ORIGEN|PISO|DPTO ORIGEN|PAÍS DE DESTINO|PROVINCIA DESTINO|CIUDAD DESTINO|CALLE DESTINO|ALTURA DESTINO|
            //PISO|DEPTO DESTINO|RANGO DE PESO|CANTIDAD DE BULTOS|URGENTE (SI|NO)|ESTADO|FACTURADO (SI|NO)

            using var archivo = new StreamReader("OrdenDeServicio.txt");
            while (!archivo.EndOfStream)
            {
                var proximaLinea = archivo.ReadLine();
                string[] datosSeparados = proximaLinea.Split("|");

                OrdenDeServicio ordenDeServicio = new OrdenDeServicio();
                usuario.DNIAutorizados = int.Parse(datosSeparados[0]);
                usuario.CUIT = datosSeparados[1];
                usuario.Contraseña = datosSeparados[2];
                usuario.ApellidoNombre = datosSeparados[3];
                ordenDeServicio.numeroTrackeo          = int.Parse(datosSeparados[0]);
                ordenDeServicio.fecha                  = int.Parse(datosSeparados[1]);
                ordenDeServicio.CUIT                   = datosSeparados[2];
                ordenDeServicio.cliente                = datosSeparados[3];
                ordenDeServicio.tipoDeEnvio            = datosSeparados[4];
                ordenDeServicio.paisOrigen             = datosSeparados[5];
                ordenDeServicio.provinciaOrigen        = datosSeparados[6];
                ordenDeServicio.ciudadOrigen           = datosSeparados[7];
                ordenDeServicio.calleOrigen            = datosSeparados[8];
                ordenDeServicio.alturaOrigen           = int.Parse(datosSeparados[9]);
                ordenDeServicio.pisoOrigen             = datosSeparados[10];
                ordenDeServicio.deptoOrigen            = datosSeparados[11];
                ordenDeServicio.paisDestino            = datosSeparados[12];
                ordenDeServicio.provinciaDestino       = datosSeparados[13];
                ordenDeServicio.ciudadDestino          = datosSeparados[14];
                ordenDeServicio.calleDestino           = datosSeparados[15];
                ordenDeServicio.alturaDestino          = int.Parse(datosSeparados[16]);
                ordenDeServicio.pisoDestino            = datosSeparados[17];
                ordenDeServicio.deptoDestino           = datosSeparados[18];
                ordenDeServicio.rangoDePeso            = datosSeparados[19];
                ordenDeServicio.cantidadDeBultos       = int.Parse(datosSeparados[20]);
                ordenDeServicio.urgente                = datosSeparados[21];
                ordenDeServicio.estado                 = datosSeparados[22];
                ordenDeServicio.facturado              = datosSeparados[23];
            
                ListaUsuario.Add(usuario);
            }
        }
    }
}
