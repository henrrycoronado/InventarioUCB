using InventarioUCB_SPA.DataBaseApp.Models.Services;
using ServicesApp.Models;
namespace ServicesApp.Models.Services;
public class GestionarAprobacionesService : IGestionarAprobacionesService
{
    private readonly SolicitudPrestamoRepository _solicitud;
    private readonly IPrestamoService _prestamoService;
    public GestionarAprobacionesService(SolicitudPrestamoRepository solicitud, PrestamoRepository prestamo, IPrestamoService prestamoService){
        _solicitud = solicitud;
        _prestamoService = prestamoService;
    }
    public bool AprobarSolicitud(int Idsolicitud, int IdAdmin)
    {
        var solicitud = _solicitud.GetById(Idsolicitud);
        if(solicitud == null){
            Console.WriteLine("Solicitud no encontrada");
            return false;
        }
        solicitud.Estado = "Aprobada";
        if(_solicitud.Update(solicitud, solicitud.Id) && _prestamoService.CrearPrestamo(solicitud)){
            Console.WriteLine( "Solicitud Aprobada");
            return true;
        };
        ;
        Console.WriteLine("Solicitud no modificada, error en la DB");
        return false;
    }

    public bool RechazarSolicitud(int Idsolicitud, int IdAdmin)
    {
        var solicitud = _solicitud.GetById(Idsolicitud);
        if(solicitud == null){
            Console.WriteLine("Solicitud no encontrada");
            return false;
        }
        solicitud.Estado = "Pendiente";
        if(_solicitud.Update(solicitud, solicitud.Id)){
            Console.WriteLine( "Solicitud no Aprobada");
            return true;
        }
        Console.WriteLine("Solicitud no modificada, error en la DB");
        return false;
    }
}