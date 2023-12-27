using System;
using System.Collections.Generic;

namespace DL;

public partial class Medio
{
    public int IdMedio { get; set; }

    public string Titulo { get; set; } = null!;

    public int? IdTipoMedio { get; set; }

    public int? IdEditorial { get; set; }

    public DateTime? AñoLanzamiento { get; set; }

    public string? Duración { get; set; }

    public int? NumPaginas { get; set; }

    public int IdIdioma { get; set; }

    public int? IdGenero { get; set; }

    public int? IdAutor { get; set; }

    public string? Descripcion { get; set; }

    public byte[]? Imagen { get; set; }

    public virtual Autor? IdAutorNavigation { get; set; }

    public virtual Editorial? IdEditorialNavigation { get; set; }

    public virtual Genero? IdGeneroNavigation { get; set; }

    public virtual Idioma IdIdiomaNavigation { get; set; } = null!;

    public virtual TipoMedio? IdTipoMedioNavigation { get; set; }

    public virtual ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
}
