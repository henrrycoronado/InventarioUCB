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
    public int IdElement1 { get; set; }
    public int IdElement2 { get; set; }
}

public class cambiarEstadoEntrada: Ids{
    public bool Mantenimiento { get; set; }
}

public class Ids2: Ids{
    public int IdElement3 { get; set; }
}