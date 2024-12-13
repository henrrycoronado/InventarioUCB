using InventarioUCB_SPA.DataBaseApp.Models.Services;
namespace ServicesApp.Models;
public class ReporteModel
{
    public int Id { get; set; }

    public int IdPrestamo { get; set; }

    public string Titulo { get; set; } = null!;

    public string Contenido { get; set; } = null!;

    public DateOnly? FechaCreacion { get; set; }
}