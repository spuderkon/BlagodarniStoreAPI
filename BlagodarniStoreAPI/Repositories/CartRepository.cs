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

        public List<Cart> GetMy(int userId)
        {
            var carts = _context.Carts.Where(x => x.UserId == userId && x.OrderId == null);
            return LoadData(carts).ToList();
        }

        private IQueryable<Cart> LoadData(IQueryable<Cart> carts)
        {
            return carts.Include(x => x.Product)
                  .Select(x => new CartDTO(x)
                  {
                      Product = new ProductDTO(x.Product!),
                  });
        }

        #endregion

        #region ADD



        #endregion

        #region UPDATE

        public void UpdateMy(List<Cart> carts,int userId)
        {
            if (CartsBelongUser(userId,carts))
            {
                carts = carts.GroupBy(x => x.ProductId).Select(group => 
                    new Cart
                    {
                        UserId = group.First().UserId,
                        ProductId = group.Key,
                        Amount = group.Sum(cart => cart.Amount)
                    })
                    .ToList();

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
            }
            else
            {
                throw new Exception($"Конфликт полей UserId и Cart.User.Id");
            }
        }

        #endregion

        #region DELETE



        #endregion

        #region TOOLMETHODS

        private bool CartsBelongUser(int userId, List<Cart> carts)
        {
            foreach(var cart in carts)
            {
                if(cart.UserId != userId)
                    return false;
            }
            return true;
        }

        #endregion
    }
}
