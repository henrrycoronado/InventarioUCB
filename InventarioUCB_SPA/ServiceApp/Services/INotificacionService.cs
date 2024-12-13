using InventarioUCB_SPA.DataBaseApp.Models.Services;
using ServicesApp.Models;
public interface INotificacionService{
    void Respuesta_Solicitud();
    void Enviar_Notificacion();
    void Crear_Notificacion();
    void Detalle_Notificacion();
}