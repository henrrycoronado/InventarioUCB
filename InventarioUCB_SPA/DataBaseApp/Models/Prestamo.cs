using System;
using System.Collections.Generic;

namespace InventarioUCB_SPA.DataBaseApp.Models;

public partial class Prestamo
{
    public int Id { get; set; }

    public int IdSolicitudPrestamo { get; set; }

    public DateOnly? FechaDevolucion { get; set; }

    public string? Estado { get; set; }

    public virtual Solicitudesprestamo IdSolicitudPrestamoNavigation { get; set; } = null!;

    public virtual ICollection<Reporte> Reportes { get; } = new List<Reporte>();
}
