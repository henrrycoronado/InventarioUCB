using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace InventarioUCB_SPA.DataBaseApp.Models.Services;
public class EquipoRepository : BaseRepository<Equipo>
{
    public EquipoRepository(InventarioUcbContext context) : base(context) { }

    public EquipoComponente? ConeccionActiva(int Id_component, int Id_equipo){
        return _context.EquipoComponentes
                .Where( e => e.IdComponente == Id_component && e.IdEquipo == Id_equipo && e.Estado == "Asociado")
                .FirstOrDefault();
    }
    public EquipoComponente? ExistioConeccion(int Id_component, int Id_equipo){
        return _context.EquipoComponentes
                .Where( e => e.IdComponente == Id_component && e.IdEquipo == Id_equipo && e.Estado == "Eliminado")
                .FirstOrDefault();
    }
    public EquipoComponente? ConeccionConotro(int Id_component, int Id_equipo){
        return _context.EquipoComponentes
                .Where( e => e.IdComponente == Id_component && e.Estado == "Asociado" && e.IdEquipo != Id_equipo)
                .FirstOrDefault();
    }
    public void UpdateConeccion(int id_coneccion, EquipoComponente actualizar){
        var existingEntity = _context.EquipoComponentes.Where(r => r.Id == id_coneccion).FirstOrDefault();
        if (existingEntity == null){ return ;}
    
        _context.Entry(existingEntity).CurrentValues.SetValues(actualizar); // Solo actualiza propiedades
        _context.SaveChanges();
    }
    public void AddComponenteEquipo(EquipoComponente coneccion){
        _context.EquipoComponentes.Add(coneccion);
        _context.SaveChanges();
    }
    public List<Componentesaccesorio> ConeccionesEquipo(int Id_equipo){
        return _context.EquipoComponentes
                .Where( e => e.IdEquipo == Id_equipo && e.Estado == "Asociado")
                .Join(
                    _context.Componentesaccesorios,
                    ec => ec.IdComponente,
                    c => c.Id,
                    (ec, c) => c
                ).ToList();
                
    }
    public List<Componentesaccesorio> ComponentesSinConecciones()
{
    return _context.Componentesaccesorios
        .GroupJoin(
            _context.EquipoComponentes, // Tabla con la que haremos la unión
            c => c.Id,                  // Clave en Componentesaccesorios
            ec => ec.IdComponente,      // Clave en EquipoComponentes
            (c, ecs) => new { Componente = c, EquipoComponentes = ecs }) // Proyección
        .Where(x => !x.EquipoComponentes.Any() || 
                    x.EquipoComponentes.Any(ec => ec.Estado == "Eliminado")) // Filtrar componentes sin conexiones o con estado "Eliminado"
        .Select(x => x.Componente) // Seleccionar solo el Componente
        .ToList();
}



    // Obtener equipos por estado
    public List<Equipo> GetByState(string estado)
    {
        return _context.Equipos
            .Where(e => e.Estado == estado)
            .ToList();
    }
    // Obtener equipo por código UCB
    public Equipo? GetByCodigoUcb(string codigoUcb)
    {
        return _context.Equipos
            .FirstOrDefault(e => e.CodigoUcb == codigoUcb);
    }
    public Equipo? GetByCodigoEquipo(string codigoEquipo)
    {
        return _context.Equipos
            .FirstOrDefault(e => e.CodigoEquipo == codigoEquipo);
    }
    public Equipo? GetByNumeroSerie(string numeroSerie)
    {
        return _context.Equipos
            .FirstOrDefault(e => e.NumeroSerie == numeroSerie);
    }
    
}