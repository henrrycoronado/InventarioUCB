using InventarioUCB_SPA.DataBaseApp.Models;
using InventarioUCB_SPA.DataBaseApp.Models.Services;
using ServicesApp.Models;
namespace ServicesApp.Models.Services;
public class ComponenteService: IComponentService
{
    private readonly ComponenteRepository _componente;
    private readonly EquipoRepository _equipo;
    private readonly ValidacionesService _validaciones;
    public ComponenteService(ComponenteRepository componente, ValidacionesService validaciones, EquipoRepository equipo){
        _componente = componente;
        _validaciones = validaciones;
        _equipo = equipo;
    }
    public string RegistrarComponente(ComponenteModelNuevo componente, int idAdmin)
    {
        if(componente.CodigoUcb != null && _componente.GetByCodigoUcb(componente.CodigoUcb) != null){
            return "CodigoUCB ya existente";
        }else if(componente.NumeroSerie != null && _componente.GetByNumeroSerie(componente.NumeroSerie) != null){
            return "Numero de serie ya existente";
        }
        if(!_validaciones.AdminValido(idAdmin)){
            return "Creador no identificado";
        }
        var ComponenteNuevo = new Componentesaccesorio{
            CodigoComponente = componente.CodigoComponente,
            CodigoUcb = componente.CodigoUcb,
            NumeroSerie = componente.NumeroSerie,
            Fabricante = componente.Fabricante,
            Nombre = componente.Nombre,
            Descripcion = componente.Descripcion,
            IdCategoria = componente.IdCategoria,
            Ubicacion = componente.Ubicacion,
            EstadoComponente = componente.EstadoComponente,
            Estado = "Disponible"
        };
        if(_componente.Add(ComponenteNuevo)){
            return "Creacion de componente exitosa";
        }
        return "Solicitud no aceptada, revise su entrada por favor";
    }
    
    public Componentesaccesorio? DetalleComponente(int IdComponente)
    {
        var componente = _componente.GetById(IdComponente);
        if(componente != null){
            return componente;
        }
        return null;
    }
    public string ActualizarComponente(Componentesaccesorio componente, int IdAdmin)
    {
        
        var exist = _componente.GetById(componente.Id);
        if(exist == null){
            return "Componente no reconocido, codigo de componente inexistente";
        }
        exist.Nombre = componente.Nombre;
        exist.Descripcion = componente.Descripcion;
        exist.Fabricante = componente.Fabricante;
        exist.EstadoComponente = componente.EstadoComponente;
        exist.IdCategoria = componente.IdCategoria;
        exist.Ubicacion = componente.Ubicacion;
        exist.Estado = componente.Estado;
        if(_componente.Update(exist, exist.Id)){
            return "Actualizacion completada, revise cambios";
        }
        return "Actualizacion no completada, error en la DB";
    }
    public string EliminarComponente(int IdComponente, int IdAdmin)
    {
        var exist = _componente.GetById(IdComponente);
        if(exist == null){
            return "Componente no reconocido, Id de componente inexistente";
        }
        exist.Estado = "Eliminado";
        if(_componente.Update(exist, exist.Id)){
            return "Eliminacion completa, Revisar Cambios de eliminacion";
        }
        return "Eliminacion no completa, error en la DB";
    }
    
    public List<Componentesaccesorio> MostrarComponentes(string estado = "Disponible")
    {
        var result = _componente.GetByState(estado);
        return result;
    }
    public string cambiar_estado_componente(int IdComponente, int IdAdmin, bool mantenimiento = false)
    {
        var exist = _componente.GetById(IdComponente);
        if(exist == null){
            return "Componente no reconocido, ID de Componente inexistente";
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
        if(_componente.Update(exist, exist.Id)){
            return "Cambio completado, revisar cambios";
        }
        return "Cambios no completados, error en la DB";
    }
}