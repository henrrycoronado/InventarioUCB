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
    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
        _context.SaveChanges();
    }

    // Eliminar un registro
    public void Delete(int id)
    {
        var entity = _context.Set<T>().Find(id);
        if (entity != null)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }
    }
}