using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            using var archivoCiudadesNacionales = new StreamReader("CiudadesNacionales.txt");

            while (!archivoCiudadesNacionales.EndOfStream)
            {
                var proximoLinea = archivoCiudadesNacionales.ReadLine();
                string[] datosSeparados = proximoLinea.Split("|");

                var CiudadesNacional = new CiudadadesNacionales();
                CiudadesNacional.Provincia = datosSeparados[0];
                CiudadesNacional.Ciudad = datosSeparados[1];
                CiudadesNacional.Region = datosSeparados[2];

                ListaCiudadesNacionales.Add(CiudadesNacional);
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
        List<CiudadadesNacionales> ciudadesProvincia = new List<CiudadadesNacionales>();
        public List<CiudadadesNacionales> BuscarCiudades(string provincia)
        {
            CargarCiudadesNacionales();
            MessageBox.Show(provincia);
            
            CiudadadesNacionales ciudades = new CiudadadesNacionales();
            for (int i = 0; i < ListaCiudadesNacionales.Count; i++)
            {

                if (ListaCiudadesNacionales[i].Provincia.ToLower() == provincia.ToLower()) 
                {
                    ciudadesProvincia.Add(ListaCiudadesNacionales[i]);
                }
            }
            return ciudadesProvincia;


            //CiudadadesNacionales U = new CiudadadesNacionales();

            /*
            foreach (CiudadadesNacionales c in ListaCiudadesNacionales)
            {
                if (c.Provincia == provincia)
                {
                    ciudadesProvincia.Add(c.Ciudad);
                }
            }
            */

            //return ListaCiudadesNacionales.FindAll(l => l.Provincia == provincia);
        }
        public override string ToString()
        {
            return string.Format("{0} - {1}", Provincia, Ciudad);
        }
    }

}
