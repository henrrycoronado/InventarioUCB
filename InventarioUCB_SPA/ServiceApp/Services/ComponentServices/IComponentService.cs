using InventarioUCB_SPA.DataBaseApp.Models.Services;
using ServicesApp.Models;
public interface IComponentService
{
    bool RegistrarComponente(ComponenteModel componente);
    ComponenteModel DetalleComponente(int idComponente);
    bool ActualizarComponente(int idComponente);
    bool EliminarComponente(int idComponente);
    bool CambiarComponenteEquipo(int idComponente, int idEquipo);
    List<ComponenteModel> MostrarComponentes();
}