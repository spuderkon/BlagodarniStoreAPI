﻿using BlagodarniStoreAPI.Interfaces;
using BlagodarniStoreAPI.Models;
using BlagodarniStoreAPI.Repositories;
using BlagodarniStoreAPI.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlagodarniStoreAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        ICartRepository _iCartRepository;

        public CartController(ICartRepository iCartRepository)
        {
            _iCartRepository = iCartRepository;
        }

        #region GET

        /// <summary>
        /// Получить мою корзину (Токен обязателен)
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Успешное выполнение</response>
        /// <response code="400">Ошибка API</response>
        [HttpGet("GetMy"), Authorize]
        public ActionResult<IEnumerable<Cart>> GetMy() 
        {
            return _iCartRepository.GetMy(int.Parse(HttpContext.User.Claims.First(x => x.Type == "Id").Value));
        }

        #endregion

        #region POST



        #endregion

        #region PUT

        /// <summary>
        /// Обновить или записать корзину (Токен обязателен)
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     [
        ///      {
        ///       "id": int,
        ///       "customerId": int,
        ///       "productId": int,
        ///       "amount": int
        ///      },
        ///      {
        ///       "id": int,
        ///       "customerId": int,
        ///       "productId": int,
        ///       "amount": int
        ///      },
        ///      {
        ///         ...
        ///      }
        ///     ]
        ///
        /// </remarks>
        /// <param name="carts">Корзины</param>
        /// <returns></returns>
        /// <response code="200">Успешное выполнение</response>
        /// <response code="400">Ошибка API</response>
        [HttpPut("UpdateMy"), Authorize]
        public IActionResult UpdateMy([FromBody] List<Cart> carts)
        { 
            try
            {
                _iCartRepository.UpdateMy(carts, int.Parse(HttpContext.User.Claims.First(x => x.Type == "Id").Value));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ErrorTools.GetInfo(ex));
            }
        }

        #endregion

        #region DELETE



        #endregion
    }
}
