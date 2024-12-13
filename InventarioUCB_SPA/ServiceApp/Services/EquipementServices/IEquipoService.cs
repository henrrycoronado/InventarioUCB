using System.ComponentModel;
using InventarioUCB_SPA.DataBaseApp.Models;
using InventarioUCB_SPA.DataBaseApp.Models.Services;
using ServicesApp.Models;
public interface IEquipoService
{
    string RegistrarEquipo(EquipoModelNuevo equipo, int IdAdmin);
    EquipoModel DetalleEquipo(string CodigoEquipo);
    string ActualizarEquipo(EquipoModel equipo, int IdAdmin);
    List<EquipoModel> MostrarEquipos(string estado);
    List<ComponenteModel> VerComponentesAsociados(string codigoEquipo);
    List<ComponenteModel> VerComponentesNoAsociados();
}