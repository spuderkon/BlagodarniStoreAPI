using BlagodarniStoreAPI.Models;
using BlagodarniStoreAPI.ModelsDTO.POST;

namespace BlagodarniStoreAPI.Interfaces
{
    public interface IUserRepository
    {
        User? Get(int userId);
        User GetMy(int userId);
        List<User> GetCouriers();
        User Add(CreateUserDTO user);
        bool UserValid(User user);
        void UpdateUserAddress(int userId, int addressId);
    }
}
