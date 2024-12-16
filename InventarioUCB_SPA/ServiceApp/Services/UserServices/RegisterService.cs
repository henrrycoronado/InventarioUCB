using InventarioUCB_SPA.DataBaseApp.Models;
using InventarioUCB_SPA.DataBaseApp.Models.Services;
using ServicesApp.Models;
namespace ServicesApp.Models.Services;
public class RegisterService : IRegisterService
{
    private readonly UsuarioRepository _user;
    private readonly ValidacionesService _validaciones;
    public RegisterService(UsuarioRepository user, ValidacionesService validaciones){
        _user = user;
        _validaciones = validaciones;
    }
    public string RegistrarUsuario(UsuarioModel user, int IdAdmin)
    {
        if(_user.ExistsByCI(user.Ci)){
            return "CI ya existente";
        }else if(_user.ExistsByEmail(user.Correo)){
            return "Correo ya existente";
        }else if(_user.ExistsByTelefono(user.Telefono)){
            return "Telefono ya existente";
        }
        if(!_validaciones.AdminValido(IdAdmin)){
            return "Tipo de credor no reconocido";
        }
        var usuarioNuevo = new Usuario{
            Ci = user.Ci,
            Nombre = user.Nombre,
            Apellido = user.Apellido,
            Correo = user.Correo,
            Contraseña = user.Contraseña,
            Telefono = user.Telefono,
            Rol = user.Rol
        };
        if(_user.CrearUser(usuarioNuevo)){
            return "Creacion de perfil exitosa, intenta con tus credenciales ingresadas";
        }
        return "Solicitud no aceptada, revise su entrada por favor";
    }
    public bool ComprobarUsuario(string correo, string pasword)
    {
        var result = _user.GetIdByLog(correo, pasword);
        if(result == null){
            return false;
        }
        return true;
    }
}