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

        List<CiudadadesNacionales> ListaCiudadesNacionales = new List<CiudadadesNacionales>();
        public void CargarCiudadesNacionales()
        {
            using var archivoCiudadesNacionales = new StreamReader("./CiudadesNacionales.txt");

            while (!archivoCiudadesNacionales.EndOfStream)
            {
                var proximoLinea = archivoCiudadesNacionales.ReadLine();
                string[] datosSeparados = proximoLinea.Split("|");               

                ListaCiudadesNacionales.Add(new CiudadadesNacionales { Ciudad = datosSeparados[1], Provincia = datosSeparados[0], Region = datosSeparados[2] });
            }
        }

        public CiudadadesNacionales BuscarRegion(string ciudad)
        {
            CargarCiudadesNacionales();
            CiudadadesNacionales region = new CiudadadesNacionales();
            for (int i = 0; i < ListaCiudadesNacionales.Count; i++)
            {
                if (ListaCiudadesNacionales[i].Ciudad == ciudad)
                {
                    region = ListaCiudadesNacionales[i];
                }
            }
            return region;
        }
    }
}
