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
        Console.WriteLine("se llego al metodo");
        if(ComprobarCorreo(correo)){
            Console.WriteLine("se llego al metodo  y se retorna lago");
            return _user.GetIdByLog(correo, password);
        }
        Console.WriteLine("se llego al metodo y retorna null");
        return null;
    }
}