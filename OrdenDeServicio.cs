using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grupoB_TP
{
    internal class OrdenDeServicio
    {
        public int NumeroTrackeo { get; set; }
        public DateTime Fecha { get; set; }
        public string Cuit { get; set; } = string.Empty;
        public string TipoDeEnvio { get; set; } = string.Empty;
        public string PaisOrigen { get; set; } = string.Empty;
        public string ProvinciaOrigen { get; set; } = string.Empty;
        public string CiudadOrigen { get; set; } = string.Empty;
        public string CalleOrigen { get; set; } = string.Empty;
        public int AlturaOrigen { get; set; }
        public string PisodeptoOrigen { get; set; } = string.Empty;
        public string PaisDestino { get; set; } = string.Empty;
        public string ProvinciaDestino { get; set; } = string.Empty;
        public string CiudadDestino { get; set; } = string.Empty;
        public string CalleDestino { get; set; } = string.Empty;
        public int AlturaDestino { get; set; }
        public string PisodeptoDestino { get; set; } = string.Empty;
        public string RangoDePeso { get; set; } = string.Empty;
        public int CantidadDeBultos { get; set; }
        public string Urgente { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public string Facturado { get; set; } = string.Empty;

        /*  public OrdenDeServicio(
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
         }  */
    }
}
