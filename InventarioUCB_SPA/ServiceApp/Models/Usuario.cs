using InventarioUCB_SPA.DataBaseApp.Models.Services;
namespace ServicesApp.Models;
public class UsuarioModel
{
    public string Ci { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string? Rol { get; set; }
}

public class UsuarioNuevo
{
    public UsuarioModel usuario { get; set; } = null!;
    public int IdAdministrador { get; set; }
}

public class LoginRequest
{
    public string Correo { get; set; } = null!;
    public string Password { get; set; } = null!;
}

public class enteroletra{
    public int id { get; set;}
    public string estado { get; set; } = null!;
}
