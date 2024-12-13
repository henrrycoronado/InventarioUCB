using InventarioUCB_SPA.DataBaseApp.Models;
using InventarioUCB_SPA.DataBaseApp.Models.Services;
using ServicesApp.Models;
namespace ServicesApp.Models.Services;

public interface ICategoriaServices {
    string CrearCategoria(CategoriaModel categoria);
    
}