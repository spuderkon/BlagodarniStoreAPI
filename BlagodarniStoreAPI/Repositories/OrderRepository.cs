using BlagodarniStoreAPI.Interfaces;
using BlagodarniStoreAPI.Models;
using BlagodarniStoreAPI.ModelsDTO;

namespace BlagodarniStoreAPI.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        MeatStoreContext _context;
        ICartRepository _iCartRepository;

        public OrderRepository(MeatStoreContext context, ICartRepository iCartRepository)
        {
            _context = context;
            _iCartRepository = iCartRepository;
        }

        #region GET
        public List<Order> GetNotInDelivery()
        {
            var orders = _context.Orders.Where(x => x.StatusId == 1);
            return LoadData(orders).ToList();
        }

        private IQueryable<Order> LoadData(IQueryable<Order> orders)
        {
            return orders
                  .Select(x => new OrderDTO(x)
                  {
                      PaymentMethod = new PaymentMethodDTO(x.PaymentMethod),
                      Status = new OrderStatusDTO(x.Status),
                  });
        }

        #endregion

        #region ADD


        //
        //Сделать добавление OrderId в Cart при форманировании заказа!
        //




        public Order CreateMy(int customerId, Order order)
        {
            var cart = _iCartRepository.GetMy(customerId);
            if(cart.Count() != 0)
            {
                if(customerId != order.CustomerId)
                {
                    throw new Exception("Id пользователей не совпадает");
                }
                Order newOrder = new Order
                {
                    CustomerId = order.Id,
                    OrderDate = DateTime.Now,
                    StatusId = 1,
                    TotalPrice = _context.Carts.Where(x => x.CustomerId == customerId && x.OrderId == null).Sum(x => x.Product.Price * x.Amount),
                    PaymentMethodId = order.PaymentMethodId,
                    Paid = order.Paid,
                    Address = order.Address,
                };
                _context.Orders.Add(newOrder);
                _context.SaveChanges();
                return newOrder;
            }

            throw new Exception("Корзина пуста");
        }

        #endregion

        #region UPDATE

        

        #endregion

        #region REMOVE



        #endregion
    }
}
