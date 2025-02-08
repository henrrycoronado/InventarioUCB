using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace InventarioUCB_SPA.DataBaseApp.Models.Services;
public class ComponenteRepository : BaseRepository<Componentesaccesorio>
{
    public ComponenteRepository(InventarioUcbContext context) : base(context) { }

    // Obtener equipos por estado
    public List<Componentesaccesorio> GetByStateComponente(string estado)
    {
        return _context.Componentesaccesorios
            .Where(e => e.EstadoComponente == estado)
            .ToList();
    }

    public List<Componentesaccesorio> GetByState(string estado)
    {
        return _context.Componentesaccesorios
            .Where(e => e.Estado == estado)
            .ToList();
    }
    // Obtener equipo por código UCB    
    public Componentesaccesorio? GetByCodigoUcb(string codigoUcb)
    {
        return _context.Componentesaccesorios
            .FirstOrDefault(e => e.CodigoUcb == codigoUcb);
    }
    public List<Componentesaccesorio> GetByCodigoComponente(string codigoComponent)
    {
        return _context.Componentesaccesorios
            .Where(e => e.CodigoComponente == codigoComponent)
            .ToList();
    }
    public List<Componentesaccesorio> GetByFabricante(string Fabricante)
    {
        return _context.Componentesaccesorios
            .Where(e => e.Fabricante == Fabricante)
            .ToList();
    }

    public List<Componentesaccesorio> GetByCategoria(int categoriaId)
    {
        return _context.Componentesaccesorios
            .Where(e => e.IdCategoria == categoriaId)
            .ToList();
    }
    public Componentesaccesorio? GetByNumeroSerie(string numeroSerie)
    {
        return _context.Componentesaccesorios
            .FirstOrDefault(e => e.NumeroSerie == numeroSerie);
    }
    
}