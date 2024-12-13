using InventarioUCB_SPA.DataBaseApp.Models.Services;
using ServicesApp.Models;
namespace ServicesApp.Models.Services;
public class PrestamoService : IPrestamoService
{
    public bool CrearPrestamo(PrestamoModel prestamo)
    {
        return true;
    }
    public PrestamoModel DetallePrestamo(int idPrestamo)
    {
        return new PrestamoModel();
    }
    public List<PrestamoModel> HistorialPrestamo(int idUsuario)
    {
        return new List<PrestamoModel>();
    }
    public bool DevolverPrestamo(int Prestamo)
    {
        return true;
    }
}