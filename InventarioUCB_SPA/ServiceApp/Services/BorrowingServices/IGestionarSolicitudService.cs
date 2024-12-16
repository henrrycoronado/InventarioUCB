using InventarioUCB_SPA.DataBaseApp.Models.Services;
using ServicesApp.Models;
public interface IGestionarSolicitudService
{
    public bool AprobarSolicitud(int Idsolicitud, int IdAdmin);

    public bool RechazarSolicitud(int Idsolicitud, int IdAdmin);
}