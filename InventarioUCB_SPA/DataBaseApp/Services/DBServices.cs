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
    public bool Add(T entity)
    {
        try{
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return true;
        }catch(Exception e){
            Console.WriteLine(e);
            return false;
        };
    }

    // Actualizar un registro existente
    public bool Update(T entity, int id)
    {
        try
        {
            var existingEntity = GetById(id);
            if (existingEntity == null){ return false;}
    
            _context.Entry(existingEntity).CurrentValues.SetValues(entity); // Solo actualiza propiedades
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
}