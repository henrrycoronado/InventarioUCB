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
    public string AprobarSolicitud(int Idsolicitud, int IdAdmin)
    {
        var solicitud = _solicitud.GetById(Idsolicitud);
        if(solicitud == null){
            return "Solicitud no encontrada";
        }
        if(solicitud.Estado == "Pendiente"){
            solicitud.Estado = "Aprobado_Fase1";
        }else if(solicitud.Estado == "Aprobado_Fase1"){
            solicitud.Estado = "Aprobado_Fase2";
        }
        if(_solicitud.Update(solicitud, solicitud.Id)){
            return "Solicitud Aprobada";
        };
        ;
        return "Solicitud no modificada, error en la DB";
    }

    public string RechazarSolicitud(int Idsolicitud, int IdAdmin)
    {
        var solicitud = _solicitud.GetById(Idsolicitud);
        if(solicitud == null){
            return "Solicitud no encontrada";
        }
        solicitud.Estado = "Rechazada";
        if(_solicitud.Update(solicitud, solicitud.Id)){
            return "Solicitud Rechazada con exito";
        }
        return "Solicitud no modificada, error en la DB";
    }
}