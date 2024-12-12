using System;
using System.Collections.Generic;

namespace InventarioUCB_SPA.DataBaseApp.Models;

public partial class Equipo
{
    public int Id { get; set; }

    public string? CodigoUcb { get; set; }

    public string CodigoEquipo { get; set; } = null!;

    public string? NumeroSerie { get; set; }

    public string? Fabricante { get; set; }

    public string? DireccionEnlace { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int IdCategoria { get; set; }

    public string Ubicacion { get; set; } = null!;

    public string? EstadoEquipo { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<Detallessolicitudprestamo> Detallessolicitudprestamos { get; } = new List<Detallessolicitudprestamo>();

    public virtual ICollection<EquipoComponente> EquipoComponentes { get; } = new List<EquipoComponente>();

    public virtual Categoria IdCategoriaNavigation { get; set; } = null!;

    public virtual ICollection<Registrosactividade> Registrosactividades { get; } = new List<Registrosactividade>();
}
