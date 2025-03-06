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
    private readonly LoginData _login;
    public SolicitudPrestamoController(ISolicitudPrestamoService service, LoginData login)
    {
        _service = service;
        _login = login;
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

    [HttpGet("VerSolicitudes/{TipoSolicitudes}")]
    public IEnumerable<Solicitudesprestamo> Mostrar(string TipoSolicitudes)
    {
        return _service.mostrarSolicitudesPrestamo(TipoSolicitudes);
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

    [HttpPost("actualizarsolicitud")]
    public void actualizar([FromBody] enteroletra request)
    {
        _service.Actualizar(request.id, request.estado);
        return;
    }
    
}
