using InventarioUCB_SPA.DataBaseApp.Models.Services;
using ServicesApp.Models;
namespace ServicesApp.Models.Services;
public class SolicitudPrestamoService : ISolicitudPrestamoService
{
    public bool EnviarSolicitudPrestamo(SolicitudPrestamoModel soli)
    {
        return true;
    }
    public bool ValidarSolicitud()
    {
        return true;
    }
    public List<SolicitudPrestamoModel> mostrarSolicitudesPrestamo()
    {
        return new List<SolicitudPrestamoModel>();
    }
    public SolicitudPrestamoModel DetalleSolicitudPrestamo(int IdSolicitud)
    {
        return new SolicitudPrestamoModel();
    }

    public List<SolicitudPrestamoModel> HistorialSolicitudPrestamo(int IdUsuario)
    {
        return new List<SolicitudPrestamoModel>();
    }

}