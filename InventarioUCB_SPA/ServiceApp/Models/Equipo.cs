using InventarioUCB_SPA.DataBaseApp.Models.Services;
namespace ServicesApp.Models;
public class EquipoModel
{
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
}