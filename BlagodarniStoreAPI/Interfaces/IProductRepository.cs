using BlagodarniStoreAPI.Models;
using BlagodarniStoreAPI.ModelsDTO.POST;

namespace BlagodarniStoreAPI.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        List<Product>? GetByParentId(int id);
        Product Add(CreateProductDTO product);
    }
}
