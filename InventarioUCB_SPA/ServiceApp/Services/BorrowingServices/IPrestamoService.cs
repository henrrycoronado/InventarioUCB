using InventarioUCB_SPA.DataBaseApp.Models.Services;
using ServicesApp.Models;
public interface IPrestamoService
{
    bool CrearPrestamo(PrestamoModel prestamo);
    PrestamoModel DetallePrestamo(int idPrestamo);
    List<PrestamoModel> HistorialPrestamo(int IdUsuario);
    bool DevolverPrestamo(int IdPrestamo);
}