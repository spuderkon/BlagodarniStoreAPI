using BlagodarniStoreAPI.Models;

namespace BlagodarniStoreAPI.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        List<Product>? GetByParentId(int id);
        Product Add(Product product);
    }
}
