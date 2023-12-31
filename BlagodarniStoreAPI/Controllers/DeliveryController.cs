﻿using BlagodarniStoreAPI.Interfaces;
using BlagodarniStoreAPI.Models;
using BlagodarniStoreAPI.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlagodarniStoreAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        IDeliveryRepository _iDeliveryRepository;

        public DeliveryController (IDeliveryRepository iDeliveryRepository)
        {
            _iDeliveryRepository = iDeliveryRepository;
        }

        #region GET

        /// <summary>
        /// Получить информацию о доставке (Токен обязателен, Курьер)
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        /// <response code="200">Успешное выполнение</response>
        /// <response code="400">Ошибка API</response>
        [HttpGet("Get/{id}"), Authorize(Roles = "courier")]
        public ActionResult Get(int id)
        {
            return Ok(_iDeliveryRepository.Get(id, int.Parse(HttpContext.User.Claims.First(x => x.Type == "Id").Value)));
        }

        /// <summary>
        /// Получить все активные заказы на доставку (Токен обязателен, Курьер)
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Успешное выполнение</response>
        /// <response code="400">Ошибка API</response>
        [HttpGet("GetMyAllActive"), Authorize(Roles = "courier")]
        public ActionResult<IEnumerable<Delivery>> GetMyAllActive()
        {
            return Ok(_iDeliveryRepository.GetMyAllActive(int.Parse(HttpContext.User.Claims.First(x => x.Type == "Id").Value)));
        }

        #endregion

        #region POST

        /// <summary>
        /// Назначить курьера на доставку (Токен обязателен, Админ)
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///     
        ///     {
        ///        "OrderId": int,
        ///        "UserId": int,
        ///        "DateArrive": datetime, Format ("MMMM-MM-dd HH:mm:ss")
        ///     }
        ///
        /// </remarks>
        /// <param name="delivery">Delivery</param>
        /// <returns></returns>
        /// <response code="200">Успешное выполнение</response>
        /// <response code="400">Ошибка API</response>
        [HttpPost("AssignCourier"), Authorize(Roles = "admin")]
        public IActionResult AssignCourier([FromBody] Delivery delivery)
        {
            try 
            {
                return Ok(_iDeliveryRepository.AssignCourier(delivery));
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
