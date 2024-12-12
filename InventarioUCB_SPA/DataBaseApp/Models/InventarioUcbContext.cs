using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace InventarioUCB_SPA.DataBaseApp.Models;

public partial class InventarioUcbContext : DbContext
{
    public InventarioUcbContext()
    {
    }

    public InventarioUcbContext(DbContextOptions<InventarioUcbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Componentesaccesorio> Componentesaccesorios { get; set; }

    public virtual DbSet<Detallessolicitudprestamo> Detallessolicitudprestamos { get; set; }

    public virtual DbSet<Equipo> Equipos { get; set; }

    public virtual DbSet<EquipoComponente> EquipoComponentes { get; set; }

    public virtual DbSet<Prestamo> Prestamos { get; set; }

    public virtual DbSet<Registrosactividade> Registrosactividades { get; set; }

    public virtual DbSet<Reporte> Reportes { get; set; }

    public virtual DbSet<Solicitudesprestamo> Solicitudesprestamos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=InventarioUCB;user=root;password=Ucb.8147071", Microsoft.EntityFrameworkCore.ServerVersion.Parse("11.6.2-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_uca1400_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("categorias");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.Area)
                .HasDefaultValueSql("'Aula'")
                .HasColumnType("enum('Aula','Laboratorio','Taller')")
                .HasColumnName("AREA");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("NOMBRE");
        });

        modelBuilder.Entity<Componentesaccesorio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("componentesaccesorios");

            entity.HasIndex(e => e.CodigoComponente, "CODIGO_COMPONENTE").IsUnique();

            entity.HasIndex(e => e.CodigoUcb, "CODIGO_UCB").IsUnique();

            entity.HasIndex(e => e.IdCategoria, "ID_CATEGORIA");

            entity.HasIndex(e => e.NumeroSerie, "NUMERO_SERIE").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.CodigoComponente).HasColumnName("CODIGO_COMPONENTE");
            entity.Property(e => e.CodigoUcb).HasColumnName("CODIGO_UCB");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.Estado)
                .HasDefaultValueSql("'Disponible'")
                .HasColumnType("enum('Disponible','Ocupado','Mantenimiento','Eliminado')")
                .HasColumnName("ESTADO");
            entity.Property(e => e.EstadoComponente)
                .HasDefaultValueSql("'Nuevo'")
                .HasColumnType("enum('Nuevo','Bueno','Bueno - Sellado','Regular','Usado')")
                .HasColumnName("ESTADO_COMPONENTE");
            entity.Property(e => e.Fabricante)
                .HasMaxLength(255)
                .HasColumnName("FABRICANTE");
            entity.Property(e => e.IdCategoria)
                .HasColumnType("int(11)")
                .HasColumnName("ID_CATEGORIA");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.NumeroSerie).HasColumnName("NUMERO_SERIE");
            entity.Property(e => e.Ubicacion)
                .HasMaxLength(10)
                .HasColumnName("UBICACION");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Componentesaccesorios)
                .HasForeignKey(d => d.IdCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("componentesaccesorios_ibfk_1");
        });

        modelBuilder.Entity<Detallessolicitudprestamo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("detallessolicitudprestamo");

            entity.HasIndex(e => e.IdEquipo, "ID_EQUIPO");

            entity.HasIndex(e => e.IdSolicitudPrestamo, "ID_SOLICITUD_PRESTAMO");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.Estado)
                .HasDefaultValueSql("'Seleccionado'")
                .HasColumnType("enum('Seleccionado','Deseleccionado')")
                .HasColumnName("ESTADO");
            entity.Property(e => e.IdEquipo)
                .HasColumnType("int(11)")
                .HasColumnName("ID_EQUIPO");
            entity.Property(e => e.IdSolicitudPrestamo)
                .HasColumnType("int(11)")
                .HasColumnName("ID_SOLICITUD_PRESTAMO");

            entity.HasOne(d => d.IdEquipoNavigation).WithMany(p => p.Detallessolicitudprestamos)
                .HasForeignKey(d => d.IdEquipo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("detallessolicitudprestamo_ibfk_2");

            entity.HasOne(d => d.IdSolicitudPrestamoNavigation).WithMany(p => p.Detallessolicitudprestamos)
                .HasForeignKey(d => d.IdSolicitudPrestamo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("detallessolicitudprestamo_ibfk_1");
        });

        modelBuilder.Entity<Equipo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("equipos");

            entity.HasIndex(e => e.CodigoEquipo, "CODIGO_EQUIPO").IsUnique();

            entity.HasIndex(e => e.CodigoUcb, "CODIGO_UCB").IsUnique();

            entity.HasIndex(e => e.IdCategoria, "ID_CATEGORIA");

            entity.HasIndex(e => e.NumeroSerie, "NUMERO_SERIE").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.CodigoEquipo).HasColumnName("CODIGO_EQUIPO");
            entity.Property(e => e.CodigoUcb).HasColumnName("CODIGO_UCB");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.DireccionEnlace)
                .HasMaxLength(255)
                .HasColumnName("DIRECCION_ENLACE");
            entity.Property(e => e.Estado)
                .HasDefaultValueSql("'Disponible'")
                .HasColumnType("enum('Disponible','Ocupado','Mantenimiento','Eliminado')")
                .HasColumnName("ESTADO");
            entity.Property(e => e.EstadoEquipo)
                .HasDefaultValueSql("'Nuevo'")
                .HasColumnType("enum('Nuevo','Bueno','Bueno - Sellado','Regular','Usado')")
                .HasColumnName("ESTADO_EQUIPO");
            entity.Property(e => e.Fabricante)
                .HasMaxLength(255)
                .HasColumnName("FABRICANTE");
            entity.Property(e => e.IdCategoria)
                .HasColumnType("int(11)")
                .HasColumnName("ID_CATEGORIA");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.NumeroSerie).HasColumnName("NUMERO_SERIE");
            entity.Property(e => e.Ubicacion)
                .HasMaxLength(10)
                .HasColumnName("UBICACION");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Equipos)
                .HasForeignKey(d => d.IdCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("equipos_ibfk_1");
        });

        modelBuilder.Entity<EquipoComponente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("equipo_componente");

            entity.HasIndex(e => e.IdComponente, "ID_COMPONENTE");

            entity.HasIndex(e => e.IdEquipo, "ID_EQUIPO");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.Estado)
                .HasDefaultValueSql("'Asociado'")
                .HasColumnType("enum('Asociado','Eliminado')")
                .HasColumnName("ESTADO");
            entity.Property(e => e.IdComponente)
                .HasColumnType("int(11)")
                .HasColumnName("ID_COMPONENTE");
            entity.Property(e => e.IdEquipo)
                .HasColumnType("int(11)")
                .HasColumnName("ID_EQUIPO");

            entity.HasOne(d => d.IdComponenteNavigation).WithMany(p => p.EquipoComponentes)
                .HasForeignKey(d => d.IdComponente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("equipo_componente_ibfk_2");

            entity.HasOne(d => d.IdEquipoNavigation).WithMany(p => p.EquipoComponentes)
                .HasForeignKey(d => d.IdEquipo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("equipo_componente_ibfk_1");
        });

        modelBuilder.Entity<Prestamo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("prestamos");

            entity.HasIndex(e => e.IdSolicitudPrestamo, "ID_SOLICITUD_PRESTAMO");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.Estado)
                .HasDefaultValueSql("'Activo'")
                .HasColumnType("enum('Activo','Devuelto','Retrasado')")
                .HasColumnName("ESTADO");
            entity.Property(e => e.FechaDevolucion).HasColumnName("FECHA_DEVOLUCION");
            entity.Property(e => e.IdSolicitudPrestamo)
                .HasColumnType("int(11)")
                .HasColumnName("ID_SOLICITUD_PRESTAMO");

            entity.HasOne(d => d.IdSolicitudPrestamoNavigation).WithMany(p => p.Prestamos)
                .HasForeignKey(d => d.IdSolicitudPrestamo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("prestamos_ibfk_1");
        });

        modelBuilder.Entity<Registrosactividade>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("registrosactividades");

            entity.HasIndex(e => e.IdAdmin, "ID_ADMIN");

            entity.HasIndex(e => e.IdComponente, "ID_COMPONENTE");

            entity.HasIndex(e => e.IdEquipo, "ID_EQUIPO");

            entity.HasIndex(e => e.IdUsuario, "ID_USUARIO");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.Actividad)
                .HasDefaultValueSql("'Crear'")
                .HasColumnType("enum('Crear','Asociar','Mover','Modificar','Eliminar')")
                .HasColumnName("ACTIVIDAD");
            entity.Property(e => e.Detalle)
                .HasColumnType("text")
                .HasColumnName("DETALLE");
            entity.Property(e => e.FechaHora)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("FECHA_HORA");
            entity.Property(e => e.IdAdmin)
                .HasColumnType("int(11)")
                .HasColumnName("ID_ADMIN");
            entity.Property(e => e.IdComponente)
                .HasColumnType("int(11)")
                .HasColumnName("ID_COMPONENTE");
            entity.Property(e => e.IdEquipo)
                .HasColumnType("int(11)")
                .HasColumnName("ID_EQUIPO");
            entity.Property(e => e.IdUsuario)
                .HasColumnType("int(11)")
                .HasColumnName("ID_USUARIO");

            entity.HasOne(d => d.IdAdminNavigation).WithMany(p => p.RegistrosactividadeIdAdminNavigations)
                .HasForeignKey(d => d.IdAdmin)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("registrosactividades_ibfk_1");

            entity.HasOne(d => d.IdComponenteNavigation).WithMany(p => p.Registrosactividades)
                .HasForeignKey(d => d.IdComponente)
                .HasConstraintName("registrosactividades_ibfk_4");

            entity.HasOne(d => d.IdEquipoNavigation).WithMany(p => p.Registrosactividades)
                .HasForeignKey(d => d.IdEquipo)
                .HasConstraintName("registrosactividades_ibfk_3");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.RegistrosactividadeIdUsuarioNavigations)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("registrosactividades_ibfk_2");
        });

        modelBuilder.Entity<Reporte>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("reportes");

            entity.HasIndex(e => e.IdPrestamo, "ID_PRESTAMO");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.Contenido)
                .HasColumnType("text")
                .HasColumnName("CONTENIDO");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("curdate()")
                .HasColumnName("FECHA_CREACION");
            entity.Property(e => e.IdPrestamo)
                .HasColumnType("int(11)")
                .HasColumnName("ID_PRESTAMO");
            entity.Property(e => e.Titulo)
                .HasMaxLength(100)
                .HasColumnName("TITULO");

            entity.HasOne(d => d.IdPrestamoNavigation).WithMany(p => p.Reportes)
                .HasForeignKey(d => d.IdPrestamo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("reportes_ibfk_1");
        });

        modelBuilder.Entity<Solicitudesprestamo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("solicitudesprestamo");

            entity.HasIndex(e => e.IdUsuario, "ID_USUARIO");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.Estado)
                .HasDefaultValueSql("'Pendiente'")
                .HasColumnType("enum('Pendiente','Aprobada','Rechazada')")
                .HasColumnName("ESTADO");
            entity.Property(e => e.FechaFinPrestamo).HasColumnName("FECHA_FIN_PRESTAMO");
            entity.Property(e => e.FechaInicioPrestamo).HasColumnName("FECHA_INICIO_PRESTAMO");
            entity.Property(e => e.FechaSolicitud).HasColumnName("FECHA_SOLICITUD");
            entity.Property(e => e.IdUsuario)
                .HasColumnType("int(11)")
                .HasColumnName("ID_USUARIO");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Solicitudesprestamos)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("solicitudesprestamo_ibfk_1");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("usuarios");

            entity.HasIndex(e => e.Correo, "CORREO").IsUnique();

            entity.HasIndex(e => e.Telefono, "TELEFONO").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .HasColumnName("APELLIDO");
            entity.Property(e => e.Ci)
                .HasMaxLength(10)
                .HasColumnName("CI");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(255)
                .HasColumnName("CONTRASEÑA");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .HasColumnName("CORREO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Rol)
                .HasDefaultValueSql("'Cliente'")
                .HasColumnType("enum('Cliente','Administrativo','Root')")
                .HasColumnName("ROL");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("TELEFONO");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
