using BlagodarniStoreAPI.Models;

namespace BlagodarniStoreAPI.Interfaces
{
    public interface IAuthRepository
    {
        public User? ValidUser(string email, string password);
        public User? Register(User user);
    }
}
