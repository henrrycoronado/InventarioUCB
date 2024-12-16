using Microsoft.AspNetCore.Mvc;
using ServicesApp.Models.Services;
using ServicesApp.Models;
using InventarioUCB_SPA.DataBaseApp.Models;

namespace InventarioUCB_SPA.Controllers;

[ApiController]
[Route("[controller]")]
public class EquipoController : ControllerBase
{
    private readonly IEquipoService _service;
    public EquipoController(IEquipoService service)
    {
        _service = service;
    }

    [HttpPost("CrearEquipo")]
    public string CrearEquipo([FromBody] EquipoEntrada entrada)
    {
        return _service.RegistrarEquipo(entrada.equipo, entrada.IdAdministrador );
    }

    [HttpGet("VerDetalleEquipo/{IdEquipo}")]
    public Equipo? VerDetalle(int IdEquipo)
    {
        return _service.DetalleEquipo(IdEquipo);
    }

    [HttpPost("ActualizarEquipo")]
    public string Actualizar([FromBody] EquipoUpdate entrada )
    {
        return _service.ActualizarEquipo(entrada.equipo, entrada.IdAdministrador);
    }

    [HttpPost("EliminarEquipo")]
    public string Eliminar([FromBody] EquipoUpdate entrada )
    {
        return _service.EliminarEquipo(entrada.equipo.Id, entrada.IdAdministrador);
    }

    [HttpGet("VerEquipos")]
    public IEnumerable<Equipo> VerEquipos()
    {
        return _service.MostrarEquipos();
    }

    [HttpPost("CambiarEstadoEquipo")]
    public string CambiarEstado([FromBody] cambiarEstadoEntrada entrada )
    {
        return _service.cambiar_estado_equipo(entrada.IdElement1, entrada.IdElement2, entrada.Mantenimiento);
    }

    [HttpGet("VerComponentesEquipo/{CodigoComponente}")]
    public IEnumerable<Componentesaccesorio> VerComponentesEquipo(int IdEquipo)
    {
        return _service.VerComponentesAsociados(IdEquipo);
    }

    [HttpGet("VerComponentesDisponible")]
    public IEnumerable<Componentesaccesorio> VerComponentesDisponible()
    {
        return _service.VerComponentesNoAsociados();
    }

    [HttpPost("AsociarComponente")]
    public string Asociar([FromBody] Ids2 entrada )
    {
        return _service.AsociarComponenteEquipo(entrada.IdElement1, entrada.IdElement2, entrada.IdElement3);
    }

    [HttpPost("QuitarComponente")]
    public string Quitar([FromBody] Ids2 entrada )
    {
        return _service.EliminarComponenteEquipo(entrada.IdElement1, entrada.IdElement2, entrada.IdElement3);
    }
}
