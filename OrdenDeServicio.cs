using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grupoB_TP
{
    internal class OrdenDeServicio
    {
        public int numeroTrackeo            { get; set; }        
        public int fecha                    { get; set; }        
        public string CUIT                     { get; set; }        
        public string tipoDeEnvio              { get; set; }        
        public string paisOrigen               { get; set; }        
        public string provinciaOrigen          { get; set; }        
        public string ciudadOrigen             { get; set; }        
        public string calleOrigen              { get; set; }        
        public int alturaOrigen             { get; set; }        
        public string pisodeptoOrigen          { get; set; }        
        public string paisDestino              { get; set; }        
        public string provinciaDestino         { get; set; }        
        public string ciudadDestino            { get; set; }        
        public string calleDestino             { get; set; }        
        public int alturaDestino            { get; set; }        
        public string pisodeptoDestino         { get; set; }        
        public string rangoDePeso              { get; set; }        
        public int cantidadDeBultos         { get; set; }        
        public string urgente                  { get; set; }        
        public string estado                   { get; set; }        
        public string facturado                { get; set; }        

        public OrdenDeServicio(
            int numeroTrackeo_       ,
            int fecha_               ,
            string CUIT_             ,
            string tipoDeEnvio_       ,
            string paisOrigen_        ,
            string provinciaOrigen_   ,
            string ciudadOrigen_      ,
            string calleOrigen_       ,
            int alturaOrigen_         ,
            string pisodeptoOrigen_   ,
            string paisDestino_       ,
            string provinciaDestino_  ,
            string ciudadDestino_     ,
            string calleDestino_      ,
            int alturaDestino_        ,
            string pisodeptoDestino_  ,
            string rangoDePeso_       ,
            int cantidadDeBultos_     ,
            string urgente_           ,
            string estado_            ,
            string facturado_        
        )
        {
             numeroTrackeo        =      numeroTrackeo_            ;
             fecha                =      fecha_                    ;
             CUIT                 =      CUIT_                     ;
             tipoDeEnvio          =      tipoDeEnvio_              ;
             paisOrigen           =      paisOrigen_               ;
             provinciaOrigen      =      provinciaOrigen_          ;
             ciudadOrigen         =      ciudadOrigen_             ;
             calleOrigen          =      calleOrigen_              ;
             alturaOrigen         =      alturaOrigen_                ;
             pisodeptoOrigen      =      pisodeptoOrigen_          ;
             paisDestino          =      paisDestino_              ;
             provinciaDestino     =      provinciaDestino_         ;
             ciudadDestino        =      ciudadDestino_            ;
             calleDestino         =      calleDestino_             ;
             alturaDestino        =      alturaDestino_               ;
             pisodeptoDestino     =      pisodeptoDestino_         ;
             rangoDePeso          =      rangoDePeso_              ;
             cantidadDeBultos     =      cantidadDeBultos_            ;
             urgente              =      urgente_                  ;
             estado               =      estado_                   ;
             facturado            =      facturado_                ;
        }         
        
        public OrdenDeServicio()
        {

        }

        List<OrdenDeServicio> listaOrdenesDeServicio = new List<OrdenDeServicio>();

        private void CargarOrdenesDeServicio()
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
    
                ordenDeServicio.numeroTrackeo          = int.Parse(datosSeparados[0]);
                ordenDeServicio.fecha                  = int.Parse(datosSeparados[1]);
                ordenDeServicio.CUIT                   = datosSeparados[2];
                ordenDeServicio.tipoDeEnvio            = datosSeparados[3];
                ordenDeServicio.paisOrigen             = datosSeparados[4];
                ordenDeServicio.provinciaOrigen        = datosSeparados[5];
                ordenDeServicio.ciudadOrigen           = datosSeparados[6];
                ordenDeServicio.calleOrigen            = datosSeparados[7];
                ordenDeServicio.alturaOrigen           = int.Parse(datosSeparados[8]);
                ordenDeServicio.pisodeptoOrigen        = datosSeparados[9];
                ordenDeServicio.paisDestino            = datosSeparados[10];
                ordenDeServicio.provinciaDestino       = datosSeparados[11];
                ordenDeServicio.ciudadDestino          = datosSeparados[12];
                ordenDeServicio.calleDestino           = datosSeparados[13];
                ordenDeServicio.alturaDestino          = int.Parse(datosSeparados[14]);
                ordenDeServicio.pisodeptoDestino       = datosSeparados[15];
                ordenDeServicio.rangoDePeso            = datosSeparados[16];
                ordenDeServicio.cantidadDeBultos       = int.Parse(datosSeparados[17]);
                ordenDeServicio.urgente                = datosSeparados[18];
                ordenDeServicio.estado                 = datosSeparados[19];
                ordenDeServicio.facturado              = datosSeparados[20];
            
                listaOrdenesDeServicio.Add(ordenDeServicio);
            }
        }
         //METODO BUSCAR CUIT (Devuelve una lista) 
        public OrdenDeServicio BuscarNumeroTrack(int trackid)
        {
            if (listaOrdenesDeServicio.Count == 0)
            {
                
            }
            CargarOrdenesDeServicio();
            
            OrdenDeServicio Os = new OrdenDeServicio();
            foreach(var ordenDeServicio in listaOrdenesDeServicio)
            {
                if (ordenDeServicio.numeroTrackeo == trackid)
                {
                    return ordenDeServicio;
                }
            }
            return null;
        }
    }
}
