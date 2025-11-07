using System;
using System.Collections.Generic;

namespace GestionODS.DAL.DataContext;

public partial class FuenteDato
{
    public int IdFuente { get; set; }

    public string NombreFuente { get; set; } = null!;

    public string TipoFuente { get; set; } = null!;

    public string? Url { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<DatoIndicador> DatoIndicadors { get; set; } = new List<DatoIndicador>();
}
