using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace InventarioUCB_SPA.DataBaseApp.Models.Services;

public class RegistroActividadesRepository : BaseRepository<Registrosactividade>
{
    public RegistroActividadesRepository(InventarioUcbContext context) : base(context) { }

    // Obtener categorías por área
    public List<Registrosactividade> GetByActivityByActividad(string actividad)
    {
        return _context.Registrosactividades
                .Where( r => r.Actividad == actividad)
                .ToList();
    }
    public List<Registrosactividade> GetByActivityByAdmin(int IdAdmin)
    {
        return _context.Registrosactividades
                .Where( r => r.IdAdmin == IdAdmin)
                .ToList();
    }
    public List<Registrosactividade> GetByActivityByUsuarioMod(int IdUsuario)
    {
        return _context.Registrosactividades
                .Where( r => r.IdUsuario == IdUsuario)
                .ToList();
    }
    public List<Registrosactividade> GetByActivityByEquipoMod(int IdEquipo)
    {
        return _context.Registrosactividades
                .Where( r => r.IdEquipo == IdEquipo)
                .ToList();
    }
    public List<Registrosactividade> GetByActivityByComponentMod(int IdComponente)
    {
        return _context.Registrosactividades
                .Where( r => r.IdComponente == IdComponente)
                .ToList();
    }
    public bool ActividadCorrect(string actividad)
    {
        if(actividad == "Crear" || actividad == "Asociar" || actividad == "Mover" || actividad == "Modificar" || actividad == "Eliminar"){
            return true;
        }return false;
    }
}