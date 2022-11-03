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
        public static string Buscar( int columnaDeEntrada, int columnaSalida, string elementoBuscado, string path) //Buscar por la primer columna y Devuelve la segunda
        {
            using var archivo = new StreamReader(path);
            while (!archivo.EndOfStream)
            {
                var proximaLinea = archivo.ReadLine();

                if (!string.IsNullOrEmpty(proximaLinea))
                {
                    string[] datosSeparados = proximaLinea.Split("|");
                    if (datosSeparados[columnaDeEntrada] == elementoBuscado)
                    {
                        return datosSeparados[columnaSalida];
                    }
                }
            }
            return "";
        }
    }
}

