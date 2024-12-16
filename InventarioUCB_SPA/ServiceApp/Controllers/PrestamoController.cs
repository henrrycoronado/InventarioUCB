using Microsoft.AspNetCore.Mvc;
using ServicesApp.Models.Services;
using ServicesApp.Models;
using InventarioUCB_SPA.DataBaseApp.Models;

namespace InventarioUCB_SPA.Controllers;

[ApiController]
[Route("[controller]")]
public class PrestamoController : ControllerBase
{
    private readonly IPrestamoService _servicePrestamo;
    private readonly ISolicitudPrestamoService _serviceSoli;
    public PrestamoController(IPrestamoService servicePrestamo, ISolicitudPrestamoService serviceSoli)
    {
        _servicePrestamo = servicePrestamo;
        _serviceSoli = serviceSoli;
    }

    [HttpGet("DetallePrestamo/{idPrestamo}")]
    public (Prestamo?, Solicitudesprestamo?) DetallePrestamo(int idPrestamo)
    {
        var prestamo = _servicePrestamo.DetallePrestamo(idPrestamo);
        if(prestamo == null){
            return (null, null);
        }
        var soli = _serviceSoli.VerSolicitud(prestamo.Id);
        return (prestamo, soli);
    }

    [HttpGet("HistorialPrestamo/{idUser}")]
    public List<Prestamo> HisrorialPrestamo(int idUser)
    {
        return _servicePrestamo.HistorialPrestamo(idUser);
    }

    [HttpGet("DevolverPrestamo/{idPrestamo}")]
    public string Devolucion(int idPrestamo)
    {
        return _servicePrestamo.DevolverPrestamo(idPrestamo);
    }
}
