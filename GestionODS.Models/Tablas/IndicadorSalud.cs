using System;
using System.Collections.Generic;

namespace GestionODS.Models;

public partial class IndicadorSalud
{
    public int IdIndicador { get; set; }

    public int IdMeta { get; set; }

    public string CodigoIndicador { get; set; } = null!;

    public string NombreIndicador { get; set; } = null!;

    public string UnidadMedida { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<DatoIndicador> DatoIndicadors { get; set; } = new List<DatoIndicador>();

    public virtual MetaOd IdMetaNavigation { get; set; } = null!;
}
