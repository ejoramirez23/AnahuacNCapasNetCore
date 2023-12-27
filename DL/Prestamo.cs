using System;
using System.Collections.Generic;

namespace DL;

public partial class Prestamo
{
    public int IdPrestamo { get; set; }

    public int? IdMedio { get; set; }

    public DateTime? FechaPrestamo { get; set; }

    public DateTime? FechaEntrega { get; set; }

    public bool? Estatus { get; set; }

    public string? IdUsuario { get; set; }

    public virtual Medio? IdMedioNavigation { get; set; }

    public virtual AspNetUser? IdUsuarioNavigation { get; set; }
}
