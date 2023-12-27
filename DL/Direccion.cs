using System;
using System.Collections.Generic;

namespace DL;

public partial class Direccion
{
    public int IdDireccion { get; set; }

    public string? Calle { get; set; }

    public string? NumExterior { get; set; }

    public string? NumInterior { get; set; }

    public int? IdColonia { get; set; }

    public string? IdUsuario { get; set; }

    public int? IdEditorial { get; set; }

    public virtual Colonium? IdColoniaNavigation { get; set; }

    public virtual Editorial? IdEditorialNavigation { get; set; }

    public virtual AspNetUser? IdUsuarioNavigation { get; set; }
}
