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

    [HttpPost("EnviarSolicitud")]
    public bool Enviar([FromBody] SolicitudPrestamoModel request)
    {
        return _service.EnviarSolicitudPrestamo(request);
    }

    [HttpPost("AgregarDetalle")]
    public string AgregarDetalle([FromBody] Ids request)
    {
        return _service.AddDetalle(request.IdElement1, request.IdElement2);
    }
    [HttpPost("QuitarDetalle")]
    public string QuitarDetalle([FromBody] Ids request)
    {
        return _service.RemoveDetalle(request.IdElement1, request.IdElement2);
    }

    [HttpGet("VerSolicitudes")]
    public IEnumerable<Solicitudesprestamo> Mostrar()
    {
        return _service.mostrarSolicitudesPrestamo();
    }

    [HttpGet("VerDetalleSolicitud/{idSoli}")]
    public IEnumerable<Detallessolicitudprestamo> MostrarDetalle(int idSoli)
    {
        return _service.DetalleSolicitudPrestamo(idSoli);
    }
    
    [HttpGet("VerSolicitud/{idSoli}")]
    public Solicitudesprestamo? MostrarSoli(int idSoli)
    {
        return _service.VerSolicitud(idSoli);
    }

    [HttpGet("VerHistorialSolicitud/{idUser}")]
    public IEnumerable<Solicitudesprestamo> HistorialSoli(int idUser)
    {
        return _service.HistorialSolicitudPrestamo(idUser);
    }
    
}
