using Microsoft.AspNetCore.Mvc;
using ServicesApp.Models.Services;
using ServicesApp.Models;
using InventarioUCB_SPA.DataBaseApp.Models;

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
    public string Crear([FromBody] Categoria request)
    {
        return _service.CrearCategoria(request);
    }

    [HttpGet("VerCategorias")]
    public IEnumerable<Categoria> Ver()
    {
        return _service.ObtenerCategorias();
    }
    [HttpGet("VerCategoriasAreas/{area}")]
    public IEnumerable<Categoria> VerAreas(string area)
    {
        return _service.ObtenerCategoriasArea(area);
    }

}
