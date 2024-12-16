using InventarioUCB_SPA.DataBaseApp.Models.Services;
using ServicesApp.Models;
namespace ServicesApp.Models.Services;
public class GestionarSolicitudService : IGestionarSolicitudService
{
    private readonly SolicitudPrestamoRepository _solicitud;
    private readonly IPrestamoService _prestamoService;
    public GestionarSolicitudService(SolicitudPrestamoRepository solicitud, PrestamoRepository prestamo, IPrestamoService prestamoService){
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
        solicitud.Estado = "En Revision";
        if(_solicitud.Update(solicitud, solicitud.Id)){
            Console.WriteLine( "Solicitud En Revision");
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
        solicitud.Estado = "Rechazada";
        if(_solicitud.Update(solicitud, solicitud.Id)){
            Console.WriteLine( "Solicitud Rechazada");
            return true;
        }
        Console.WriteLine("Solicitud no modificada, error en la DB");
        return false;
    }

}