using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Modelo;

public partial class UsuarioContext : DbContext
{
    public UsuarioContext()
    {
    }

    public UsuarioContext(DbContextOptions<UsuarioContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Gasto> Gastos { get; set; }

    public virtual DbSet<TablaGasto> TablaGastos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__categori__8A3D240C95ACAF85");

            entity.ToTable("categoria");

            entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");
            entity.Property(e => e.CantidadGastos)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("cantidadGastos");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.NombreCategoria)
                .HasMaxLength(100)
                .HasColumnName("nombreCategoria");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Categoria)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK_UsuarioCategoria");
        });

        modelBuilder.Entity<Gasto>(entity =>
        {
            entity.HasKey(e => e.IdGastos).HasName("PK__gasto__9C14561ADB59EDBE");

            entity.ToTable("gasto");

            entity.Property(e => e.IdGastos).HasColumnName("idGastos");
            entity.Property(e => e.CantidadGasto)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("cantidadGasto");
            entity.Property(e => e.GastoAcumulado).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.LimiteGasto)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("limiteGasto");
            entity.Property(e => e.NombreGasto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreGasto");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Gastos)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("FK__gasto__idCategor__52593CB8");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Gastos)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__gasto__idUsuario__534D60F1");
        });

        modelBuilder.Entity<TablaGasto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TablaGas__3214EC2720934632");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");
            entity.Property(e => e.LimiteGasto).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.TablaGastos)
                .HasForeignKey(d => d.Idusuario)
                .HasConstraintName("FK__TablaGast__IDUsu__5CD6CB2B");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuarios__3214EC0709C059F5");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
