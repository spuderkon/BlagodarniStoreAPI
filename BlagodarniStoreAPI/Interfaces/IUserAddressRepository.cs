using BlagodarniStoreAPI.Models;

namespace BlagodarniStoreAPI.Interfaces
{
    public interface IUserAddressRepository
    {
        List<UserAddress>? GetUserAddresses(int id);
        UserAddress Add(int id, string address);
        bool UserAddressDoesntExist(int id, string address);
    }
}
