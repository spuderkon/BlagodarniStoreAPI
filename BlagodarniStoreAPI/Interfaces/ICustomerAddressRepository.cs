using BlagodarniStoreAPI.Models;

namespace BlagodarniStoreAPI.Interfaces
{
    public interface ICustomerAddressRepository
    {
        List<CustomerAddress>? GetCustomerAddresses(int id);
    }
}
