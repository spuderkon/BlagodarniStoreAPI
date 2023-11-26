using BlagodarniStoreAPI.Interfaces;
using BlagodarniStoreAPI.Models;
using BlagodarniStoreAPI.ModelsDTO;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BlagodarniStoreAPI.Repositories
{
    public class DeliveryRepository : IDeliveryRepository
    {
        MeatStoreContext _context;

        public DeliveryRepository(MeatStoreContext context)
        {
            _context = context;
        }

        #region GET

        public Delivery? Get(int id, int userId) 
        {
            var delivery = _context.Deliveries.Where(x => x.Id == id && x.UserId == userId).Include(x=> x.Order.Carts).FirstOrDefault();
            return delivery;
        }

        public List<Delivery> GetMyAllActive(int userId)
        {
            var deliveries = _context.Deliveries.Where(x => x.UserId == userId && x.Order.StatusId != 2);
            return LoadData(deliveries).ToList();
        }

        private IQueryable<Delivery> LoadData(IQueryable<Delivery> deliveries)
        {
            return deliveries
                  .Select(x => new DeliveryDTO(x)
                  {
                  });
        }

        #endregion

        #region ADD

        public Delivery AssignCourier(Delivery newDelivery)
        {
            var delivery = _context.Deliveries.FirstOrDefault(x => x.OrderId == newDelivery.OrderId);
            if (delivery is not null)
            {
                throw new Exception("Доставка уже сформирована");
            }
            _context.Deliveries.Add(newDelivery);
            _context.SaveChanges();
            return newDelivery;
        }

        #endregion

        #region UPDATE



        #endregion

        #region REMOVE



        #endregion
    }
}