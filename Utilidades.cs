using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grupoB_TP
{
    static class Utilidades
    {
        public static void GrabarNuevaFila(string Path, string Text)
        {
            string contenido = File.ReadAllText(Path);
            contenido = Text + "\n" + contenido;      
            File.WriteAllText(Path, contenido);
        }
    }
}

