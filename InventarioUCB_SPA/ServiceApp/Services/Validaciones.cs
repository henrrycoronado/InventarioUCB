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
    public EquipoModel convertirEquipoModel(Equipo equipo){
        if(equipo == null){
            return new EquipoModel();
        }
        var modelo = new EquipoModel{
            CodigoEquipo = equipo.CodigoEquipo,
            CodigoUcb = equipo.CodigoUcb,
            NumeroSerie = equipo.NumeroSerie,
            Fabricante = equipo.Fabricante,
            DireccionEnlace = equipo.DireccionEnlace,
            Nombre = equipo.Nombre,
            Descripcion = equipo.Descripcion,
            IdCategoria = equipo.IdCategoria,
            Ubicacion = equipo.Ubicacion,
            EstadoEquipo = equipo.EstadoEquipo,
            Estado = equipo.Estado
        };
        return modelo;
    }

    public ComponenteModel convertirComponenteModel(Componentesaccesorio componente){
        if(componente == null){
            return new ComponenteModel();
        }
        var modelo = new ComponenteModel{
            CodigoComponente = componente.CodigoComponente,
            CodigoUcb = componente.CodigoUcb,
            NumeroSerie = componente.NumeroSerie,
            Fabricante = componente.Fabricante,
            Nombre =  componente.Nombre,
            Descripcion = componente.Descripcion,
            IdCategoria = componente.IdCategoria,
            Ubicacion = componente.Ubicacion,
            EstadoComponente = componente.EstadoComponente,
            Estado = componente.Estado
        };
        return modelo;
    }
    public PrestamoModel convertirPrestamoModel(Prestamo prestamo){
        if(prestamo == null){
            return new PrestamoModel();
        }
        var modelo = new PrestamoModel{
            IdSolicitudPrestamo = prestamo.IdSolicitudPrestamo,
            FechaDevolucion = prestamo.FechaDevolucion,
            Estado = prestamo.Estado
        };
        return modelo;
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