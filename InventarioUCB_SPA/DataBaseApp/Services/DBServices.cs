using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace InventarioUCB_SPA.DataBaseApp.Models.Services;
public class BaseRepository<T> where T : class
{
    protected readonly InventarioUcbContext _context;

    public BaseRepository(InventarioUcbContext context)
    {
        _context = context;
    }

    // Obtener todos los registros
    public List<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }

    // Obtener por Id
    public T? GetById(int id)
    {
        return _context.Set<T>().Find(id);
    }

    // Crear un nuevo registro
    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
        _context.SaveChanges();
    }

    // Actualizar un registro existente
    public void Update(T entity, int id)
    {
        var existingEntity = GetById(id);
        if (existingEntity == null){ return ;}
    
        _context.Entry(existingEntity).CurrentValues.SetValues(entity); // Solo actualiza propiedades
        _context.SaveChanges();
    }
}