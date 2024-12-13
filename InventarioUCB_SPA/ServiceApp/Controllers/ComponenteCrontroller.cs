using Microsoft.AspNetCore.Mvc;
using ServicesApp.Models.Services;
using ServicesApp.Models;

namespace InventarioUCB_SPA.Controllers;

[ApiController]
[Route("[controller]")]
public class ComponenteController : ControllerBase
{
    private readonly IComponentService _service;
    public ComponenteController(IComponentService service)
    {
        _service = service;
    }

    [HttpPost("CrearEquipo")]
    public string CrearEquipo([FromBody] ComponenteEntrada entrada)
    {
        return _service.RegistrarComponente(entrada.componente, entrada.IdAdministrador );
    }

    [HttpGet("VerDetalleComponente/{CodigoComponente}")]
    public ComponenteModel VerDetalle(string CodigoComponente)
    {
        return _service.DetalleComponente(CodigoComponente);
    }

    [HttpPost("ActualizarComponente")]
    public string Actualizar([FromBody] ComponenteUpdate entrada )
    {
        return _service.ActualizarComponente(entrada.componente, entrada.IdAdministrador);
    }

    [HttpPost("EliminarComponente")]
    public string Eliminar([FromBody] ComponenteDelete entrada )
    {
        return _service.EliminarComponente(entrada.CodigoComponente, entrada.IdAdministrador);
    }

    [HttpGet("VerComponentes/{estado}")]
    public IEnumerable<ComponenteModel> VerEquipos(string estado)
    {
        return _service.MostrarComponentes(estado);
    }

    [HttpPost("CambiarEstadoComponentes")]
    public string CambiarEstado([FromBody] cambiarEstadoEntrada entrada )
    {
        return _service.cambiar_estado_componente(entrada.Codigoelemento, entrada.IdAdministrador, entrada.Mantenimiento);
    }
}
