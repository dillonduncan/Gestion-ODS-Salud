using System;
using System.Collections.Generic;

namespace GestionODS.Models;

public partial class MetaOd
{
    public int IdMeta { get; set; }

    public int IdObjetivo { get; set; }

    public string CodigoMeta { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ObjetivoOd IdObjetivoNavigation { get; set; } = null!;

    public virtual ICollection<IndicadorSalud> IndicadorSaluds { get; set; } = new List<IndicadorSalud>();
}
