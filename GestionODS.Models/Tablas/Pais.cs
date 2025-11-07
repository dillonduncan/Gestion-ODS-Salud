using System;
using System.Collections.Generic;

namespace GestionODS.Models;

public partial class Pais
{
    public int IdPais { get; set; }

    public string NombrePais { get; set; } = null!;

    public string CodigoIso { get; set; } = null!;

    public long? Poblacion { get; set; }

    public decimal? Pib { get; set; }

    public int IdContinente { get; set; }

    public virtual ICollection<DatoIndicador> DatoIndicadors { get; set; } = new List<DatoIndicador>();

    public virtual Continente IdContinenteNavigation { get; set; } = null!;

    public virtual ICollection<Region> Regions { get; set; } = new List<Region>();
}
