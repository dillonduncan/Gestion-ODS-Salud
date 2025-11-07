using System;
using System.Collections.Generic;
using GestionODS.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionODS.DAL.DataContext;

public partial class GestionOdsSaludContext : DbContext
{
    public GestionOdsSaludContext()
    {
    }

    public GestionOdsSaludContext(DbContextOptions<GestionOdsSaludContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Continente> Continentes { get; set; }

    public virtual DbSet<DatoIndicador> DatoIndicadors { get; set; }

    public virtual DbSet<FuenteDato> FuenteDatos { get; set; }

    public virtual DbSet<IndicadorSalud> IndicadorSaluds { get; set; }

    public virtual DbSet<MetaOd> MetaOds { get; set; }

    public virtual DbSet<ObjetivoOd> ObjetivoOds { get; set; }

    public virtual DbSet<Pais> Pais { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    public virtual DbSet<Reporte> Reportes { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Continente>(entity =>
        {
            entity.HasKey(e => e.IdContinente).HasName("PK__continen__985A3622A4E5CB9A");

            entity.ToTable("continente");

            entity.HasIndex(e => e.NombreContinente, "UQ__continen__70FC16CA732B1DD1").IsUnique();

            entity.Property(e => e.IdContinente).HasColumnName("id_continente");
            entity.Property(e => e.NombreContinente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_continente");
        });

        modelBuilder.Entity<DatoIndicador>(entity =>
        {
            entity.HasKey(e => e.IdDato).HasName("PK__dato_ind__95283FC252048AEF");

            entity.ToTable("dato_indicador");

            entity.Property(e => e.IdDato).HasColumnName("id_dato");
            entity.Property(e => e.Anio).HasColumnName("anio");
            entity.Property(e => e.FechaActualizacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_actualizacion");
            entity.Property(e => e.IdFuente).HasColumnName("id_fuente");
            entity.Property(e => e.IdIndicador).HasColumnName("id_indicador");
            entity.Property(e => e.IdPais).HasColumnName("id_pais");
            entity.Property(e => e.IdRegion).HasColumnName("id_region");
            entity.Property(e => e.NivelConfianza)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nivel_confianza");
            entity.Property(e => e.Valor)
                .HasColumnType("decimal(15, 4)")
                .HasColumnName("valor");

            entity.HasOne(d => d.IdFuenteNavigation).WithMany(p => p.DatoIndicadors)
                .HasForeignKey(d => d.IdFuente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dato_indicador_fuente_datos");

            entity.HasOne(d => d.IdIndicadorNavigation).WithMany(p => p.DatoIndicadors)
                .HasForeignKey(d => d.IdIndicador)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dato_indicador_indicador_salud");

            entity.HasOne(d => d.IdPaisNavigation).WithMany(p => p.DatoIndicadors)
                .HasForeignKey(d => d.IdPais)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dato_indicador_pais");

            entity.HasOne(d => d.IdRegionNavigation).WithMany(p => p.DatoIndicadors)
                .HasForeignKey(d => d.IdRegion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dato_indicador_region");
        });

        modelBuilder.Entity<FuenteDato>(entity =>
        {
            entity.HasKey(e => e.IdFuente).HasName("PK__fuente_d__D899AF3D5B65050E");

            entity.ToTable("fuente_datos");

            entity.Property(e => e.IdFuente).HasColumnName("id_fuente");
            entity.Property(e => e.Descripcion)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.NombreFuente)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("nombre_fuente");
            entity.Property(e => e.TipoFuente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipo_fuente");
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("url");
        });

        modelBuilder.Entity<IndicadorSalud>(entity =>
        {
            entity.HasKey(e => e.IdIndicador).HasName("PK__indicado__CDEA22ABC3BF63AF");

            entity.ToTable("indicador_salud");

            entity.HasIndex(e => e.CodigoIndicador, "UQ__indicado__9A17F5F4767E96BE").IsUnique();

            entity.Property(e => e.IdIndicador).HasColumnName("id_indicador");
            entity.Property(e => e.CodigoIndicador)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("codigo_indicador");
            entity.Property(e => e.Descripcion)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.IdMeta).HasColumnName("id_meta");
            entity.Property(e => e.NombreIndicador)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("nombre_indicador");
            entity.Property(e => e.UnidadMedida)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("unidad_medida");

            entity.HasOne(d => d.IdMetaNavigation).WithMany(p => p.IndicadorSaluds)
                .HasForeignKey(d => d.IdMeta)
                .HasConstraintName("FK__indicador__id_me__47DBAE45");
        });

        modelBuilder.Entity<MetaOd>(entity =>
        {
            entity.HasKey(e => e.IdMeta).HasName("PK__meta_ods__68A1E9B8B452A5B0");

            entity.ToTable("meta_ods");

            entity.Property(e => e.IdMeta).HasColumnName("id_meta");
            entity.Property(e => e.CodigoMeta)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("codigo_meta");
            entity.Property(e => e.Descripcion)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.IdObjetivo).HasColumnName("id_objetivo");

            entity.HasOne(d => d.IdObjetivoNavigation).WithMany(p => p.MetaOds)
                .HasForeignKey(d => d.IdObjetivo)
                .HasConstraintName("FK__meta_ods__id_obj__440B1D61");
        });

        modelBuilder.Entity<ObjetivoOd>(entity =>
        {
            entity.HasKey(e => e.IdObjetivo).HasName("PK__objetivo__380EF460669EADD5");

            entity.ToTable("objetivo_ods");

            entity.HasIndex(e => e.CodigoObjetivo, "UQ__objetivo__8BB77825C3E4AB90").IsUnique();

            entity.Property(e => e.IdObjetivo).HasColumnName("id_objetivo");
            entity.Property(e => e.CodigoObjetivo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("codigo_objetivo");
            entity.Property(e => e.Descripcion)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.NombreObjetivo)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("nombre_objetivo");
        });

        modelBuilder.Entity<Pais>(entity =>
        {
            entity.HasKey(e => e.IdPais).HasName("PK__pais__0941A3A76AB105FF");

            entity.ToTable("pais");

            entity.HasIndex(e => e.CodigoIso, "UQ__pais__296D3C1003C6F16C").IsUnique();

            entity.Property(e => e.IdPais).HasColumnName("id_pais");
            entity.Property(e => e.CodigoIso)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("codigo_iso");
            entity.Property(e => e.IdContinente).HasColumnName("id_continente");
            entity.Property(e => e.NombrePais)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre_pais");
            entity.Property(e => e.Pib)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("pib");
            entity.Property(e => e.Poblacion).HasColumnName("poblacion");

            entity.HasOne(d => d.IdContinenteNavigation).WithMany(p => p.Pais)
                .HasForeignKey(d => d.IdContinente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__pais__id_contine__3B75D760");
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.HasKey(e => e.IdRegion).HasName("PK__region__3CEC6B52940CC832");

            entity.ToTable("region");

            entity.Property(e => e.IdRegion).HasColumnName("id_region");
            entity.Property(e => e.IdPais).HasColumnName("id_pais");
            entity.Property(e => e.NombreRegion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre_region");

            entity.HasOne(d => d.IdPaisNavigation).WithMany(p => p.Regions)
                .HasForeignKey(d => d.IdPais)
                .HasConstraintName("FK__region__id_pais__3E52440B");
        });

        modelBuilder.Entity<Reporte>(entity =>
        {
            entity.HasKey(e => e.IdReporte).HasName("PK__reporte__87E4F5CBFAC49213");

            entity.ToTable("reporte");

            entity.Property(e => e.IdReporte).HasColumnName("id_reporte");
            entity.Property(e => e.Descripcion)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaGeneracion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_generacion");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.RutaArchivo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ruta_archivo");
            entity.Property(e => e.Titulo)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("titulo");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Reportes)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__reporte__id_usua__5441852A");

            entity.HasMany(d => d.IdDatos).WithMany(p => p.IdReportes)
                .UsingEntity<Dictionary<string, object>>(
                    "ReporteDato",
                    r => r.HasOne<DatoIndicador>().WithMany()
                        .HasForeignKey("IdDato")
                        .HasConstraintName("FK__reporte_d__id_da__656C112C"),
                    l => l.HasOne<Reporte>().WithMany()
                        .HasForeignKey("IdReporte")
                        .HasConstraintName("FK__reporte_d__id_re__6477ECF3"),
                    j =>
                    {
                        j.HasKey("IdReporte", "IdDato").HasName("PK__reporte___BEB67637333FE1FA");
                        j.ToTable("reporte_dato");
                        j.IndexerProperty<int>("IdReporte").HasColumnName("id_reporte");
                        j.IndexerProperty<long>("IdDato").HasColumnName("id_dato");
                    });
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__usuario__4E3E04ADC7527FF6");

            entity.ToTable("usuario");

            entity.HasIndex(e => e.Correo, "UQ__usuario__2A586E0BA89C68D4").IsUnique();

            entity.HasIndex(e => e.NombreUsuario, "UQ__usuario__D4D22D74F46CA33D").IsUnique();

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.ContrasenaHash)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("contrasena_hash");
            entity.Property(e => e.Correo)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre_completo");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_usuario");
            entity.Property(e => e.Rol)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("consultor")
                .HasColumnName("rol");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
