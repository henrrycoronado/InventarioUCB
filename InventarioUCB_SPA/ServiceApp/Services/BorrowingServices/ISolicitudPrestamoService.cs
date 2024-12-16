using InventarioUCB_SPA.DataBaseApp.Models.Services;
using InventarioUCB_SPA.DataBaseApp.Models;
using ServicesApp.Models;
public interface ISolicitudPrestamoService
{
    bool EnviarSolicitudPrestamo(SolicitudPrestamoModel soli);
    List<Solicitudesprestamo> mostrarSolicitudesPrestamo();
    List<Solicitudesprestamo> mostrarSolicitudesAceptadas();
    public List<Detallessolicitudprestamo> DetalleSolicitudPrestamo(int IdSolicitud);
    Solicitudesprestamo? VerSolicitud(int IdSolicitud);
    List<Solicitudesprestamo> HistorialSolicitudPrestamo(int IdUsuario);
    string AddDetalle(int idSolicitud, int IdEquipo);
    string RemoveDetalle(int IdSolicitud, int IdEquipo);
}