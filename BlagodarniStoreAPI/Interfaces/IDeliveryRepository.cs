using BlagodarniStoreAPI.Models;
using BlagodarniStoreAPI.ModelsDTO.POST;

namespace BlagodarniStoreAPI.Interfaces
{
    public interface IDeliveryRepository
    {
        List<Delivery> GetMyActive(int userId);
        Delivery? Get(int id, int userId);
        Delivery AssignCourier(CreateDeliveryDTO delivery);
    }
}
