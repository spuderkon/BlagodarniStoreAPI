using BlagodarniStoreAPI.Interfaces;
using BlagodarniStoreAPI.Models;
using BlagodarniStoreAPI.Repositories;
using BlagodarniStoreAPI.Tools;
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

        /// <summary>
        /// Получить продукты по категории родителя
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        /// <response code="200">Успешное выполнение</response>
        /// <response code="400">Ошибка API</response>
        [HttpGet("GetByParent/{Id}")]
        public ActionResult<IEnumerable<Product>> GetByParentId(int id)
        {
            var Products = _iProductRepository.GetByParentId(id);
            return Products == null ? NotFound() : Products;
        }

        #endregion

        #region POST

        /// <summary>
        /// Создать новый продукт (Токен обязателен)
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///     
        ///     {
        ///        "Name": "Name",
        ///        "CategoryId": 1,
        ///        "Description": "Description",
        ///        "Image": "Image.jpg",
        ///        "UnitId": 1,
        ///        "Price": 1
        ///     }
        ///
        /// </remarks>
        /// <param name="product">Product</param>
        /// <returns></returns>
        /// <response code="200">Успешное выполнение</response>
        /// <response code="400">Ошибка API</response>
        [HttpPost("Add")]//, Authorize(Roles = "admin")
        public IActionResult Add([FromBody] Product product)
        {
            try
            {
                Product newProduct = _iProductRepository.Add(product);
                return Ok(newProduct);
            }
            catch (Exception ex) 
            {
                return BadRequest(ErrorTools.GetInfo(ex));
            }
        }
        #endregion

        #region PUT



        #endregion

        #region DELETE



        #endregion
    }
}
