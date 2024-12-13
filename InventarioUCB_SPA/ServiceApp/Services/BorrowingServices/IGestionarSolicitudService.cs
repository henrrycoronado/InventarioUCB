using InventarioUCB_SPA.DataBaseApp.Models.Services;
using ServicesApp.Models;
public interface IGestionarSolicitudService
{
    public void AprobarSolicitud(int Idsolicitud);

    public void RechazarSolicitud(int Idsolicitud);
}