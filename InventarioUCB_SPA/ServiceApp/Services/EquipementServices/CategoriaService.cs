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
    public string CrearCategoria(Categoria categoria)
    {
        var result = _cate.GetByName(categoria.Nombre);
        if(result != null){
            return "categoria ya existe";
        }
        var modelo = new Categoria{
            Nombre = categoria.Nombre,
            Area = categoria.Area
        };
        if(_cate.Add(modelo)){
            return "categoria creada";
        }
        
        return "Error al crear la categoria en la DB";
    }
    public List<Categoria> ObtenerCategorias(){
        return _cate.GetAll();
    }

    public List<Categoria> ObtenerCategoriasArea(string area){
        return _cate.GetByArea(area);
    }    
}