using BlagodarniStoreAPI.Models;

namespace BlagodarniStoreAPI.Interfaces
{
    public interface IRoleRepository
    {
        List<Role> GetAll();
    }
}
