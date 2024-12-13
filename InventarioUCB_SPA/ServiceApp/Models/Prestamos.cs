using InventarioUCB_SPA.DataBaseApp.Models.Services;
namespace ServicesApp.Models;
public class PrestamoModel
{
    public int IdSolicitudPrestamo { get; set; }

    public DateOnly? FechaDevolucion { get; set; }

    public string? Estado { get; set; }
}