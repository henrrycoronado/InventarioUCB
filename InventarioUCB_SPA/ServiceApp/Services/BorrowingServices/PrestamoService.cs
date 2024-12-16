using InventarioUCB_SPA.DataBaseApp.Models;
using InventarioUCB_SPA.DataBaseApp.Models.Services;
using ServicesApp.Models;
namespace ServicesApp.Models.Services;
public class PrestamoService : IPrestamoService
{
    private readonly PrestamoRepository _prestamo;
    private readonly ValidacionesService _validaciones;
    public PrestamoService(PrestamoRepository prestamo, ValidacionesService validaciones){
        _prestamo = prestamo;
        _validaciones = validaciones;
    }
    public bool CrearPrestamo(Solicitudesprestamo solicitud) 
    {
        var prestamoNuevo = new Prestamo{
            IdSolicitudPrestamo = solicitud.Id,
            FechaDevolucion = solicitud.FechaFinPrestamo,
            Estado = "Activo"
        };
        if(_prestamo.Add(prestamoNuevo)){
            return true;
        }
        return false;
    }
    public Prestamo? DetallePrestamo(int idPrestamo)
    {
        var prestamo = _prestamo.GetById(idPrestamo);
        if (prestamo == null)
            return null;
        return prestamo;
    }
    public List<Prestamo> HistorialPrestamo(int idUsuario)
    {
        var result = _prestamo.Historial(idUsuario);
        return result;
    }
    public string DevolverPrestamo(int IdPrestamo)
    {
        var prestamo = _prestamo.GetById(IdPrestamo);
        if (prestamo == null){
            return "prestamo no existe";
        }
        if(prestamo.FechaDevolucion > DateOnly.FromDateTime(DateTime.Now)){
            prestamo.Estado = "Retrasado";
        }
        else{
            prestamo.Estado = "Devuelto";
        }

        if(_prestamo.Update(prestamo, prestamo.Id)){
            return "Devolucion Exitosa";
        }
        return "Devolucion no completada, error en la DB";
    }
}