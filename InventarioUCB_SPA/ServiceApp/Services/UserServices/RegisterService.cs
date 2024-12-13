using InventarioUCB_SPA.DataBaseApp.Models.Services;
using ServicesApp.Models;
namespace ServicesApp.Models.Services;
public class RegisterService : IRegisterService
{
    
    public bool RegistrarUsuario(UsuarioModel user)
    {
        return true;
    }
    public bool ComprobarUsuario(UsuarioModel user)
    {
        return true;
    }
}