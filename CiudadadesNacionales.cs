using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Version_2___Pantallas
{
    internal class CiudadadesNacionales
    {
        public string Ciudad { get; set; }
        public string Provincia { get; set; }
        public string Region { get; set; }

        static List<CiudadadesNacionales> CiudadesNacionales = new List<CiudadadesNacionales>();
        public static void CargarCiudadesNacionales()
        {
            using var archivoCiudadesNacionales = new StreamReader("./CiudadesNacionales.txt");

            while (!archivoCiudadesNacionales.EndOfStream)
            {
                var proximoLinea = archivoCiudadesNacionales.ReadLine();
                string[] datosSeparados = proximoLinea.Split("|");

                var ciudadNacional = new CiudadadesNacionales();
                ciudadNacional.Ciudad = datosSeparados[0];

                ciudadNacional.Provincia = datosSeparados[1];

                ciudadNacional.Region = datosSeparados[2];

                CiudadesNacionales.Add(ciudadNacional);
            }
            MessageBox.Show("El archivo Ciudades se cargo correctamente");
        }
    }
}
