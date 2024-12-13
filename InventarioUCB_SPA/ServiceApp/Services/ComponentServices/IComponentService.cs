using InventarioUCB_SPA.DataBaseApp.Models.Services;
using ServicesApp.Models;
public interface IComponentService
{
    string RegistrarComponente(ComponenteModelNuevo componente, int IdAdmin);
    ComponenteModel DetalleComponente(string CodigoComponente);
    string ActualizarComponente(ComponenteModel componente, int IdAdmin);
    string EliminarComponente(string CodigoComponente, int IdAdmin);
    List<ComponenteModel> MostrarComponentes(string estado);
}