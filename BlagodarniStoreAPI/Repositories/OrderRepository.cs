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
                      PaymentMethod = new PaymentMethodDTO(x.PaymentMethod!),
                      Status = new OrderStatusDTO(x.Status!),
                  });
        }

        #endregion

        #region ADD


        //
        //Сделать добавление OrderId в Cart при форманировании заказа!
        //




        public Order CreateMy(int userId, Order order)
        {
            var carts = _context.Carts.Where(x => x.UserId == userId && x.OrderId == null);
            if (carts.Count() != 0)
            {
                Order newOrder = new Order
                {
                    UserId = userId,
                    OrderDate = DateTime.Now,
                    StatusId = 1,
                    TotalPrice = carts.Sum(x => x.Product.Price * x.Amount),
                    PaymentMethodId = order.PaymentMethodId,
                    Paid = order.Paid,
                    Address = order.Address,
                };
                _context.Orders.Add(newOrder);
                _context.SaveChanges();
                carts.ToList().ForEach(x => x.OrderId = newOrder.Id);
                _iCartRepository.UpdateMy(userId, carts.ToList());
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
