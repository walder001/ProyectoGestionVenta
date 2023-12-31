﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProyectoGestionVenta.Models
{
    public partial class GestionVentasContext : DbContext
    {
        public GestionVentasContext()
        {
        }

        public GestionVentasContext(DbContextOptions<GestionVentasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Articulo> Articulos { get; set; } = null!;
        public virtual DbSet<Categorium> Categoria { get; set; } = null!;
        public virtual DbSet<DetalleIngreso> DetalleIngresos { get; set; } = null!;
        public virtual DbSet<DetalleVentum> DetalleVenta { get; set; } = null!;
        public virtual DbSet<Ingreso> Ingresos { get; set; } = null!;
        public virtual DbSet<Persona> Personas { get; set; } = null!;
        public virtual DbSet<Rol> Rols { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
        public virtual DbSet<Ventum> Venta { get; set; } = null!;

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //if (!optionsBuilder.IsConfigured)
        //    //{
        //    //    optionsBuilder.UseSqlServer("Name=ConnectionStrings:dev");
        //    //}
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Articulo>(entity =>
            {
                entity.ToTable("articulo");

                entity.HasIndex(e => e.Nombre, "UQ__articulo__72AFBCC69AC85533")
                    .IsUnique();

                entity.Property(e => e.ArticuloId).HasColumnName("articuloId");

                entity.Property(e => e.CategoriaId).HasColumnName("categoriaId");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("codigo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.PrecioVenta)
                    .HasColumnType("decimal(11, 2)")
                    .HasColumnName("precio_venta");

                entity.Property(e => e.Stock).HasColumnName("stock");

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.Articulos)
                    .HasForeignKey(d => d.CategoriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__articulo__catego__5812160E");
            });

            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.HasKey(e => e.CategoriaId)
                    .HasName("PK__categori__6378C0C005A95A44");

                entity.ToTable("categoria");

                entity.HasIndex(e => e.Nombre, "UQ__categori__72AFBCC649B806D7")
                    .IsUnique();

                entity.Property(e => e.CategoriaId).HasColumnName("categoriaId");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<DetalleIngreso>(entity =>
            {
                entity.ToTable("detalle_ingreso");

                entity.Property(e => e.DetalleIngresoId).HasColumnName("detalle_ingresoId");

                entity.Property(e => e.ArticuloId).HasColumnName("articuloId");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.IngresoId).HasColumnName("ingresoId");

                entity.Property(e => e.Precio)
                    .HasColumnType("decimal(11, 2)")
                    .HasColumnName("precio");

                entity.HasOne(d => d.Articulo)
                    .WithMany(p => p.DetalleIngresos)
                    .HasForeignKey(d => d.ArticuloId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__detalle_i__artic__5FB337D6");

                entity.HasOne(d => d.Ingreso)
                    .WithMany(p => p.DetalleIngresos)
                    .HasForeignKey(d => d.IngresoId)
                    .HasConstraintName("FK__detalle_i__ingre__5EBF139D");
            });

            modelBuilder.Entity<DetalleVentum>(entity =>
            {
                entity.HasKey(e => e.DetalleVentaId)
                    .HasName("PK__detalle___000CCCF7C00A9670");

                entity.ToTable("detalle_venta");

                entity.Property(e => e.DetalleVentaId).HasColumnName("detalle_ventaId");

                entity.Property(e => e.ArticuloId).HasColumnName("articuloId");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.Descuento)
                    .HasColumnType("decimal(11, 2)")
                    .HasColumnName("descuento");

                entity.Property(e => e.Precio)
                    .HasColumnType("decimal(11, 2)")
                    .HasColumnName("precio");

                entity.Property(e => e.VentaId).HasColumnName("ventaId");

                entity.HasOne(d => d.Articulo)
                    .WithMany(p => p.DetalleVenta)
                    .HasForeignKey(d => d.ArticuloId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__detalle_v__artic__6754599E");

                entity.HasOne(d => d.Venta)
                    .WithMany(p => p.DetalleVenta)
                    .HasForeignKey(d => d.VentaId)
                    .HasConstraintName("FK__detalle_v__venta__66603565");
            });

            modelBuilder.Entity<Ingreso>(entity =>
            {
                entity.ToTable("ingreso");

                entity.Property(e => e.IngresoId).HasColumnName("ingresoId");

                entity.Property(e => e.Estado)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("estado");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.Impuesto)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("impuesto");

                entity.Property(e => e.NumComprobante)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("num_comprobante");

                entity.Property(e => e.ProveedorId).HasColumnName("proveedorId");

                entity.Property(e => e.SerieComprobante)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("serie_comprobante");

                entity.Property(e => e.TipoComprobante)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("tipo_comprobante");

                entity.Property(e => e.Total)
                    .HasColumnType("decimal(11, 2)")
                    .HasColumnName("total");

                entity.Property(e => e.UsuarioId).HasColumnName("usuarioId");

                entity.HasOne(d => d.Proveedor)
                    .WithMany(p => p.Ingresos)
                    .HasForeignKey(d => d.ProveedorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ingreso__proveed__5AEE82B9");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Ingresos)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ingreso__usuario__5BE2A6F2");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.ToTable("persona");

                entity.Property(e => e.Personaid).HasColumnName("personaid");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.NumDocumento)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("num_documento");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("telefono");

                entity.Property(e => e.TipoDocumento)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("tipo_documento");

                entity.Property(e => e.TipoPersona)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("tipo_persona");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.ToTable("rol");

                entity.Property(e => e.RolId).HasColumnName("rolId");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuario");

                entity.Property(e => e.UsuarioId).HasColumnName("usuarioId");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.NumDocumento)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("num_documento");

                entity.Property(e => e.Password)
                    .HasMaxLength(1)
                    .HasColumnName("password");

                entity.Property(e => e.RolId).HasColumnName("rolId");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("telefono");

                entity.Property(e => e.TipoDocumento)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("tipo_documento");

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.RolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__usuario__rolId__4F7CD00D");
            });

            modelBuilder.Entity<Ventum>(entity =>
            {
                entity.HasKey(e => e.VentaId)
                    .HasName("PK__venta__40B8EB54F4382265");

                entity.ToTable("venta");

                entity.Property(e => e.VentaId).HasColumnName("ventaId");

                entity.Property(e => e.ClienteId).HasColumnName("clienteId");

                entity.Property(e => e.Estado)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("estado");

                entity.Property(e => e.FechaHora)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_hora");

                entity.Property(e => e.Impuesto)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("impuesto");

                entity.Property(e => e.NumComprobante)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("num_comprobante");

                entity.Property(e => e.SerieComprobante)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("serie_comprobante");

                entity.Property(e => e.TipoComprobante)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("tipo_comprobante");

                entity.Property(e => e.Total)
                    .HasColumnType("decimal(11, 2)")
                    .HasColumnName("total");

                entity.Property(e => e.UsuarioId).HasColumnName("usuarioId");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__venta__clienteId__628FA481");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__venta__usuarioId__6383C8BA");
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
