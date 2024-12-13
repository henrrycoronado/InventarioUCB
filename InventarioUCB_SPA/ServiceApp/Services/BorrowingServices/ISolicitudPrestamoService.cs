using InventarioUCB_SPA.DataBaseApp.Models.Services;
using InventarioUCB_SPA.DataBaseApp.Models;
using ServicesApp.Models;
public interface ISolicitudPrestamoService
{
    bool EnviarSolicitudPrestamo(SolicitudPrestamoModel soli);
    List<SolicitudPrestamoModel> mostrarSolicitudesPrestamo();
    public List<Detallessolicitudprestamo> DetalleSolicitudPrestamo(int IdSolicitud);
    SolicitudPrestamoModel VerSolicitud(int IdSolicitud);
    List<SolicitudPrestamoModel> HistorialSolicitudPrestamo(int IdUsuario);
}