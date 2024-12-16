using InventarioUCB_SPA.DataBaseApp.Models;
using InventarioUCB_SPA.DataBaseApp.Models.Services;
using ServicesApp.Models;
namespace ServicesApp.Models.Services;
public class SolicitudPrestamoService : ISolicitudPrestamoService
{
    private readonly SolicitudPrestamoRepository _solicitud;
    private readonly DetalleSolicitudPrestamoRepository _detalle;
    private readonly EquipoRepository _equipo;
    private readonly ValidacionesService _validaciones;
    public SolicitudPrestamoService(SolicitudPrestamoRepository solicitud, DetalleSolicitudPrestamoRepository detalle, EquipoRepository equipo, ValidacionesService validaciones){
        _solicitud = solicitud;
        _validaciones = validaciones;
        _detalle = detalle;
        _equipo = equipo;
    }
    public bool EnviarSolicitudPrestamo(SolicitudPrestamoModel soli)
    {
        if(_validaciones.ValidarSolicitud(soli)){
            var solicitud = new Solicitudesprestamo{
                IdUsuario = soli.IdUsuario,
                FechaInicioPrestamo = soli.FechaInicioPrestamo,
                FechaFinPrestamo = soli.FechaFinPrestamo,
                FechaSolicitud = soli.FechaSolicitud,
                Estado = "Pendiente"
            };
            if(_solicitud.Add(solicitud)){
                return true;
            }
        }
        return false;
    }
    
    public List<Solicitudesprestamo> mostrarSolicitudesPrestamo()
    {
        var result = _solicitud.GetPendingRequests();
        return result;
    }

    public List<Solicitudesprestamo> mostrarSolicitudesAceptadas()
    {
        var result = _solicitud.GetReviewRequests();
        return result;
    }
    
    public List<Detallessolicitudprestamo> DetalleSolicitudPrestamo(int IdSolicitud)
    {
        var result = _detalle.GetBySolicitudId(IdSolicitud);
        return result;
    }
    public Solicitudesprestamo? VerSolicitud(int IdSolicitud){
        var result = _solicitud.GetById(IdSolicitud);
        if(result != null){
            return result;
        }
        return null;
    }

    public List<Solicitudesprestamo> HistorialSolicitudPrestamo(int IdUsuario)
    {
        var result = _solicitud.GetByIdUser(IdUsuario);
        return result;
    }
    public string AddDetalle(int idSolicitud, int IdEquipo){
        var solicitud = _solicitud.GetById(idSolicitud);
        var equipo = _equipo.GetById(IdEquipo);
        if(solicitud == null || equipo == null){
            return "agrgacion de detalle no posible, revise los elementos a asociar";
        }
        if(_detalle.ConeccionActiva(solicitud.Id, equipo.Id) != null){
            return "Coneccion ya existente";
        }else if(_detalle.ExistioConeccion(solicitud.Id, equipo.Id) != null){
            var detalle = _detalle.ExistioConeccion(solicitud.Id, equipo.Id);
            if(detalle != null){
                if(_detalle.ChangeStateDetalleSolicitud(detalle.Id)){
                    return "revisar cambio, se actualizo el detalle de la solicitud";
                }
            }
            return "No se puede restaurar el detalle previo";
        }
        else{
            var detalle = new Detallessolicitudprestamo{
                IdSolicitudPrestamo = solicitud.Id,
                IdEquipo = equipo.Id,
                Estado = "Seleccionado"
            };
            if(_detalle.Add(detalle)){
                return "detalle añadido, revisar el cambio";
            }
            
            return "detalle no añadido, error en la DB";
        }
    }
    public string RemoveDetalle(int IdSolicitud, int IdEquipo){
        var solicitud = _solicitud.GetById(IdSolicitud);
        var equipo = _equipo.GetById(IdEquipo);
        if(solicitud == null || equipo == null){
            return "Eliminacion no posible, revise los elementos a Eliminar";
        }
        if(_detalle.ConeccionActiva(solicitud.Id, equipo.Id) == null){
            return "Coneccion no existente o ya eliminada";
        }
        else{
            var detalle = _detalle.ConeccionActiva(solicitud.Id, equipo.Id);
            if(detalle != null){
            detalle.Estado = "Eliminado";
                if(_detalle.ChangeStateDetalleSolicitud(detalle.Id)){
                    return "detalle Eliminada, revisar el cambio";
                };
            }
            return "detalle no Eliminada, error en la DB";
        }
    }
}