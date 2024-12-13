using InventarioUCB_SPA.DataBaseApp.Models.Services;
using ServicesApp.Models;
namespace ServicesApp.Models.Services;
public class EquipoService : IEquipoService
{
    public bool RegistrarEquipo(EquipoModel equipo)
    {
        
        return true;
    }

    public EquipoModel DetalleEquipo(int id)
    {
        return new EquipoModel();
    }
    public bool ActualizarEquipo(int id)
    {
        return true;
    }

    public bool EliminarEquipo(int id)
    {
        return true;
    }

    public List<EquipoModel> MostrarEquipos()
    {
        return new List<EquipoModel>();
    }

    public bool cambiar_estado_equipo(int idEquipo)
    {
        return true;
    }

    /*
    public List<Equipo> EquiposRegistrados = new List<Equipo>
    {
        new Equipo
        {
            Id_equipo = 1,
            Codigo_Equipo = "1234",
            Nombre_equipo = "PC1",
            Estado_Equipo = "Disponible",
            Detalle_equipo = "nada"
        },
        new Equipo
        {
            Id_equipo = 2,
            Codigo_Equipo = "2345",
            Nombre_equipo = "PC1",
            Estado_Equipo = "Estropeado",
            Detalle_equipo = "dañado"
        },
        new Equipo
        {
            Id_equipo = 3,
            Codigo_Equipo = "3456",
            Nombre_equipo = "Data1",
            Estado_Equipo = "Disponible",
            Detalle_equipo = "algo rayado"
        },
    };
    */
}