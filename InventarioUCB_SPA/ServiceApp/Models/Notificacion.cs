using InventarioUCB_SPA.DataBaseApp.Models.Services;
namespace ServicesApp.Models;
public class Notificacion
{
    public int IdNotificacion { get; set; }
    public UsuarioModel Destinatario { get; set; } = null!;
    public string Mensaje { get; set; } = null!;
    public DateTime FechaEnvio { get; set; }

    public void EnviarNotificacion()
    {
        
    }
}