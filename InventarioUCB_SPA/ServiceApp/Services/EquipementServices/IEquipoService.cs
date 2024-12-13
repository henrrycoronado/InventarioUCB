using System.ComponentModel;
using InventarioUCB_SPA.DataBaseApp.Models;
using InventarioUCB_SPA.DataBaseApp.Models.Services;
using ServicesApp.Models;
public interface IEquipoService
{
    string RegistrarEquipo(EquipoModelNuevo equipo, int IdAdmin);
    EquipoModel DetalleEquipo(string CodigoEquipo);
    string ActualizarEquipo(EquipoModel equipo, int IdAdmin);
    string EliminarEquipo(string CodigoEquipo, int IdAdmin);
    string cambiar_estado_equipo(string CodigoEquipo, int IdAdmin, bool mantenimiento = false);
    List<EquipoModel> MostrarEquipos(string estado);
    List<ComponenteModel> VerComponentesAsociados(string codigoEquipo);
    List<ComponenteModel> VerComponentesNoAsociados();
    string AsociarComponenteEquipo(string CodigoComponente, string CodigoEquipo, int IdAdmin);
    string EliminarComponenteEquipo(string CodigoComponente, string CodigoEquipo, int IdAdmin);
}