using BlagodarniStoreAPI.Models;
using BlagodarniStoreAPI.ModelsDTO;

namespace BlagodarniStoreAPI.Interfaces
{
    public interface IOrderRepository
    {
        List<Order> GetNotInDelivery();
        Order CreateMy(Order order, int customerId);
        void OrderPaid(int deliveryId, int courierId);
        void OrderDelivered(int deliveryId, int courierId);
    }
}
