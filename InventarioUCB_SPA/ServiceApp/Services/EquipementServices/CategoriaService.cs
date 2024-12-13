using InventarioUCB_SPA.DataBaseApp.Models;
using InventarioUCB_SPA.DataBaseApp.Models.Services;
using ServicesApp.Models;
namespace ServicesApp.Models.Services;
public class CategoriaServices : ICategoriaServices
{
    private readonly CategoriaRepository _cate;
    public CategoriaServices(CategoriaRepository cate){
        _cate = cate;
    }
    public string CrearCategoria(CategoriaModel categoria)
    {
        var result = _cate.GetByName(categoria.Nombre);
        if(result != null){
            return "categoria ya existe";
        }
        var modelo = new Categoria{
            Nombre = categoria.Nombre,
            Area = categoria.Area
        };
        _cate.Add(modelo);
        return "categoria creada";
    }
}