using Microsoft.AspNetCore.Mvc;
using ServicesApp.Models.Services;
using ServicesApp.Models;
using InventarioUCB_SPA.DataBaseApp.Models;

namespace InventarioUCB_SPA.Controllers;

[ApiController]
[Route("[controller]")]
public class PrestamoController : ControllerBase
{
    private readonly IPrestamoService _service;
    public PrestamoController(IPrestamoService service)
    {
        _service = service;
    }

    [HttpPost("CrearPrestamo")]
    public string Crear([FromBody] Solicitudesprestamo request)
    {
        return _service.CrearPrestamo(request);
    }

    [HttpGet("DetallePrestamo/{idPrestamo}")]
    public PrestamoModel DetallePrestamo(int idPrestamo)
    {
        return _service.DetallePrestamo(idPrestamo);
    }

    [HttpGet("HistorialPrestamo/{idUser}")]
    public List<PrestamoModel> HisrorialPrestamo(int idUser)
    {
        return _service.HistorialPrestamo(idUser);
    }

    [HttpGet("DevolverPrestamo/{idPrestamo}")]
    public string Devolucion(int idPrestamo)
    {
        return _service.DevolverPrestamo(idPrestamo);
    }
}
