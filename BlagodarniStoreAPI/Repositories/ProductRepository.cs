using BlagodarniStoreAPI.Interfaces;
using BlagodarniStoreAPI.Models;
using BlagodarniStoreAPI.ModelsDTO.GET;
using BlagodarniStoreAPI.ModelsDTO.POST;
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

        public List<Product> GetAll()
        {
            return LoadData(_context.Products).ToList();
        }

        public List<Product>? GetByParentId(int id)
        {
            return LoadData(_context.Products.Where(x => x.Category.ParentId == id).Include(x => x.Unit)).ToList();
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

        #region ADD

        public Product Add(CreateProductDTO product)
        {
            var newProduct = new Product
            {
                Name = product.Name,
                CategoryId = product.CategoryId,
                Description = product.Description,
                Image = product.Image,
                UnitId = product.UnitId,
                Price = product.Price,
            };
            _context.Products.Add(newProduct);
            _context.SaveChanges();
            return newProduct;
        }

        #endregion
    }
}
