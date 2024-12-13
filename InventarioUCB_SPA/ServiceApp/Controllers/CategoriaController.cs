using Microsoft.AspNetCore.Mvc;
using ServicesApp.Models.Services;
using ServicesApp.Models;

namespace InventarioUCB_SPA.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriaController : ControllerBase
{
    private readonly ILoginService _servicel;
    private readonly IRegisterService _servicer;
    public CategoriaController(ILoginService servicel, IRegisterService servicer)
    {
        _servicel = servicel;
        _servicer = servicer;
    }

    [HttpPost("Loggin")]
    public int? Loggin([FromBody] LoginRequest request)
    {
        return _servicel.Logear(request.Correo, request.Password);
    }

    [HttpPost("CrearCuenta")]
    public string NuevaCuenta([FromBody] UsuarioNuevo user)
    {
        return _servicer.RegistrarUsuario(user.usuario, user.IdAdministrador);
    }
}
