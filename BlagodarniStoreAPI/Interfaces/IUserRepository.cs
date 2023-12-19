using BlagodarniStoreAPI.Models;

namespace BlagodarniStoreAPI.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> Get(int userId);
        User GetMy(int userId);
        List<User> GetCouriers();
        User Add(User user);
    }
}
