using BlagodarniStoreAPI.Models;
using BlagodarniStoreAPI.ModelsDTO.POST;

namespace BlagodarniStoreAPI.Interfaces
{
    public interface ICartRepository
    {
        List<Cart> GetMy(int userId);
        void UpdateMy(List<UpdateCartDTO> carts, int userId);
    }
}
