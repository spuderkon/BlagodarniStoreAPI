using BlagodarniStoreAPI.Models;
using BlagodarniStoreAPI.ModelsDTO;

namespace BlagodarniStoreAPI.Interfaces
{
    public interface IAuthRepository
    {
        string? Authorize(string phoneNumber, string password);
        User? ValidUser(string phoneNumber, string password);
        string? Register(User user);
        bool SetNewPassword(string phoneNumber, string password, int userId);
    }
}
