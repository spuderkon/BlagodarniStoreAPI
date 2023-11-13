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


        [HttpGet("GetProductsByParentId/{Id}")]
        public ActionResult<IEnumerable<Product>> GetProductsByParentId(int Id)
        {
            var Products = _ProductRepository.GetProductsByParentId(Id);
            return Products == null ? NotFound() : Products;
        }
    }
}
