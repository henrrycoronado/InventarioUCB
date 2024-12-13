using InventarioUCB_SPA.DataBaseApp.Models.Services;
using ServicesApp.Models;
public interface IRegisterService
{
    bool RegistrarUsuario(UsuarioModel user);
    bool ComprobarUsuario(UsuarioModel user);
}