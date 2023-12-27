using System;
using System.Collections.Generic;

namespace DL;

public partial class Genero
{
    public int IdGenero { get; set; }

    public string? NombreGenero { get; set; }

    public virtual ICollection<Medio> Medios { get; set; } = new List<Medio>();
}
