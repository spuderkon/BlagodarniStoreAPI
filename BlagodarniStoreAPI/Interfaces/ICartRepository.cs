using BlagodarniStoreAPI.Models;

namespace BlagodarniStoreAPI.Interfaces
{
    public interface ICartRepository
    {
        List<Cart> GetMy(int userId);
        void UpdateMy(int userId, List<Cart> carts);
    }
}
