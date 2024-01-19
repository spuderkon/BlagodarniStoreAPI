using BlagodarniStoreAPI.Interfaces;
using BlagodarniStoreAPI.Models;
using BlagodarniStoreAPI.ModelsDTO.GET;
using BlagodarniStoreAPI.ModelsDTO.POST;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace BlagodarniStoreAPI.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        MeatStoreContext _context;
        ICartRepository _iCartRepository;
        IUserRepository _iUserRepository;
        IUserAddressRepository _iUserAddressRepository;

        public OrderRepository(MeatStoreContext context, ICartRepository iCartRepository,IUserRepository iUserRepository, IUserAddressRepository iUserAddressRepository)
        {
            _context = context;
            _iCartRepository = iCartRepository;
            _iUserRepository = iUserRepository;
            _iUserAddressRepository = iUserAddressRepository;
        }

        #region GET

        public List<Order> GetMyActual(int userId)
        {
            return LoadData(_context.Orders.Where(x => x.UserId == userId && x.StatusId == 1)).ToList();
        }

        public List<Order> GetMyDelivered(int userId)
        {
            return LoadData(_context.Orders.Where(x => x.UserId == userId && x.StatusId == 2)).ToList();
        }

        public List<Order> GetNotInDelivery()
        {
            return LoadData(_context.Orders.Where(x => x.StatusId == 1)).ToList();
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

        public Order CreateMy(CreateOrderDTO order, int userId)
        {
            var carts = _context.Carts.Where(x => x.UserId == userId && x.OrderId == null);
            var qwe = carts.Count();
            bool paid = order.PaymentMethodId == 1 ? true : false;
            if (carts.ToList().Count() != 0)
            {
                    var newOrder = new Order
                    {
                        UserId = userId,
                        OrderDate = DateTime.Now,
                        StatusId = 1,
                        TotalPrice = carts.Sum(x => x.Product!.Price * x.Amount),
                        PaymentMethodId = order.PaymentMethodId,
                        Paid = paid,
                        AddressId = order.AddressId,
                    };

                    _context.Orders.Add(newOrder);
                    _context.SaveChanges();
                    carts.ToList().ForEach(x => x.OrderId = newOrder.Id);
                    List<UpdateCartDTO> updateCarts = carts.Select(x => new UpdateCartDTO()
                    {
                        ProductId = x.ProductId,
                        Amount = x.Amount,
                        OrderId = x.OrderId,
                    }).ToList();
                    _iCartRepository.UpdateMy(updateCarts, userId);
                    return newOrder;            
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
                if (delivery.CourierId != courierId)
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
                if (delivery.CourierId != courierId)
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

    }
}
