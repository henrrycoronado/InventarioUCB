using InventarioUCB_SPA.DataBaseApp.Models.Services;
using InventarioUCB_SPA.DataBaseApp.Models;
using ServicesApp.Models;
public interface IPrestamoService
{
    bool CrearPrestamo(Solicitudesprestamo prestamo);
    Prestamo? DetallePrestamo(int idPrestamo);
    List<Prestamo> HistorialPrestamo(int IdUsuario);
    string DevolverPrestamo(int IdPrestamo);
}