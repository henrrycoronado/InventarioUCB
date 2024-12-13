using InventarioUCB_SPA.DataBaseApp.Models.Services;
using ServicesApp.Models;
public interface IEquipoService
{
    bool RegistrarEquipo(EquipoModel equipo);
    EquipoModel DetalleEquipo(int idEquipo);
    bool ActualizarEquipo(int idEquipo);
    bool EliminarEquipo(int idEquipo);
    List<EquipoModel> MostrarEquipos();
}