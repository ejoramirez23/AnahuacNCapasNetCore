using System;
using System.Collections.Generic;

namespace DL;

public partial class Idioma
{
    public int IdIdioma { get; set; }

    public string? NombreIdioma { get; set; }

    public virtual ICollection<Medio> Medios { get; set; } = new List<Medio>();
}
