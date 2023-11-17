using BlagodarniStoreAPI.Models;

namespace BlagodarniStoreAPI.Interfaces
{
    public interface ICartRepository
    {
        List<Cart> GetMy(int customerId);
        void UpdateMy(int customerId, List<Cart> carts);
    }
}
