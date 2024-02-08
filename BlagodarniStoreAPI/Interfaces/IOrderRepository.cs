using BlagodarniStoreAPI.Models;
using BlagodarniStoreAPI.ModelsDTO;
using BlagodarniStoreAPI.ModelsDTO.POST;

namespace BlagodarniStoreAPI.Interfaces
{
    public interface IOrderRepository
    {
        List<Order> GetNotInDelivery();
        Order CreateMy(CreateOrderDTO order, int userId);
        List<Order> GetMyActual(int userId);
        List<Order> GetMyDelivered(int userId);
        void OrderPaid(int deliveryId, int courierId);
        void OrderDelivered(int deliveryId, int courierId);
        void RejectOrder(int orderId);
    }
}
