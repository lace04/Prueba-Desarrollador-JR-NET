using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GestionBiblioteca.Server.Models;

public partial class DbgestionbibliotecaContext : DbContext
{
  public DbgestionbibliotecaContext()
  {
  }

  public DbgestionbibliotecaContext(DbContextOptions<DbgestionbibliotecaContext> options)
      : base(options)
  {
  }

  public virtual DbSet<Autor> Autores { get; set; }

  public virtual DbSet<Comentario> Comentarios { get; set; }

  public virtual DbSet<Libro> Libros { get; set; }

  public virtual DbSet<Usuario> Usuarios { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Autor>(entity =>
    {
      entity.HasKey(e => e.AutorId).HasName("PK__Autores__F58AE92979F246D2");

      entity.Property(e => e.Nombre)
              .HasMaxLength(50)
              .IsUnicode(false)
              .HasColumnName("nombre");
    });

    modelBuilder.Entity<Comentario>(entity =>
    {
      entity.HasKey(e => e.ComentarioId).HasName("PK__Comentar__F184493843004107");

      entity.Property(e => e.Comentario1)
              .HasMaxLength(200)
              .IsUnicode(false)
              .HasColumnName("comentario");
      entity.Property(e => e.LibroId).HasColumnName("LibroID");
    });

    modelBuilder.Entity<Libro>(entity =>
    {
      entity.HasKey(e => e.LibroId).HasName("PK__Libros__35A1ECED84C3564C");

      entity.Property(e => e.AutorId).HasColumnName("autorID");
      entity.Property(e => e.Titulo)
          .HasMaxLength(50)
          .IsUnicode(false)
          .HasColumnName("titulo");

      modelBuilder.Entity<Usuario>(entity =>
      {
        entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__5B65BF977CF094EF");

        entity.ToTable("Usuario");

        entity.Property(e => e.Clave)
          .HasMaxLength(100)
          .IsUnicode(false);
        entity.Property(e => e.Correo)
          .HasMaxLength(50)
          .IsUnicode(false);
        entity.Property(e => e.Nombre)
          .HasMaxLength(50)
          .IsUnicode(false);
      });

      OnModelCreatingPartial(modelBuilder);
    });
  }

  partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
