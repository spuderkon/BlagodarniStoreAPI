using BlagodarniStoreAPI.Models;

namespace BlagodarniStoreAPI.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetByParentId(int CategoryId);
        Product Add(Product product);
    }
}
