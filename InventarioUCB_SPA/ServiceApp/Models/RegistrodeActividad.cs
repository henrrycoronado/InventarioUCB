using InventarioUCB_SPA.DataBaseApp.Models.Services;
namespace ServicesApp.Models;
public class RegistroActividadModel
{
    public int IdAdmin { get; set; }

    public int? IdComponente { get; set; }

    public int? IdEquipo { get; set; }

    public int? IdUsuario { get; set; }

    public string? Actividad { get; set; }

    public string Detalle { get; set; } = null!;

    public DateTime? FechaHora { get; set; }
}