using InventarioUCB_SPA.DataBaseApp.Models.Services;
using ServicesApp.Models;
namespace ServicesApp.Models.Services;
public class ComponenteService: IComponentService
{
    public bool RegistrarComponente(ComponenteModel componente)
    {
        return true;
    }
    public ComponenteModel DetalleComponente(int idComponente)
    {
        return new ComponenteModel();
    }
    public bool ActualizarComponente(int idComponente)
    {
        return true;
    }
    public bool EliminarComponente(int id)
    {
        return true;
    }
    public bool CambiarComponenteEquipo(int idComponente, int idEquipo)
    {
        return true;
    }
    public List<ComponenteModel> MostrarComponentes()
    {
        return new List<ComponenteModel>();
    }
}