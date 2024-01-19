using BlagodarniStoreAPI.Models;
using BlagodarniStoreAPI.ModelsDTO.POST;

namespace BlagodarniStoreAPI.Interfaces
{
    public interface IAuthRepository
    {
        string? Authorize(string phoneNumber, string password);
        User? ValidUser(string phoneNumber, string password);
        string? Register(CreateUserDTO user);
        bool SetNewPassword(string phoneNumber, string password, int userId);
    }
}
