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
    public bool AprobarSoicitud([FromBody] Ids request)
    {
        if(_service.AprobarSolicitud(request.IdElement1, request.IdElement2))
        {
            return true;
        }
        return false;
    }


    [HttpPost("Rechazar")]
    public bool RechazarSolicitud([FromBody] Ids request)
    {
        if(_service.RechazarSolicitud(request.IdElement1, request.IdElement2))
        {
            return true;
        }
        return false;
    }


}
