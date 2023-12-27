using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Direccion
    {

        public int IdDireccion { get; set; }

        public string Calle { get; set; }

        public string NumExterior { get; set; }
        public string NumInterior { get; set; }
        public ML.Colonia Colonia { get; set; }

        // falta propiedad de navegacion de AspNetUsers Id

        public ML.Editorial? Editorial { get; set; }
    }
}
