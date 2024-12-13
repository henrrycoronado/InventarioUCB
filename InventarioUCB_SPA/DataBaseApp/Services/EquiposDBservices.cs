using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace InventarioUCB_SPA.DataBaseApp.Models.Services;
public class EquipoRepository : BaseRepository<Equipo>
{
    public EquipoRepository(InventarioUcbContext context) : base(context) { }

    // Obtener equipos por estado
    public List<Equipo> GetByState(string estado)
    {
        return _context.Equipos
            .Where(e => e.EstadoEquipo == estado)
            .ToList();
    }
    public void AddComponent(int idEquipo, int idComponent){
        var ConectarEquipoComponent = new EquipoComponente{
            IdEquipo = idEquipo,
            IdComponente = idComponent,
            Estado = "Asociado"
        };
        _context.EquipoComponentes.Add(ConectarEquipoComponent);
        _context.SaveChanges();
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