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
    public bool ChangeStateDetalleSolicitud(int idDetalleSoli){
        try{
            var ds = GetById(idDetalleSoli);
            if(ds == null){return false;}
            if(ds.Estado == "Seleccionado"){
                ds.Estado = "Deseleccionado";
            }else{
                ds.Estado = "Seleccionado";
            }
            if(Update(ds, ds.Id)){
                return true;
            }
            return false;
        }catch(Exception e){
            Console.WriteLine(e);
            return false;
        }
    }

    public Detallessolicitudprestamo? ConeccionActiva(int Id_Solicitud, int Id_equipo){
        return _context.Detallessolicitudprestamos
                .Where( e => e.IdSolicitudPrestamo == Id_Solicitud && e.IdEquipo == Id_equipo && e.Estado == "Seleccionado")
                .FirstOrDefault();
    }
    public Detallessolicitudprestamo? ExistioConeccion(int Id_Solicitud, int Id_equipo){
        return _context.Detallessolicitudprestamos
                .Where( e => e.IdSolicitudPrestamo == Id_Solicitud && e.IdEquipo == Id_equipo && e.Estado == "Deseleccionado")
                .FirstOrDefault();
    }

    
}