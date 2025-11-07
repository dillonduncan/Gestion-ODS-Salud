using System;
using System.Collections.Generic;

namespace GestionODS.Models;

public partial class Continente
{
    public int IdContinente { get; set; }

    public string NombreContinente { get; set; } = null!;

    public virtual ICollection<Pais> Pais { get; set; } = new List<Pais>();
}
