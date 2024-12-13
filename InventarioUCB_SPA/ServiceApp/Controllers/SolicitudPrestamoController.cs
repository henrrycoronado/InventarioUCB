using Microsoft.AspNetCore.Mvc;
using ServicesApp.Models.Services;
using ServicesApp.Models;
using InventarioUCB_SPA.DataBaseApp.Models;

namespace InventarioUCB_SPA.Controllers;

[ApiController]
[Route("[controller]")]
public class SolicitudPrestamoController : ControllerBase
{
    private readonly ISolicitudPrestamoService _service;
    public SolicitudPrestamoController(ISolicitudPrestamoService service)
    {
        _service = service;
    }

    [HttpPost("EnviarSolicitu")]
    public bool Enviar([FromBody] SolicitudPrestamoModel request)
    {
        return _service.EnviarSolicitudPrestamo(request);
    }

    [HttpGet("VerSoicitudes")]
    public IEnumerable<SolicitudPrestamoModel> Mostrar()
    {
        return _service.mostrarSolicitudesPrestamo();
    }

    [HttpGet("VerDetalleSolicitud/{idSoli}")]
    public IEnumerable<Detallessolicitudprestamo> MostrarDetalle(int idSoli)
    {
        return _service.DetalleSolicitudPrestamo(idSoli);
    }
    [HttpGet("VerSolicitud/{idSoli}")]
    public SolicitudPrestamoModel MostrarSoli(int idSoli)
    {
        return _service.VerSolicitud(idSoli);
    }

    [HttpGet("VerHistorialSolicitud/{idUser}")]
    public IEnumerable<SolicitudPrestamoModel> HistorialSoli(int idUser)
    {
        return _service.HistorialSolicitudPrestamo(idUser);
    }
    
}
