﻿using System;
using System.Collections.Generic;

namespace DL;

public partial class Estado
{
    public int IdEstado { get; set; }

    public string? Nombre { get; set; }

    public int? IdPais { get; set; }

    public virtual Pai? IdPaisNavigation { get; set; }

    public virtual ICollection<Municipio> Municipios { get; set; } = new List<Municipio>();
}
