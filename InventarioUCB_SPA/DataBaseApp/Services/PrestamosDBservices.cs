using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace InventarioUCB_SPA.DataBaseApp.Models.Services;

public class PrestamoRepository : BaseRepository<Prestamo>
{
    public PrestamoRepository(InventarioUcbContext context) : base(context) { }

    // Obtener categorías por área
    public List<Prestamo> GetByRetraso()
    {
        return _context.Prestamos
        .Where(d => d.Estado == "Activo" && d.FechaDevolucion < DateOnly.FromDateTime(DateTime.Now))
        .ToList();
    }
    public List<Prestamo> GetByDevueltos()
    {
        return _context.Prestamos
        .Where(d => d.Estado == "Devueltos" || d.Estado == "Retrasado")
        .ToList();
    }
    public Prestamo? GetInforPrestamo(int IdSolicitudPrestamo){
        return _context.Prestamos
                .Where( p => p.IdSolicitudPrestamo == IdSolicitudPrestamo)
                .FirstOrDefault();
    } 
}