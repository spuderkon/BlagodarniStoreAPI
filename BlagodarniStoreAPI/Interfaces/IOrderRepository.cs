using BlagodarniStoreAPI.Models;
using BlagodarniStoreAPI.ModelsDTO;

namespace BlagodarniStoreAPI.Interfaces
{
    public interface IOrderRepository
    {
        List<Order> GetNotInDelivery();

        Order CreateMy(int userId, OrderDTO order);
        void OrderPaid(int deliveryId, int courierId);
        void OrderDelivered(int deliveryId, int courierId);
    }
}
