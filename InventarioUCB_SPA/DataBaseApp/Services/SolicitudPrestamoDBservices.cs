using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace InventarioUCB_SPA.DataBaseApp.Models.Services;

public class SolicitudPrestamoRepository : BaseRepository<Solicitudesprestamo>
{
    public SolicitudPrestamoRepository(InventarioUcbContext context) : base(context) { }

    // Obtener categorías por área
    public List<Solicitudesprestamo> GetPendingRequests()
    {
        return _context.Solicitudesprestamos
            .Where(s => s.Estado == "Pendiente")
            .ToList();
    }
    public List<Solicitudesprestamo> SolicitudesUsuario(int idUser)
    {
        return _context.Solicitudesprestamos
            .Where(s => s.IdUsuario == idUser)
            .ToList();
    }
}