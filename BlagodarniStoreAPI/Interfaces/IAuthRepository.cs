using BlagodarniStoreAPI.Models;
using BlagodarniStoreAPI.ModelsDTO;

namespace BlagodarniStoreAPI.Interfaces
{
    public interface IAuthRepository
    {
        public User? ValidUser(string phoneNumber, string password);
        public User? Register(User user);
        public bool SetNewPassword(int userId, string phoneNumber, string password);
    }
}
