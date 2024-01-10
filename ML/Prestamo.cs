using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ML
{
    public class Prestamo
    {
        public int IdPrestamo { get; set; }

        public ML.Medio Medio { get; set; }

        public string FechaPrestamo { get; set; }

        public string FechaEntrega { get; set; }

        public bool Estatus { get; set; }
        public ML.Usuario Usuario { get; set; }

        public List<object> Prestamos { get; set; }

    }
}
