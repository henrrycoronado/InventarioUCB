using InventarioUCB_SPA.DataBaseApp.Models.Services;
namespace ServicesApp.Models;
public class EquipoModelNuevo
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
}

public class EquipoModel: EquipoModelNuevo{
    public string? Estado { get; set; } = null!;
}

public class EquipoEntrada{
    public EquipoModelNuevo equipo { get; set; } = null!;
    public int IdAdministrador { get; set; }
}
public class EquipoEntradaUpdate{
    public EquipoModel equipo { get; set; } = null!;
    public int IdAdministrador { get; set; }
}

public class EquipoEntradaDelete{
    public string Codigoequipo { get; set; } = null!;
    public int IdAdministrador { get; set; }
}

public class cambiarEstadoEntrada{
    public int IdAdministrador { get; set; }
    public string Codigoelemento { get; set; } = null!;
    public bool Mantenimiento { get; set; }
}

public class Identificadores{
    public string Codigocomponente{ get; set; } = null!;
    public string Codigoequipo { get; set; } = null!;
    public int IdAdministrador { get; set; }
}