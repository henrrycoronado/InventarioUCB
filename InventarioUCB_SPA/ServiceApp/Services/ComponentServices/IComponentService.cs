using InventarioUCB_SPA.DataBaseApp.Models;
using InventarioUCB_SPA.DataBaseApp.Models.Services;
using ServicesApp.Models;
public interface IComponentService
{
    string RegistrarComponente(ComponenteModelNuevo componente, int IdAdmin);
    Componentesaccesorio? DetalleComponente(int IdComponente);
    string ActualizarComponente(Componentesaccesorio componente, int IdAdmin);
    string EliminarComponente(int IdComponente, int IdAdmin);
    string cambiar_estado_componente(int IdComponente, int IdAdmin, bool mantenimiento = false);
    List<Componentesaccesorio> MostrarComponentes(string estado);
}