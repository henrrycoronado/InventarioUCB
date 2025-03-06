using InventarioUCB_SPA.DataBaseApp.Models.Services;
using ServicesApp.Models;
namespace ServicesApp.Models.Services;
public class LoginServices : ILoginService
{
    private readonly UsuarioRepository _user;
    public LoginServices(UsuarioRepository user){
        _user = user;
    }
    public bool ComprobarCorreo(string correo)
    {
        if(_user.ExistsByEmail(correo)){
            return true;
        }
        return false;
    }
    public int? Logear(string correo, string password)
    {
        if(ComprobarCorreo(correo)){
            return _user.GetIdByLog(correo, password);
        }
        return null;
    }
    public string? GetRol(int id){
        var result = _user.GetById(id);
        if(result != null && result.Rol != null){
            return result.Rol;
        }
        return null;
    }
}