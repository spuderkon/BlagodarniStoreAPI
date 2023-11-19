using BlagodarniStoreAPI.Models;

namespace BlagodarniStoreAPI.Interfaces
{
    public interface IUserRepository
    {
        User? Get(int id);
        //User? Add(User user);
    }
}
