using BlagodarniStoreAPI.Models;

namespace BlagodarniStoreAPI.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetProductsByParent(int CategoryId);
    }
}
