using BlagodarniStoreAPI.Models;

namespace BlagodarniStoreAPI.Interfaces
{
    public interface IUserAddressRepository
    {
        List<UserAddress>? GetUserAddresses(int id);
    }
}
