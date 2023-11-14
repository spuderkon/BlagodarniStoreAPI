using BlagodarniStoreAPI.Models;

namespace BlagodarniStoreAPI.Interfaces
{
    public interface IUserRepository
    {
        public User? Get(int id);
        //User? Add(User user);
    }
}
