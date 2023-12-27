﻿using System;
using System.Collections.Generic;

namespace DL;

public partial class Autor
{
    public int IdAutor { get; set; }

    public string? Nombre { get; set; }

    public string? ApellidoPaterno { get; set; }

    public string? ApellidoMaterno { get; set; }

    public virtual ICollection<Medio> Medios { get; set; } = new List<Medio>();
}
