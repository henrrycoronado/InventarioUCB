using System;
using System.Collections.Generic;

namespace InventarioUCB_SPA.DataBaseApp.Models;

public partial class Reporte
{
    public int Id { get; set; }

    public int IdPrestamo { get; set; }

    public string Titulo { get; set; } = null!;

    public string Contenido { get; set; } = null!;

    public DateOnly? FechaCreacion { get; set; }

    public virtual Prestamo IdPrestamoNavigation { get; set; } = null!;
}
