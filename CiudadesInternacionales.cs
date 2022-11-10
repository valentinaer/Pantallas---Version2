using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Version_2___Pantallas
{
    internal class CiudadesInternacionales
    {
        public string Pais { get; set; }
        public string Ciudad { get; set; }


        List<CiudadesInternacionales> ListaCiudadesI = new List<CiudadesInternacionales>();

        public void CargarCiudadesInternacionales()
        {
            using var archivoCiudadesInternacionales = new StreamReader("CiudadesInternacionales.txt");

            while (!archivoCiudadesInternacionales.EndOfStream)
            {
                var proximaLinea = archivoCiudadesInternacionales.ReadLine();
                string[] datosSeparados = proximaLinea.Split("|");

                var CiudadInternacional = new CiudadesInternacionales();
                CiudadInternacional.Pais = datosSeparados[0];
                CiudadInternacional.Ciudad = datosSeparados[1];

                ListaCiudadesI.Add(CiudadInternacional);

            }
        }

        List<CiudadesInternacionales> ciudadesPais = new List<CiudadesInternacionales>();

        public List<CiudadesInternacionales> BuscarCiudades(string pais)
        {
            CargarCiudadesInternacionales();

            CiudadesInternacionales ciudades = new CiudadesInternacionales();
            foreach (CiudadesInternacionales c in ListaCiudadesI)
            {
                if (c.Pais.ToLower() == pais.ToLower())
                {
                    ciudadesPais.Add(c);
                }
            }
            return ciudadesPais;

        }
    }
}
