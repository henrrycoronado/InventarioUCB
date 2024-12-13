using Microsoft.AspNetCore.Mvc;
using ServicesApp.Models.Services;
using ServicesApp.Models;

namespace InventarioUCB_SPA.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly ILoginService _service;
    public UsuarioController(ILoginService service)
    {
        _service = service;
    }

    [HttpPost("")]
    public int? Loggin([FromBody] LoginRequest request)
    {
        Console.WriteLine("se llego al controlador");
        return _service.Logear(request.Correo, request.Password);
    }
}
