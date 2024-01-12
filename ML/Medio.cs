﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Medio
    {
        public int IdMedio { get; set; }

        public string Titulo { get; set; }

        public ML.TipoMedio TipoMedio { get; set; } = new ML.TipoMedio();
        public ML.Editorial Editorial { get; set; } = new ML.Editorial();

        public string? AñoLanzamiento { get; set; }
        public string? Duracion { get; set; }

        public int? NumPaginas { get; set; }

        public ML.Genero Genero { get; set; } = new ML.Genero();

        public ML.Idioma Idioma { get; set; } = new ML.Idioma();

        public ML.Autor Autor { get; set; } = new Autor();

        public string Descripcion { get; set; }

        public string? Imagen { get; set; }

        public List<object> Medios { get; set; }

    }
}
