using BlagodarniStoreAPI.Interfaces;
using BlagodarniStoreAPI.Models;
using BlagodarniStoreAPI.ModelsDTO.GET;
using BlagodarniStoreAPI.ModelsDTO.POST;
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
            return LoadData(_context.Deliveries.Where(x => x.Id == id && x.CourierId == userId).Include(x => x.Order.Carts)).FirstOrDefault();
        }

        public List<Delivery> GetMyAllActive(int userId)
        {
            return LoadData(_context.Deliveries.Where(x => x.CourierId == userId && x.Order.StatusId != 2)).ToList();
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

        public Delivery AssignCourier(CreateDeliveryDTO delivery)
        {
            var existingDelivery = _context.Deliveries.FirstOrDefault(x => x.OrderId == delivery.OrderId);
            if (existingDelivery is not null)
            {
                throw new Exception("Доставка уже сформирована");
            }
            var newDelivery = new Delivery
            {
                OrderId = delivery.OrderId,
                CourierId = delivery.CourierId,
                DateArrive = delivery.DateArrive,
            };
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