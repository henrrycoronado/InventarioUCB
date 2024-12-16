using System.ComponentModel;
using InventarioUCB_SPA.DataBaseApp.Models;
using InventarioUCB_SPA.DataBaseApp.Models.Services;
using ServicesApp.Models;
public interface IEquipoService
{
    string RegistrarEquipo(EquipoModelNuevo equipo, int IdAdmin);
    Equipo? DetalleEquipo(int IdEquipo);
    string ActualizarEquipo(Equipo equipo, int IdAdmin);
    string EliminarEquipo(int IdEquipo, int IdAdmin);
    string cambiar_estado_equipo(int IdEquipo, int IdAdmin, bool mantenimiento = false);
    List<Equipo> MostrarEquipos();
    List<Componentesaccesorio> VerComponentesAsociados(int IdEquipo);
    List<Componentesaccesorio> VerComponentesNoAsociados();
    string AsociarComponenteEquipo(int IdComponente, int IdEquipo, int IdAdmin);
    string EliminarComponenteEquipo(int IdComponente, int IdEquipo, int IdAdmin);
}