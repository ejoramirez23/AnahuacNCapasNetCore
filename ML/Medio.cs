using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Medio
    {
        public int IdMedio { get; set; }
        public string? Titulo { get; set; }
        public ML.TipoMedio? TipoMedio { get; set; }
        public ML.Editorial? Editorial { get; set; }
        public string? AñoLanzamiento { get; set; }
        public string? Duracion { get; set; }

        public int NumPaginas { get; set; }

        public ML.Genero? Genero { get; set; }

        public ML.Idioma? Idioma { get; set; }

        public ML.Autor? Autor { get; set; }

        public string? Descripcion { get; set; }

        public string? Imagen { get; set; }

        public List<object>? Medios { get; set; }

    }
}
