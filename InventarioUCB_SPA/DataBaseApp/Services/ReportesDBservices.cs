using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace InventarioUCB_SPA.DataBaseApp.Models.Services;

public class ReporteRepository : BaseRepository<Reporte>
{
    public ReporteRepository(InventarioUcbContext context) : base(context) { }

    // Obtener categorías por área
    public List<Reporte> GetByPrestamoId(int prestamoId)
    {
        return _context.Reportes
            .Where(r => r.IdPrestamo == prestamoId)
            .ToList();
    }

    public List<Reporte> GetByPrestamoFormulario()
    {
        return _context.Reportes
            .Where(r => r.Titulo == "Formulario de Responsabilidad")
            .ToList();
    }

    public List<Reporte> GetByPrestamoObservacion()
    {
        return _context.Reportes
            .Where(r => r.Titulo == "Observacion de Devolucion")
            .ToList();
    }
}