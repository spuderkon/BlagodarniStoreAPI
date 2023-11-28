using BlagodarniStoreAPI.Interfaces;
using BlagodarniStoreAPI.Models;
using BlagodarniStoreAPI.ModelsDTO;
using Microsoft.EntityFrameworkCore;

namespace BlagodarniStoreAPI.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        MeatStoreContext _context;
        ICartRepository _iCartRepository;
        IUserAddressRepository _iUserAddressRepository;

        public OrderRepository(MeatStoreContext context, ICartRepository iCartRepository, IUserAddressRepository iUserAddressRepository)
        {
            _context = context;
            _iCartRepository = iCartRepository;
            _iUserAddressRepository = iUserAddressRepository;
        }

        #region GET
        public List<Order> GetNotInDelivery()
        {
            return LoadData(_context.Orders.Where(x => x.StatusId == 1)).ToList();
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

        public Order CreateMy(Order order, int userId)
        {
            var carts = _context.Carts.Where(x => x.UserId == userId && x.OrderId == null);
            if (carts.Count() != 0)
            {
                if(order.PaymentMethodId != 1 && order.Paid)
                {
                    throw new Exception($"Конфликт полей {order.PaymentMethodId} и {order.Paid}") ;
                }
                else
                {
                    Order newOrder = new Order
                    {
                        UserId = userId,
                        OrderDate = DateTime.Now,
                        StatusId = 1,
                        TotalPrice = carts.Sum(x => x.Product!.Price * x.Amount),
                        PaymentMethodId = order.PaymentMethodId,
                        Paid = order.Paid,
                        Address = order.Address,
                    };
                    _context.Orders.Add(newOrder);
                    _context.SaveChanges();
                    carts.ToList().ForEach(x => x.OrderId = newOrder.Id);
                    _iCartRepository.UpdateMy(carts.ToList(), userId);
                    if(UserAddressDoesntExist(newOrder.Address))
                    {
                        _iUserAddressRepository.Add(order.Address,userId);
                    }
                    return newOrder;
                }
            }
            else
            {
                throw new Exception("Корзина пуста");
            }
        }

        #endregion

        #region UPDATE

        public void OrderPaid(int orderId, int courierId)
        {
            var delivery = _context.Deliveries.FirstOrDefault(x => x.OrderId == orderId);
            if (delivery is not null)
            {
                if (delivery.UserId != courierId)
                {
                    throw new Exception("Заказ вам не принадлежит");
                }
                else
                {
                    var order = _context.Orders.FirstOrDefault(x => x.Id == orderId);
                    if(order.Paid)
                    {
                        throw new Exception("Заказ уже оплачен");
                    }
                    else
                    {
                        order.Paid = true;
                        _context.Orders.Update(order);
                        _context.SaveChanges();
                    }
                }
            }
            else
            {
                throw new Exception("Доставки с таким заказом не существует");
            }
        }

        public void OrderDelivered(int orderId, int courierId)
        {
            var delivery = _context.Deliveries.FirstOrDefault(x => x.OrderId == orderId);
            if (delivery is not null)
            {
                if (delivery.UserId != courierId)
                {
                    throw new Exception("Заказ вам не принадлежит");
                }
                var order = _context.Orders.FirstOrDefault(x => x.Id == orderId);
                if(order.Paid)
                {
                    order.StatusId = 2;
                    _context.Orders.Update(order);
                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception("Заказ не оплачен");
                }
            }
            else
            {
                throw new Exception("Доставки с таким заказом не существует");
            }
        }

        #endregion

        #region REMOVE



        #endregion

        #region TOOLMETHODS

        public bool UserAddressDoesntExist(string address)
        {
            if(_context.UserAddresses.FirstOrDefault(x => x.Address == address) == null)
                return true;
            return false;
        }

        #endregion

    }
}
