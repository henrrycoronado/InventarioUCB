using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace InventarioUCB_SPA.DataBaseApp.Models.Services;
public class ComponenteRepository : BaseRepository<Componentesaccesorio>
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
    public Componentesaccesorio? GetByCodigoComponente(string codigoComponent)
    {
        return _context.Componentesaccesorios
            .FirstOrDefault(e => e.CodigoComponente == codigoComponent);
    }
    public Componentesaccesorio? GetByNumeroSerie(string numeroSerie)
    {
        return _context.Componentesaccesorios
            .FirstOrDefault(e => e.NumeroSerie == numeroSerie);
    }
    
}