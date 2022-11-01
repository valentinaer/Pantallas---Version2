using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grupoB_TP
{
    static class Validador
    {
        public static string DNI = "12345678";
        public static string DNI2 = "87654321";
        
        internal static string PedirEntero(string campo, int min, int max, string valor)
        {

            if (int.TryParse(valor, out int result))
            {
                if (result >= min && result <= max)
                {
                    return "";
                }
                else
                {
                    return $"Debe ingresar un valor {campo} mayor a {min} y menor a {max}. \n";
                }
            }
            else
            {
                return $"Debe ingresar un valor de {campo} numérico. \n";
            }
        }

        internal static string PedirLongitudFija(string campo, int longitud, string text)
        {
            if (text.Length == longitud)
            {
                return "";
            }
            else
            {
                return $"El valor {campo} debe tener una longitud de {longitud} caracteres. \n";
            }
        }

        internal static string PedirNumerico(string campo, string ingreso)
        {
            while (true)
            {
                bool estaOK = true;
                foreach (char caracter in ingreso)
                {
                    if (caracter > '0' && caracter < '9')
                    {
                        return ($" El {campo} debe tener solamente números.");
                        estaOK = false;
                        break;
                    }
                }
                if (!estaOK)
                {
                    continue;
                }
            }

        }

        internal static string PedirVacio(string campo, string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return $"{campo} no puede estar vacio. \n";
            }
            else
            {
                return "";
            }

        }
    }
}

