using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grupoB_TP
{
    internal class OrdenDeServicio
    {
        public int numeroTrackeo { get; set; }
        public int fecha { get; set; }
        public string CUIT { get; set; } = string.Empty;
        public string tipoDeEnvio { get; set; } = string.Empty;
        public string paisOrigen { get; set; } = string.Empty;
        public string provinciaOrigen { get; set; } = string.Empty;
        public string ciudadOrigen { get; set; } = string.Empty;
        public string calleOrigen { get; set; } = string.Empty;
        public int alturaOrigen { get; set; }
        public string pisodeptoOrigen { get; set; } = string.Empty;
        public string paisDestino { get; set; } = string.Empty;
        public string provinciaDestino { get; set; } = string.Empty;
        public string ciudadDestino { get; set; } = string.Empty;
        public string calleDestino { get; set; } = string.Empty;
        public int alturaDestino { get; set; }
        public string pisodeptoDestino { get; set; } = string.Empty;
        public string rangoDePeso { get; set; } = string.Empty;
        public int cantidadDeBultos { get; set; } 
        public string urgente { get; set; } = string.Empty;
        public string estado { get; set; } = string.Empty;
        public string facturado { get; set; } = string.Empty;

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
