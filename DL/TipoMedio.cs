using System;
using System.Collections.Generic;

namespace DL;

public partial class TipoMedio
{
    public int IdTipoMedio { get; set; }

    public string? NombreTm { get; set; }

    public virtual ICollection<Medio> Medios { get; set; } = new List<Medio>();
}
