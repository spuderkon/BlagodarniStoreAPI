using BlagodarniStoreAPI.Interfaces;
using BlagodarniStoreAPI.Models;
using BlagodarniStoreAPI.ModelsDTO;
using Microsoft.EntityFrameworkCore;
using System;

namespace BlagodarniStoreAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        MeatStoreContext _context;

        public ProductRepository(MeatStoreContext context)
        {
            _context = context;
        }

        #region GET

        public List<Product>? GetProductsByParent(int CategoryId)
        {
            var products = _context.Products.Where(x => x.Category.ParentId == CategoryId).Include(x=> x.Unit);
            return LoadData(products).ToList();
        }
        private IQueryable<Product> LoadData(IQueryable<Product> products)
        {
            return products
                  .Select(x => new ProductDTO(x)
                  {
                      Unit = new UnitDTO(x.Unit),
                      Category = new CategoryDTO(x.Category)
                  });
        }

        #endregion
    }
}
