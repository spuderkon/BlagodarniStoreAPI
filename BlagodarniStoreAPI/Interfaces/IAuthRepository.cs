using BlagodarniStoreAPI.Models;
using BlagodarniStoreAPI.Interfaces;

namespace BlagodarniStoreAPI.Interfaces
{
    public interface IAuthRepository
    {
        public User? ValidUser(string email, string password);
    }
}
