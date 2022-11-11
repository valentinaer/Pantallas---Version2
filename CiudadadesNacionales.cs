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
        public string? Ciudad { get; set; }
        public string? Provincia { get; set; }
        public string? Region { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1} - {2}", Provincia, Ciudad, Region);
        }
    }

}
