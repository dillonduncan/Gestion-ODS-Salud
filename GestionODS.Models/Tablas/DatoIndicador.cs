using System;
using System.Collections.Generic;

namespace GestionODS.Models;

public partial class DatoIndicador
{
    public long IdDato { get; set; }

    public int IdIndicador { get; set; }

    public int IdPais { get; set; }

    public int IdRegion { get; set; }

    public int IdFuente { get; set; }

    public int Anio { get; set; }

    public decimal Valor { get; set; }

    public string? NivelConfianza { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public virtual FuenteDato IdFuenteNavigation { get; set; } = null!;

    public virtual IndicadorSalud IdIndicadorNavigation { get; set; } = null!;

    public virtual Pai IdPaisNavigation { get; set; } = null!;

    public virtual Region IdRegionNavigation { get; set; } = null!;

    public virtual ICollection<Reporte> IdReportes { get; set; } = new List<Reporte>();
}
