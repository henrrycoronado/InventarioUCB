using InventarioUCB_SPA.DataBaseApp.Models.Services;
using InventarioUCB_SPA.DataBaseApp.Models;
using ServicesApp.Models;
public interface IPrestamoService
{
    string CrearPrestamo(Solicitudesprestamo prestamo);
    PrestamoModel DetallePrestamo(int idPrestamo);
    List<PrestamoModel> HistorialPrestamo(int IdUsuario);
    string DevolverPrestamo(int IdPrestamo);
}