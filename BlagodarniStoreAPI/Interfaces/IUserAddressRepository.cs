using BlagodarniStoreAPI.Models;

namespace BlagodarniStoreAPI.Interfaces
{
    public interface IUserAddressRepository
    {
        List<UserAddress>? GetUserAddresses(int id);
        UserAddress Add(int userId, string address);
    }
}
