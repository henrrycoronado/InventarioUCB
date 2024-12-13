using InventarioUCB_SPA.DataBaseApp.Models.Services;
using ServicesApp.Models;
public interface IRegisterService
{
    string RegistrarUsuario(UsuarioModel user, int IdAdmin);
    bool ComprobarUsuario(string correo, string pasword);
}