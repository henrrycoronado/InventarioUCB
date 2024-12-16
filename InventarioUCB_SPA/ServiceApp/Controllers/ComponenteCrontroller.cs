using Microsoft.AspNetCore.Mvc;
using ServicesApp.Models.Services;
using ServicesApp.Models;
using InventarioUCB_SPA.DataBaseApp.Models;

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
    public Componentesaccesorio? VerDetalle(int IdComponente)
    {
        return _service.DetalleComponente(IdComponente);
    }

    [HttpPost("ActualizarComponente")]
    public string Actualizar([FromBody] ComponenteUpdate entrada )
    {
        return _service.ActualizarComponente(entrada.componente, entrada.IdAdministrador);
    }

    [HttpPost("EliminarComponente")]
    public string Eliminar([FromBody] ComponenteUpdate entrada )
    {
        return _service.EliminarComponente(entrada.componente.Id, entrada.IdAdministrador);
    }

    [HttpGet("VerComponentes/{estado}")]
    public IEnumerable<Componentesaccesorio> VerEquipos(string estado)
    {
        return _service.MostrarComponentes(estado);
    }

    [HttpPost("CambiarEstadoComponentes")]
    public string CambiarEstado([FromBody] cambiarEstadoEntrada entrada )
    {
        return _service.cambiar_estado_componente(entrada.IdElement1, entrada.IdElement2);
    }
}
