using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace InventarioUCB_SPA.DataBaseApp.Models.Services;

public class DetalleSolicitudPrestamoRepository : BaseRepository<Detallessolicitudprestamo>
{
    public DetalleSolicitudPrestamoRepository(InventarioUcbContext context) : base(context) { }

    // Obtener categorías por área
    public List<Detallessolicitudprestamo> GetBySolicitudId(int idSolicitud)
    {
        return _context.Detallessolicitudprestamos
        .Where(d => d.Estado == "Seleccionado" && d.IdSolicitudPrestamo == idSolicitud)
        .ToList();
    }
}