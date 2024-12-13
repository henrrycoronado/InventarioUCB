using System.ComponentModel;
using InventarioUCB_SPA.DataBaseApp.Models.Services;
namespace ServicesApp.Models;
public class ComponenteModelNuevo
{
    public string? CodigoUcb { get; set; }

    public string CodigoComponente { get; set; } = null!;

    public string? NumeroSerie { get; set; }

    public string? Fabricante { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int IdCategoria { get; set; }

    public string Ubicacion { get; set; } = null!;

    public string? EstadoComponente { get; set; }
}
public class ComponenteModel: ComponenteModelNuevo{
    public string? Estado { get; set; }
}