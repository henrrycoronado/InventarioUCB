using InventarioUCB_SPA.DataBaseApp.Models.Services;
namespace ServicesApp.Models;
public class SolicitudPrestamoModel
{
    public int IdUsuario { get; set; }

    public DateOnly FechaSolicitud { get; set; }

    public DateOnly FechaInicioPrestamo { get; set; }

    public DateOnly FechaFinPrestamo { get; set; }

    public string? Estado { get; set; }
}


public class Ids{
    public int IdAdministrador { get; set; }
    public int IdElement { get; set; }
}