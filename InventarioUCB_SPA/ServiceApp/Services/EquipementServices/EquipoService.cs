using InventarioUCB_SPA.DataBaseApp.Models;
using InventarioUCB_SPA.DataBaseApp.Models.Services;
using ServicesApp.Models;
namespace ServicesApp.Models.Services;
public class EquipoService : IEquipoService
{
    private readonly EquipoRepository _equipo;
    private readonly ComponenteRepository _componente;
    private readonly ValidacionesService _validaciones;
    public EquipoService(EquipoRepository equipo, UsuarioRepository user, ValidacionesService validaciones, ComponenteRepository componente){
        _equipo = equipo;
        _validaciones = validaciones;
        _componente = componente;
    }
    public string RegistrarEquipo(EquipoModelNuevo equipo, int idAdmin)
    {
        if(equipo.CodigoUcb != null && _equipo.GetByCodigoUcb(equipo.CodigoUcb) != null){
            return "CodigoUCB ya existente";
        }else if(equipo.NumeroSerie != null && _equipo.GetByNumeroSerie(equipo.NumeroSerie) != null){
            return "Numero de serie ya existente";
        }
        if(!_validaciones.AdminValido(idAdmin)){
            return "Creador no identificado";
        }
        var EquipoNuevo = new Equipo{
            CodigoEquipo = equipo.CodigoEquipo,
            CodigoUcb = equipo.CodigoUcb,
            NumeroSerie = equipo.NumeroSerie,
            Fabricante = equipo.Fabricante,
            DireccionEnlace = equipo.DireccionEnlace,
            Nombre = equipo.Nombre,
            Descripcion = equipo.Descripcion,
            IdCategoria = equipo.IdCategoria,
            Ubicacion = equipo.Ubicacion,
            EstadoEquipo = equipo.EstadoEquipo,
            Estado = "Disponible"
        };
        if(_equipo.Add(EquipoNuevo)){
            return "Creacion de equipo exitosa";
        }
        return "Solicitud no aceptada, revise su entrada por favor";
    }
    
    public Equipo? DetalleEquipo(int IdEquipo)
    {
        var equipo = _equipo.GetById(IdEquipo);
        if(equipo != null){
            return equipo;
        }
        return null;
    }
    public string ActualizarEquipo(Equipo equipo, int IdAdmin)
    {
        var exist = _equipo.GetById(equipo.Id);
        if(exist == null){
            return "Equipo no reconocido, codigo de equipo inexistente";
        }
        exist.Nombre = equipo.Nombre;
        exist.Descripcion = equipo.Descripcion;
        exist.Fabricante = equipo.Fabricante;
        exist.DireccionEnlace = equipo.DireccionEnlace;
        exist.EstadoEquipo = equipo.EstadoEquipo;
        exist.IdCategoria = equipo.IdCategoria;
        exist.Ubicacion = equipo.Ubicacion;
        exist.Estado = equipo.Estado;
        _equipo.Update(exist, exist.Id);
        return "Revisar Cambios";
    }

    public string EliminarEquipo(int IdEquipo, int IdAdmin)
    {
        var exist = _equipo.GetById(IdEquipo);
        if(exist == null){
            return "Equipo no reconocido, ID de equipo inexistente";
        }
        exist.Estado = "Eliminado";
        if(_equipo.Update(exist, exist.Id)){
            return "Eliminacion completada";
        }
        return "Eliminacion no completada, error en la DB";
    }

    public List<Equipo> MostrarEquipos()
    {
        string estado = "Disponible";
        var result = _equipo.GetByState(estado);
        return result;
    }

    public string cambiar_estado_equipo(int IdEquipo, int IdAdmin, bool mantenimiento = false)
    {
        var exist = _equipo.GetById(IdEquipo);
        if(exist == null){
            return "Equipo no reconocido, ID de equipo inexistente";
        }

        if(mantenimiento){
            exist.Estado = "Mantenimiento";
        }else{
            if(exist.Estado == "Disponible"){
                exist.Estado = "Ocupado";
            }else{
                exist.Estado = "Disponible";
            }
        }
        if(_equipo.Update(exist, exist.Id)){
            return "Estado cambiado con exito";
        }
        return "Cambios No completados, error en la DB";
    }
    public List<Componentesaccesorio> VerComponentesAsociados(int IdEquipo){
        var result = _equipo.ConeccionesEquipo(IdEquipo);
        return result;
    }
    public List<Componentesaccesorio> VerComponentesNoAsociados(){
        var result = _equipo.ComponentesSinConecciones();
        return result;
    }

    public string AsociarComponenteEquipo(int IdComponente, int IdEquipo, int IdAdmin)
    {
        var componente = _componente.GetById(IdComponente);
        var equipo = _equipo.GetById(IdEquipo);
        if(componente == null || equipo == null){
            return "Coneccion no posible, revise los elementos a asociar";
        }
        if(_equipo.ConeccionActiva(componente.Id, equipo.Id) != null){
            return "Coneccion ya existente";
        }else if(_equipo.ConeccionConOtro(componente.Id, equipo.Id) != null){
            return "Componente asociado con otro equipo, elimine primero";
        }
        else if(_equipo.ExistioConeccion(componente.Id, equipo.Id) != null){
            var coneccion = _equipo.ExistioConeccion(componente.Id, equipo.Id);
            if(coneccion != null){
                coneccion.Estado = "Asociado";
                if(_equipo.UpdateConeccion(coneccion.Id, coneccion)){
                    return "revisar cambio, se actualizo la asociacion del componente";
                }
            }
            return "No se puede restaurar coneccion previa";
        }
        else{
            var coneccion = new EquipoComponente{
                IdComponente = componente.Id,
                IdEquipo = equipo.Id,
                Estado = "Asociado"
            };
            if(_equipo.AddComponenteEquipo(coneccion)){
                return "Coneccion Realizada, revisar el cambio";
            }
            
            return "Coneccion no Realizada, error en la DB";
        }
    }
    public string EliminarComponenteEquipo(int IdComponente, int IdEquipo, int IdAdmin)
    {
        var componente = _componente.GetById(IdComponente);
        var equipo = _equipo.GetById(IdEquipo);
        if(componente == null || equipo == null){
            return "Eliminacion no posible, revise los elementos a Eliminar";
        }
        if(_equipo.ConeccionActiva(componente.Id, equipo.Id) == null){
            return "Coneccion no existente o ya eliminada";
        }
        else{
            var coneccion = _equipo.ConeccionActiva(componente.Id, equipo.Id);
            if(coneccion != null){
            coneccion.Estado = "Eliminado";
                if(_equipo.UpdateConeccion(coneccion.Id ,coneccion)){
                    return "Coneccion Eliminada, revisar el cambio";
                };
            }
            return "Coneccion no Eliminada, error en la DB";
        }
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