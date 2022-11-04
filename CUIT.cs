using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Version_2___Pantallas
{
    internal class CUIT
    {
        string Cuitenviado { get; set; }
        public CUIT(string cuitenviado)
        {
            Cuitenviado = cuitenviado;
            MessageBox.Show("CUIT EN CLASE: "+ Cuitenviado);// ACA LLEGA
        }
        public CUIT()
        {
           
        }
        public string DevolverCUIT()
        {
            MessageBox.Show("DEVOLVER CUIT : "+Cuitenviado); // ACA ESTA VACIO
            return Cuitenviado;
        }
      
    }
}
