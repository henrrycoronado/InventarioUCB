using InventarioUCB_SPA.DataBaseApp.Models;
using InventarioUCB_SPA.DataBaseApp.Models.Services;
using ServicesApp.Models;
namespace ServicesApp.Models.Services;
public class SolicitudPrestamoService : ISolicitudPrestamoService
{
    private readonly SolicitudPrestamoRepository _solicitud;
    private readonly DetalleSolicitudPrestamoRepository _detalle;
    private readonly ValidacionesService _validaciones;
    public SolicitudPrestamoService(SolicitudPrestamoRepository solicitud, DetalleSolicitudPrestamoRepository detalle, ValidacionesService validaciones){
        _solicitud = solicitud;
        _validaciones = validaciones;
        _detalle = detalle;
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
            _solicitud.Add(solicitud);
            return true;
        }
        return false;
    }
    
    public List<SolicitudPrestamoModel> mostrarSolicitudesPrestamo()
    {
        var result = _solicitud.GetPendingRequests();
        var lista = new List<SolicitudPrestamoModel>();
        foreach (var soli in result)
        {
            lista.Add(_validaciones.convertirSolicitudModel(soli));
        }
        return new List<SolicitudPrestamoModel>();
    }
    public List<Detallessolicitudprestamo> DetalleSolicitudPrestamo(int IdSolicitud)
    {
        var result = _detalle.GetBySolicitudId(IdSolicitud);

        return result;
    }
    public SolicitudPrestamoModel VerSolicitud(int IdSolicitud){
        var result = _solicitud.GetById(IdSolicitud);
        if(result == null){
            return new SolicitudPrestamoModel();
        }
        return _validaciones.convertirSolicitudModel(result);
    }

    public List<SolicitudPrestamoModel> HistorialSolicitudPrestamo(int IdUsuario)
    {
        var result = _solicitud.GetByIdUser(IdUsuario);
        var lista = new List<SolicitudPrestamoModel>();
        foreach (var soli in result)
        {
            lista.Add(_validaciones.convertirSolicitudModel(soli));
        }
        return lista;
    }

}