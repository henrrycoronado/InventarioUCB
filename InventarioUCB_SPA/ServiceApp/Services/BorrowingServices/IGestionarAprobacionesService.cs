using InventarioUCB_SPA.DataBaseApp.Models.Services;
using ServicesApp.Models;
namespace ServicesApp.Models.Services;
public interface IGestionarAprobacionesService
{

    public bool AprobarSolicitud(int Idsolicitud, int IdAdmin);
    public bool RechazarSolicitud(int Idsolicitud, int IdAdmin);

}