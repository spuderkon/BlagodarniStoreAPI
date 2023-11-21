using BlagodarniStoreAPI.Models;

namespace BlagodarniStoreAPI.Interfaces
{
    public interface IOrderRepository
    {
        List<Order> GetNotInDelivery();

        Order CreateMy(int userId, Order order);
    }
}
