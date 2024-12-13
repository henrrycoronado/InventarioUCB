using InventarioUCB_SPA.DataBaseApp.Models.Services;
using ServicesApp.Models;
public interface IGestionarSolicitudService
{
    public string AprobarSolicitud(int Idsolicitud, int IdAdmin);

    public string RechazarSolicitud(int Idsolicitud, int IdAdmin);
}