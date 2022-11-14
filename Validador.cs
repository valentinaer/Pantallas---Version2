using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grupoB_TP
{
    static class Validador
    {
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
                    return $"Debe ingresar un valor de {campo} mayor a {min} y menor a {max}. \n";
                }
            }
            else
            {
                return $"Debe ingresar un valor de {campo} numérico. \n";
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

        internal static string ValidarFecha(string fecha, string campo)
        {
            string msj = "";
            if (!DateTime.TryParse(fecha, out DateTime fechas))
            {
                msj = "Debe ingresar una fecha válida en el campo " + campo + System.Environment.NewLine;
            }
            else
            {
                msj += "";
            }
            return msj;
        }
    }
}

