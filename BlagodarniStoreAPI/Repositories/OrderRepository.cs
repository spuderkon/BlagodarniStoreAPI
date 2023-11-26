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

        public Order CreateMy(int userId, OrderDTO order)
        {
            var carts = _context.Carts.Where(x => x.UserId == userId && x.OrderId == null);
            if (carts.Count() != 0)
            {
                if(order.PaymentMethodId != 1 && order.Paid)
                {
                    throw new Exception($"Конфликт полей {order.PaymentMethodId} и {order.Paid}") ;
                }
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



        #endregion

        /*
         
        public void OrderTaken(int deliveryId, int courierId)
        {
            var delivery = _context.Deliveries.FirstOrDefault(x => x.Id == deliveryId);
            if (delivery is not null)
            {
                if (delivery.UserId == courierId)
                {
                    var order = _context.Orders.FirstOrDefault(x => x.Id == delivery.OrderId)!;
                    order.StatusId = 3;
                    _context.Orders.Update(order);
                    _context.Deliveries.Update(delivery);
                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception("Заказ не принадлежит вам");
                }
            }
            else
            {
                throw new Exception("Такого заказа не существует");
            }
        } 

         */
    }
}
