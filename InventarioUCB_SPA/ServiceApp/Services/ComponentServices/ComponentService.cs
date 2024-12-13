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
        if(_componente.GetByCodigoComponente(componente.CodigoComponente) != null){
            return "Codigo componente ya existente";
        }else if(componente.CodigoUcb != null && _componente.GetByCodigoUcb(componente.CodigoUcb) != null){
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
        _componente.Add(ComponenteNuevo);
        if(ComprobarComponente(componente.CodigoComponente)){
            return "Creacion de componente exitosa";
        }
        return "Solicitud no aceptada, revise su entrada por favor";
    }
    public bool ComprobarComponente(string codigoComponent){
        if(_componente.GetByCodigoComponente(codigoComponent) == null){
            return false;
        }
        return true;
    }
    
    public ComponenteModel DetalleComponente(string CodigoComponente)
    {
        var componente = _componente.GetByCodigoComponente(CodigoComponente);
        if(componente != null){
            return _validaciones.convertirComponenteModel(componente);
        }
        return new ComponenteModel();
    }
    public string ActualizarComponente(ComponenteModel componente, int IdAdmin)
    {
        
        var exist = _componente.GetByCodigoComponente(componente.CodigoComponente);
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
        _componente.Update(exist, exist.Id);
        return "Revisar Cambios";
    }
    public string EliminarComponente(string CodigoComponente, int IdAdmin)
    {
        var exist = _componente.GetByCodigoComponente(CodigoComponente);
        if(exist == null){
            return "Componente no reconocido, codigo de componente inexistente";
        }
        exist.Estado = "Eliminado";
        _componente.Update(exist, exist.Id);
        return "Revisar Cambios de eliminacion";
    }
    
    public List<ComponenteModel> MostrarComponentes(string estado = "Disponible")
    {
        var result = _componente.GetByState(estado);
        List<ComponenteModel> lista = new List<ComponenteModel>();
        foreach (var equipo in result)
        {
            lista.Add(_validaciones.convertirComponenteModel(equipo));
        }
        return lista;
    }
    public string cambiar_estado_componente(string CodigoComponente, int IdAdmin, bool mantenimiento = false)
    {
        var exist = _componente.GetByCodigoComponente(CodigoComponente);
        if(exist == null){
            return "Componente no reconocido, codigo de Componente inexistente";
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
        _componente.Update(exist, exist.Id);
        return "Revisar cambios";
    }
}