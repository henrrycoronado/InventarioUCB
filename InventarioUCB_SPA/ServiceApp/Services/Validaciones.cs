using InventarioUCB_SPA.DataBaseApp.Models.Services;
using InventarioUCB_SPA.DataBaseApp.Models;
using ServicesApp.Models;
namespace ServicesApp.Models.Services;
public class ValidacionesService
{
    private readonly UsuarioRepository _user;
    public ValidacionesService(UsuarioRepository user){
        _user = user;
    }
    public bool AdminValido(int IdAdmin){
        var admin = _user.GetById(IdAdmin);
        if(admin == null || (admin.Rol != "Root" && admin.Rol != "Administrativo")){
            return false;
        }
        return true;
    }
    public SolicitudPrestamoModel convertirSolicitudModel(Solicitudesprestamo solicitud){
        if(solicitud == null){
            return new SolicitudPrestamoModel();
        }
        var modelo = new SolicitudPrestamoModel{
            IdUsuario = solicitud.IdUsuario,
            FechaInicioPrestamo = solicitud.FechaInicioPrestamo,
            FechaFinPrestamo = solicitud.FechaFinPrestamo,
            FechaSolicitud = solicitud.FechaSolicitud,
            Estado = solicitud.Estado
        };
        return modelo;
    }    


    public bool ValidarSolicitud(SolicitudPrestamoModel soli)
    {
        return true;
    }
}