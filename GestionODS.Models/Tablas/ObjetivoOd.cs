using System;
using System.Collections.Generic;

namespace GestionODS.Models;

public partial class ObjetivoOd
{
    public int IdObjetivo { get; set; }

    public string CodigoObjetivo { get; set; } = null!;

    public string NombreObjetivo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<MetaOd> MetaOds { get; set; } = new List<MetaOd>();
}
