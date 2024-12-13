using Microsoft.AspNetCore.Mvc;
using ServicesApp.Models.Services;
using ServicesApp.Models;

namespace InventarioUCB_SPA.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriaController : ControllerBase
{
    private readonly ICategoriaServices _service;
    public CategoriaController(ICategoriaServices services)
    {
        _service = services;
    }

    [HttpPost("CrearCategoria")]
    public string Crear([FromBody] CategoriaModel request)
    {
        return _service.CrearCategoria(request);
    }

}
