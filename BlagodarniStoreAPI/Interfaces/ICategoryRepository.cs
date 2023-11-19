using BlagodarniStoreAPI.Models;

namespace BlagodarniStoreAPI.Interfaces
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
    }
}
