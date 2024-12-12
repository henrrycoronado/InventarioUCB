using System;
using System.Collections.Generic;

namespace InventarioUCB_SPA.DataBaseApp.Models;

public partial class Solicitudesprestamo
{
    public int Id { get; set; }

    public int IdUsuario { get; set; }

    public DateOnly FechaSolicitud { get; set; }

    public DateOnly FechaInicioPrestamo { get; set; }

    public DateOnly FechaFinPrestamo { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<Detallessolicitudprestamo> Detallessolicitudprestamos { get; } = new List<Detallessolicitudprestamo>();

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<Prestamo> Prestamos { get; } = new List<Prestamo>();
}
