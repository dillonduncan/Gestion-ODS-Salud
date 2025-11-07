using System;
using System.Collections.Generic;

namespace GestionODS.DAL.DataContext;

public partial class Reporte
{
    public int IdReporte { get; set; }

    public int IdUsuario { get; set; }

    public string Titulo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public DateTime? FechaGeneracion { get; set; }

    public string? RutaArchivo { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<DatoIndicador> IdDatos { get; set; } = new List<DatoIndicador>();
}
