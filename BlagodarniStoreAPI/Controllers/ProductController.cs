using BlagodarniStoreAPI.Interfaces;
using BlagodarniStoreAPI.Models;
using BlagodarniStoreAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BlagodarniStoreAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        IProductRepository _iProductRepository;

        public ProductController(IProductRepository productRepository)
        {
            _iProductRepository = productRepository;
        }

        #region GET
        [HttpGet("GetProductsByParent/{Id}")]
        public ActionResult<IEnumerable<Product>> GetProductsByParent(int Id)
        {
            var Products = _iProductRepository.GetProductsByParent(Id);
            return Products == null ? NotFound() : Products;
        }

        #endregion
    }
}
