using Microsoft.AspNetCore.Mvc;
using ServicesApp.Models.Services;
using ServicesApp.Models;

namespace InventarioUCB_SPA.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly ILoginService _servicel;
    private readonly IRegisterService _servicer;
    private readonly LoginData _login;
    public UsuarioController(ILoginService servicel, IRegisterService servicer, LoginData login)
    {
        _servicel = servicel;
        _servicer = servicer;
        _login = login;
    }

    [HttpPost("Loggin")]
    public int? Loggin([FromBody] LoginRequest request)
    {
        var result = _servicel.Logear(request.Correo, request.Password);
        if(result != null){
            _login.AgregarId(result);
        }
        return result;
    }
    [HttpGet("CerrarSesion")]
    public void Cerrar()
    {
        _login.CerrarSesion();
        return ;
    }

    [HttpPost("CrearCuenta")]
    public string NuevaCuenta([FromBody] UsuarioNuevo user)
    {
        return _servicer.RegistrarUsuario(user.usuario, user.IdAdministrador);
    }
    [HttpGet("VerId")]
    public int? ver()
    {
        return _login.UserId;
    }

    [HttpGet("VerRol/{id}")]
    public string? verRol(int id)
    {
        return _servicel.GetRol(id);
    }
}
