using InventarioUCB_SPA.DataBaseApp.Models.Services;
using ServicesApp.Models;
public interface ISolicitudPrestamoService
{
    bool EnviarSolicitudPrestamo(SolicitudPrestamoModel soli);
    bool ValidarSolicitud();
    List<SolicitudPrestamoModel> mostrarSolicitudesPrestamo();
    SolicitudPrestamoModel DetalleSolicitudPrestamo(int IdSolicitud);
    List<SolicitudPrestamoModel> HistorialSolicitudPrestamo(int idUsuario);
}