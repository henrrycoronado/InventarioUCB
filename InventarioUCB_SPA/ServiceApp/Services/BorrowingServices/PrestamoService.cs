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
    public string CrearPrestamo(Solicitudesprestamo solicitud) 
    {
        var prestamoNuevo = new Prestamo{
            IdSolicitudPrestamo = solicitud.Id,
            FechaDevolucion = solicitud.FechaFinPrestamo,
            Estado = "Activo"
        };
        _prestamo.Add(prestamoNuevo);
        return "Prestamo Creado";
    }
    public PrestamoModel DetallePrestamo(int idPrestamo)
    {
        var prestamoModel = _prestamo.GetById(idPrestamo);
        if (prestamoModel == null)
            return new PrestamoModel();
        return _validaciones.convertirPrestamoModel(prestamoModel);
    }
    public List<PrestamoModel> HistorialPrestamo(int idUsuario)
    {
        var result = _prestamo.Historial(idUsuario);
        var lista = new List<PrestamoModel>();
        foreach (var prest in result)
        {
            lista.Add(_validaciones.convertirPrestamoModel(prest));
        }
        return lista;
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
        _prestamo.Update(prestamo, prestamo.Id);
        return "Devolucion Exitosa";
    }
}