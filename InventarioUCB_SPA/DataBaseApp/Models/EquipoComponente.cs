using System;
using System.Collections.Generic;

namespace InventarioUCB_SPA.DataBaseApp.Models;

public partial class EquipoComponente
{
    public int Id { get; set; }

    public int IdEquipo { get; set; }

    public int IdComponente { get; set; }

    public string? Estado { get; set; }

    public virtual Componentesaccesorio IdComponenteNavigation { get; set; } = null!;

    public virtual Equipo IdEquipoNavigation { get; set; } = null!;
}
