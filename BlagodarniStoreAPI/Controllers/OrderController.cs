﻿using BlagodarniStoreAPI.Interfaces;
using BlagodarniStoreAPI.Models;
using BlagodarniStoreAPI.ModelsDTO;
using BlagodarniStoreAPI.ModelsDTO.POST;
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

        public OrderController(IOrderRepository iOrderRepository, MeatStoreContext context)
        {
            _iOrderRepository = iOrderRepository;
        }

        #region GET

        /// <summary>
        /// Получить мои все актуальные заказы (Токен обязателен)
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Успешное выполнение</response>
        /// <response code="400">Ошибка API</response>
        [HttpGet("GetMyAllActual"), Authorize]
        public ActionResult<IEnumerable<Order>> GetMyActual()
        {
            return Ok(_iOrderRepository.GetMyActual(int.Parse(HttpContext.User.Claims.First(x => x.Type == "id").Value)));
        }

        /// <summary>
        /// Получить мои все доставленные заказы (Токен обязателен)
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Успешное выполнение</response>
        /// <response code="400">Ошибка API</response>
        [HttpGet("GetMyAllDelivered"), Authorize]
        public ActionResult<IEnumerable<Order>> GetMyDelivered()
        {
            return Ok(_iOrderRepository.GetMyDelivered(int.Parse(HttpContext.User.Claims.First(x => x.Type == "id").Value)));
        }

        /// <summary>
        /// Получить все заказы не назначенные на доставку (Токен обязателен, Админ)
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Успешное выполнение</response>
        /// <response code="400">Ошибка API</response>
        [HttpGet("GetNotInDelivery"),Authorize(Roles = "admin")]
        public ActionResult<IEnumerable<Order>> GetNotInDelivery()
        {
            return Ok(_iOrderRepository.GetNotInDelivery());
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
        ///        "PaymentMethodId": int,
        ///        "Address": string,
        ///     }
        ///
        /// </remarks>
        /// <param name="order">Order</param>
        /// <returns></returns>
        /// <response code="200">Успешное выполнение</response>
        /// <response code="400">Ошибка API</response>
        [HttpPost("CreateMy"), Authorize]
        public IActionResult CreateMy([FromBody] CreateOrderDTO order)
        {
            try
            {
                return Ok(_iOrderRepository.CreateMy(order, int.Parse(HttpContext.User.Claims.First(x => x.Type == "id").Value)));
            }
            catch (Exception ex) 
            {
                return BadRequest(ErrorTools.GetInfo(ex));
            }
        }

        #endregion

        #region PUT

        /// <summary>
        /// Отметить что заказ оплачен (Токен обязателен, Курьер)
        /// </summary>
        /// <returns></returns>
        /// <param name="id">Id заказа</param>
        /// <response code="200">Успешное выполнение</response>
        /// <response code="400">Ошибка API</response>
        [HttpPut("OrderPaid"), Authorize(Roles = "courier")]
        public IActionResult OrderPaid(int id)
        {
            try
            {
                _iOrderRepository.OrderPaid(id, int.Parse(HttpContext.User.Claims.First(x => x.Type == "id").Value));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ErrorTools.GetInfo(ex));
            }
        }

        #endregion

        #region PUT

        /// <summary>
        /// Отметить что получен клиентом (Токен обязателен, Курьер)
        /// </summary>
        /// <returns></returns>
        /// <param name="id">Id заказа</param>
        /// <response code="200">Успешное выполнение</response>
        /// <response code="400">Ошибка API</response>
        [HttpPut("OrderDelivered"), Authorize(Roles = "courier")]
        public IActionResult OrderDelivered(int id)
        {
            try
            {
                _iOrderRepository.OrderDelivered(id, int.Parse(HttpContext.User.Claims.First(x => x.Type == "Id").Value));
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
