using Microsoft.AspNetCore.Mvc;
using ServicesApp.Models.Services;
using ServicesApp.Models;

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

    [HttpGet("VerDetalleEquipo/{CodigoEquipo}")]
    public EquipoModel VerDetalle(string CodigoEquipo)
    {
        return _service.DetalleEquipo(CodigoEquipo);
    }

    [HttpPost("ActualizarEquipo")]
    public string Actualizar([FromBody] EquipoEntradaUpdate entrada )
    {
        return _service.ActualizarEquipo(entrada.equipo, entrada.IdAdministrador);
    }

    [HttpPost("EliminarEquipo")]
    public string Eliminar([FromBody] EquipoEntradaDelete entrada )
    {
        return _service.EliminarEquipo(entrada.Codigoequipo, entrada.IdAdministrador);
    }

    [HttpGet("VerEquipos")]
    public IEnumerable<EquipoModel> VerEquipos()
    {
        return _service.MostrarEquipos();
    }

    [HttpPost("CambiarEstadoEquipo")]
    public string CambiarEstado([FromBody] cambiarEstadoEntrada entrada )
    {
        return _service.cambiar_estado_equipo(entrada.Codigoelemento, entrada.IdAdministrador, entrada.Mantenimiento);
    }

    [HttpGet("VerComponentesEquipo/{CodigoComponente}")]
    public IEnumerable<ComponenteModel> VerComponentesEquipo(string CodigoComponente)
    {
        return _service.VerComponentesAsociados(CodigoComponente);
    }

    [HttpGet("VerComponentesDisponible")]
    public IEnumerable<ComponenteModel> VerComponentesDisponible()
    {
        return _service.VerComponentesNoAsociados();
    }

    [HttpPost("AsociarComponente")]
    public string Asociar([FromBody] Identificadores entrada )
    {
        return _service.AsociarComponenteEquipo(entrada.Codigocomponente, entrada.Codigoequipo, entrada.IdAdministrador);
    }

    [HttpPost("QuitarComponente")]
    public string Quitar([FromBody] Identificadores entrada )
    {
        return _service.EliminarComponenteEquipo(entrada.Codigocomponente, entrada.Codigoequipo, entrada.IdAdministrador);
    }
}
