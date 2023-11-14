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

        IProductRepository _ProductRepository;

        public ProductController(IProductRepository productRepository)
        {
            _ProductRepository = productRepository;
        }


        [HttpGet("GetProductsByParent/{Id}")]
        public ActionResult<IEnumerable<Product>> GetProductsByParent(int Id)
        {
            var Products = _ProductRepository.GetProductsByParent(Id);
            return Products == null ? NotFound() : Products;
        }
    }
}
