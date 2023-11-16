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

        public List<Cart> GetMyCart(int customerId)
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

    }
}
