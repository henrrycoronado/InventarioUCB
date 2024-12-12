using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace InventarioUCB_SPA.DataBaseApp.Models.Services;

public class CategoriaRepository : BaseRepository<Categoria>
{
    public CategoriaRepository(InventarioUcbContext context) : base(context) { }

    // Obtener categorías por área
    public List<Categoria> GetByArea(string area)
    {
        return _context.Categorias
            .Where(c => c.Area == area)
            .ToList();
    }
    public Categoria? GetByName(string name)
    {
        return _context.Set<Categoria>().FirstOrDefault(e => e.Nombre == name);
    }

    public bool AreaCorrect(string area)
    {
        if(area == "Aula" || area == "Laboratorio" || area == "Taller"){
            return true;
        }return false;
    }
}