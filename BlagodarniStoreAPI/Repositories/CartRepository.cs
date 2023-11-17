using Azure.Core;
using BlagodarniStoreAPI.Interfaces;
using BlagodarniStoreAPI.Models;
using BlagodarniStoreAPI.ModelsDTO;
using Microsoft.EntityFrameworkCore;

namespace BlagodarniStoreAPI.Repositories
{
    public class CartRepository : ICartRepository
    {
        MeatStoreContext _context;

        public CartRepository(MeatStoreContext context)
        {
            _context = context;
        }

        #region GET

        public List<Cart> GetMy(int customerId)
        {
            var carts = _context.Carts.Where(x => x.CustomerId == customerId && x.OrderId == null);
            return LoadData(carts).ToList();
        }

        private IQueryable<Cart> LoadData(IQueryable<Cart> carts)
        {
            return carts.Include(x => x.Product)
                  .Select(x => new CartDTO(x)
                  {
                      Product = new ProductDTO(x.Product),
                  });
        }

        #endregion

        #region ADD



        #endregion

        #region UPDATE

        public void UpdateMy(int customerId, List<Cart> carts)
        {
            foreach (var cart in carts)
            {
                if(_context.Carts.Any(x => x == cart))
                {
                    _context.Carts.Update(cart);
                }
                else
                {
                    _context.Carts.Add(cart);
                }
            }
            _context.SaveChanges();
            /*foreach (var cart in carts) 
            { 
                _context.Carts.Update(cart);
            }
            _context.SaveChanges();*/
            /* if(_context.Carts.Any(x => x.CustomerId == customerId && x.OrderId == null))
             {
                 foreach (var cart in carts)
                 {
                     _context.Carts.Update(cart);
                 }
                 _context.Carts.Attach
             }*/
        }

        #endregion

        #region DELETE



        #endregion
    }
}
