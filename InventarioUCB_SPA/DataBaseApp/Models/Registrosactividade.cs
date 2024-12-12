using System;
using System.Collections.Generic;

namespace InventarioUCB_SPA.DataBaseApp.Models;

public partial class Registrosactividade
{
    public int Id { get; set; }

    public int IdAdmin { get; set; }

    public int? IdComponente { get; set; }

    public int? IdEquipo { get; set; }

    public int? IdUsuario { get; set; }

    public string? Actividad { get; set; }

    public string Detalle { get; set; } = null!;

    public DateTime? FechaHora { get; set; }

    public virtual Usuario IdAdminNavigation { get; set; } = null!;

    public virtual Componentesaccesorio? IdComponenteNavigation { get; set; }

    public virtual Equipo? IdEquipoNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
