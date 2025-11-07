using System;
using System.Collections.Generic;

namespace GestionODS.DAL.DataContext;

public partial class Continente
{
    public int IdContinente { get; set; }

    public string NombreContinente { get; set; } = null!;

    public virtual ICollection<Pai> Pais { get; set; } = new List<Pai>();
}
