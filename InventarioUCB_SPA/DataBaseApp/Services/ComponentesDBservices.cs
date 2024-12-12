using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace InventarioUCB_SPA.DataBaseApp.Models.Services;
public class ComponenteRepository : BaseRepository<Equipo>
{
    public ComponenteRepository(InventarioUcbContext context) : base(context) { }

    // Obtener equipos por estado
    public List<Componentesaccesorio> GetByState(string estado)
    {
        return _context.Componentesaccesorios
            .Where(e => e.EstadoComponente == estado)
            .ToList();
    }
    // Obtener equipo por código UCB
    public Componentesaccesorio? GetByCodigoUcb(string codigoUcb)
    {
        return _context.Componentesaccesorios
            .FirstOrDefault(e => e.CodigoUcb == codigoUcb);
    }
    public Componentesaccesorio? GetByCodigoEquipo(string codigoComponent)
    {
        return _context.Componentesaccesorios
            .FirstOrDefault(e => e.CodigoComponente == codigoComponent);
    }
    public Equipo? GetByNumeroSerie(string numeroSerie)
    {
        return _context.Equipos
            .FirstOrDefault(e => e.NumeroSerie == numeroSerie);
    }
    public bool EstadoEquipoCorrect(string estadoEquipo)
    {
        if(estadoEquipo == "Nuevo" || estadoEquipo == "Bueno" || estadoEquipo == "Bueno - Sellado" || estadoEquipo == "Regular" || estadoEquipo == "Usado"){
            return true;
        }return false;
    }
    public bool EstadoCorrect(string estadoEquipo)
    {
        if(estadoEquipo == "Disponible" || estadoEquipo == "Ocupado" || estadoEquipo == "Mantenimiento" || estadoEquipo == "Eliminado"){
            return true;
        }return false;
    }
}