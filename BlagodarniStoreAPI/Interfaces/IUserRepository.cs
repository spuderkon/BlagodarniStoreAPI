using BlagodarniStoreAPI.Models;

namespace BlagodarniStoreAPI.Interfaces
{
    public interface IUserRepository
    {
        User? Get(int userId);
        User GetMy(int userId);
        List<User> GetCouriers();
        User Add(User user);
        bool UserValid(User user);
    }
}
