using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Version_2___Pantallas
{
    internal class PadronUsuario
    {
        public string CUIT { get; set; }
        public int DNIAutorizados { get; set; }

        public string ApellidoNombre { get; set; }

        public string Contraseña { get; set; }

        // C O N S T R U C T O R E S //
        public PadronUsuario(int dniautorizados, string cuit, string apellidonombre, string contraseña)
        {
            CUIT = cuit;
            DNIAutorizados = dniautorizados;
            ApellidoNombre = apellidonombre;
            Contraseña = contraseña;
        }
        public override string ToString()
        {
            return string.Format("{0} - {1} - {2} - {3}",

                CUIT,
                DNIAutorizados,
                ApellidoNombre,
                Contraseña);
        }
    }
}
