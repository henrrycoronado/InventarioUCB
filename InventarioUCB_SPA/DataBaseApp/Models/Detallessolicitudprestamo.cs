using System;
using System.Collections.Generic;

namespace InventarioUCB_SPA.DataBaseApp.Models;

public partial class Detallessolicitudprestamo
{
    public int Id { get; set; }

    public int IdSolicitudPrestamo { get; set; }

    public int IdEquipo { get; set; }

    public string? Estado { get; set; }

    public virtual Equipo IdEquipoNavigation { get; set; } = null!;

    public virtual Solicitudesprestamo IdSolicitudPrestamoNavigation { get; set; } = null!;
}
