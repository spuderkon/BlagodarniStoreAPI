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

        public List<Product>? GetProductsByParentId(int CategoryId)
        {
            var products = _context.Products.Where(x => x.Category.ParentId == CategoryId).Include(x=> x.Unit).ToList();
            return products;
        }
        /*private IQueryable<Product> LoadData(IQueryable<Product> products)
        {
            return products
                  .Select(x => new ProductDTO(x)
                  {
                      Post = x.Post != null ? new PostDTO(x.Post) : null,
                      Role = new RoleDTO(x.Role),
                      Department = x.Department != null ? new DepartmentDTO(x.Department) : null
                  });
        }*/

        #endregion
    }
}
