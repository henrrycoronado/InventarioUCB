using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace InventarioUCB_SPA.DataBaseApp.Models.Services;

public class SolicitudPrestamoRepository : BaseRepository<Solicitudesprestamo>
{
    public SolicitudPrestamoRepository(InventarioUcbContext context) : base(context) { }

    // Obtener categorías por área
    public List<Solicitudesprestamo> GetSolicitudEstado(string TipoSolicitudes)
    {
        return _context.Solicitudesprestamos
            .Where(s => s.Estado == TipoSolicitudes)
            .ToList();
    }
    public List<Solicitudesprestamo> GetByIdUser(int idUser)
    {
        return _context.Solicitudesprestamos
            .Where(s => s.IdUsuario == idUser)
            .ToList();
    }
}