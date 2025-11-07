using System;
using System.Collections.Generic;

namespace GestionODS.Models;

public partial class Region
{
    public int IdRegion { get; set; }

    public string NombreRegion { get; set; } = null!;

    public int IdPais { get; set; }

    public virtual ICollection<DatoIndicador> DatoIndicadors { get; set; } = new List<DatoIndicador>();

    public virtual Pai IdPaisNavigation { get; set; } = null!;
}
