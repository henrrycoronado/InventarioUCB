using Microsoft.AspNetCore.Mvc;
using ServicesApp.Models.Services;
using ServicesApp.Models;

namespace InventarioUCB_SPA.Controllers;

[ApiController]
[Route("[controller]")]
public class GestionarSolicitudesController : ControllerBase
{
    private readonly IGestionarSolicitudService _service;
    public GestionarSolicitudesController(IGestionarSolicitudService service)
    {
        _service = service;
    }

    [HttpPost("Aprobar")]
    public string AprobarSoicitud([FromBody] Ids request)
    {
        return _service.AprobarSolicitud(request.IdElement, request.IdAdministrador);
    }

    [HttpPost("Rechazar")]
    public string RechazarSolicitud([FromBody] Ids request)
    {
        return _service.RechazarSolicitud(request.IdElement, request.IdAdministrador);
    }
}
