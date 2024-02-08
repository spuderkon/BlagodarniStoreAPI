using BlagodarniStoreAPI.Models;
using BlagodarniStoreAPI.ModelsDTO.POST;

namespace BlagodarniStoreAPI.Interfaces
{
    public interface IUnitRepository
    {
        List<Unit> GetAll();

        Unit Add(CreateUnitDTO unit);
    }
}
