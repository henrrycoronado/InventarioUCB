using InventarioUCB_SPA.DataBaseApp.Models.Services;
using ServicesApp.Models;

public interface ILoginService
{
    bool ComprobarCorreo(string correo);
    int? Logear(string correo, string password);
}