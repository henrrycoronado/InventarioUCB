using System;
using System.Collections.Generic;

namespace InventarioUCB_SPA.DataBaseApp.Models;

public partial class Categoria
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Area { get; set; }

    public virtual ICollection<Componentesaccesorio> Componentesaccesorios { get; } = new List<Componentesaccesorio>();

    public virtual ICollection<Equipo> Equipos { get; } = new List<Equipo>();
}
