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

        public void UpdateMy(List<Cart> newCarts,int userId)
        {
            if (CartsBelongUser(userId, newCarts))
            {
                var dataBaseCarts = _context.Carts.Where(x => x.UserId == userId && x.OrderId == null).ToList();
                newCarts = newCarts.GroupBy(x => x.ProductId).Select(group =>
                    new Cart
                    {
                        UserId = group.First().UserId,
                        ProductId = group.Key,
                        Amount = group.Sum(cart => cart.Amount)
                    })
                    .ToList();
                var cartsToDelete = dataBaseCarts.ExceptBy(newCarts.Select(x => x.ProductId), x=> x.ProductId).ToList();
                foreach (var cart in newCarts) 
                {
                    var existingCart = _context.Carts.FirstOrDefault(x => x.UserId == userId && x.ProductId == cart.ProductId && x.OrderId == null);

                    if(existingCart == null)
                    {
                        _context.Carts.Add(cart);
                    }
                    else
                    {
                        existingCart.Amount = cart.Amount;
                        _context.Carts.Update(existingCart);
                    }
                }
                _context.Carts.RemoveRange(cartsToDelete);
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
