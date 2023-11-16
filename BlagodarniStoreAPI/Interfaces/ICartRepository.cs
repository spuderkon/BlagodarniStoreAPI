using BlagodarniStoreAPI.Models;

namespace BlagodarniStoreAPI.Interfaces
{
    public interface ICartRepository
    {
        List<Cart> GetMyCart(int customerId);
    }
}
