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
        if(_equipo.GetByCodigoEquipo(equipo.CodigoEquipo) != null){
            return "Codigo equipo ya existente";
        }else if(equipo.CodigoUcb != null && _equipo.GetByCodigoUcb(equipo.CodigoUcb) != null){
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
        _equipo.Add(EquipoNuevo);
        if(ComprobarEquipo(equipo.CodigoEquipo)){
            return "Creacion de equipo exitosa";
        }
        return "Solicitud no aceptada, revise su entrada por favor";
    }
    public bool ComprobarEquipo(string codigoEquipo){
        if(_equipo.GetByCodigoEquipo(codigoEquipo) == null){
            return false;
        }
        return true;
    }
    
    public EquipoModel DetalleEquipo(string CodigoEquipo)
    {
        var equipo = _equipo.GetByCodigoEquipo(CodigoEquipo);
        if(equipo != null){
            return _validaciones.convertirEquipoModel(equipo);
        }
        return new EquipoModel();
    }
    public string ActualizarEquipo(EquipoModel equipo, int IdAdmin)
    {
        var exist = _equipo.GetByCodigoEquipo(equipo.CodigoEquipo);
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

    public string EliminarEquipo(string CodigoEquipo, int IdAdmin)
    {
        var exist = _equipo.GetByCodigoEquipo(CodigoEquipo);
        if(exist == null){
            return "Equipo no reconocido, codigo de equipo inexistente";
        }
        exist.Estado = "Eliminado";
        _equipo.Update(exist, exist.Id);
        return "Revisar Cambios de eliminacion";
    }

    public List<EquipoModel> MostrarEquipos()
    {
        string estado = "Disponible";
        var result = _equipo.GetByState(estado);
        List<EquipoModel> lista = new List<EquipoModel>();
        foreach (var equipo in result)
        {
            lista.Add(_validaciones.convertirEquipoModel(equipo));
        }
        return lista;
    }

    public string cambiar_estado_equipo(string CodigoEquipo, int IdAdmin, bool mantenimiento = false)
    {
        var exist = _equipo.GetByCodigoEquipo(CodigoEquipo);
        if(exist == null){
            return "Equipo no reconocido, codigo de equipo inexistente";
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
        _equipo.Update(exist, exist.Id);
        return "Revisar cambios";
    }
    public List<ComponenteModel> VerComponentesAsociados(string codigoEquipo){
        var equipo = _equipo.GetByCodigoEquipo(codigoEquipo);
        var lista = new List<ComponenteModel>();
        if(equipo == null){
            return lista;
        }
        var result = _equipo.ConeccionesEquipo(equipo.Id);
        foreach (var componente in result)
        {
            lista.Add(_validaciones.convertirComponenteModel(componente));
        }
        return lista;
    }
    public List<ComponenteModel> VerComponentesNoAsociados(){
        var lista = new List<ComponenteModel>();
        var result = _equipo.ComponentesSinConecciones();
        foreach (var componente in result)
        {
            lista.Add(_validaciones.convertirComponenteModel(componente));
        }
        return lista;
    }

    public string AsociarComponenteEquipo(string CodigoComponente, string CodigoEquipo, int IdAdmin)
    {
        var componente = _componente.GetByCodigoComponente(CodigoComponente);
        var equipo = _equipo.GetByCodigoEquipo(CodigoEquipo);
        if(componente == null || equipo == null){
            return "Coneccion no posible, revise los elementos a asociar";
        }
        if(_equipo.ConeccionActiva(componente.Id, equipo.Id) != null){
            return "Coneccion ya existente";
        }else if(_equipo.ConeccionConotro(componente.Id, equipo.Id) != null){
            return "Componente asociado con otro equipo, elimine primero";
        }
        else if(_equipo.ExistioConeccion(componente.Id, equipo.Id) != null){
            var coneccion = _equipo.ExistioConeccion(componente.Id, equipo.Id);
            if(coneccion != null){
                coneccion.Estado = "Asociado";
                _equipo.UpdateConeccion(coneccion.Id, coneccion);
                return "revisar cambio, se actualizo la asociacion del componente";
            }
            return "No se puede restaurar coneccion previa";
        }
        else{
            var coneccion = new EquipoComponente{
                IdComponente = componente.Id,
                IdEquipo = equipo.Id,
                Estado = "Asociado"
            };
            _equipo.AddComponenteEquipo(coneccion);
            return "Coneccion solicitada, revisar el cambio";
        }
    }
    public string EliminarComponenteEquipo(string CodigoComponente, string CodigoEquipo, int IdAdmin)
    {
        var componente = _componente.GetByCodigoComponente(CodigoComponente);
        var equipo = _equipo.GetByCodigoEquipo(CodigoEquipo);
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
            _equipo.UpdateConeccion(coneccion.Id ,coneccion);
            }
            return "Coneccion Eliminada, revisar el cambio";
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