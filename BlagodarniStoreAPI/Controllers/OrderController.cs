using BlagodarniStoreAPI.Interfaces;
using BlagodarniStoreAPI.Models;
using BlagodarniStoreAPI.Repositories;
using BlagodarniStoreAPI.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlagodarniStoreAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderRepository _iOrderRepository;
        MeatStoreContext _context;

        public OrderController(IOrderRepository iOrderRepository, MeatStoreContext context)
        {
            _iOrderRepository = iOrderRepository;
            _context = context;
        }

        #region GET

        /// <summary>
        /// Получить все заказы не назначенные на доставку (Токен обязателен, Админ)
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Успешное выполнение</response>
        /// <response code="400">Ошибка API</response>
        [HttpGet("GetNotInDelivery"),Authorize(Roles = "admin")]
        public ActionResult<IEnumerable<Order>> GetNotInDelivery()
        {
            return _iOrderRepository.GetNotInDelivery();
        }

        [HttpGet("test"), Authorize]
        public decimal Test()
        {
            int userId = int.Parse(HttpContext.User.Claims.First(x => x.Type == "Id").Value);
            var sum = _context.Carts.Where(x => x.UserId == userId && x.OrderId == null).Sum(x => x.Product.Price * x.Amount);
            return sum;
        }

        #endregion

        #region POST

        /// <summary>
        /// Cоздать заказ (Токен обязателен)
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///     
        ///     {
        ///        "PaymentMethodId": integer,
        ///        "Paid": bool,
        ///        "Address": string,
        ///     }
        ///
        /// </remarks>
        /// <param name="order">Order</param>
        /// <returns></returns>
        /// <response code="200">Успешное выполнение</response>
        /// <response code="400">Ошибка API</response>
        [HttpPost("CreateMy"), Authorize]
        public IActionResult CreateMy(Order order)
        {
            try
            {
                return Ok(_iOrderRepository.CreateMy(int.Parse(HttpContext.User.Claims.First(x => x.Type == "Id").Value), order));
            }
            catch (Exception ex) 
            {
                return BadRequest(ErrorTools.GetInfo(ex));
            }
            /*var cart = _iCartRepository.GetMy(int.Parse(HttpContext.User.Claims.First(x => x.Type == "Id").Value));
            if (cart.Count() == 0)
            { 
                
            }
            return*/
        }

        #endregion

        #region PUT



        #endregion

        #region DELETE



        #endregion
    }
}
