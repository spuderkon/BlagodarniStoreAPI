using BlagodarniStoreAPI.Interfaces;
using BlagodarniStoreAPI.Models;
using BlagodarniStoreAPI.ModelsDTO.POST;
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
    public class UserController : ControllerBase
    {
        IUserRepository _iUserRepository;

        public UserController(IUserRepository iUserRepository) 
        {
            _iUserRepository = iUserRepository;
        }

        #region GET

        /// <summary>
        /// Получить пользователя по Id (Токен обязателен, Админ)
        /// </summary>
        /// <param name="id">Id пользователя</param>
        /// <returns></returns>
        /// <response code="200">Успешное выполнение</response>
        /// <response code="400">Ошибка API</response>
        [HttpGet("Get/{id}"), Authorize]
        public ActionResult<User> Get(int id)
        {
            return Ok(_iUserRepository.Get(id));
        }

        /// <summary>
        /// Получить информацию о себе(Токен обязателен)
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Успешное выполнение</response>
        /// <response code="400">Ошибка API</response>
        [HttpGet("GetMy"), Authorize]
        public ActionResult<User> GetMy() 
        { 
            return _iUserRepository.GetMy(int.Parse(HttpContext.User.Claims.First(x => x.Type == "id").Value));
        }

        /// <summary>
        /// Получить всех курьеров (Токен обязателен, Админ)
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Успешное выполнение</response>
        /// <response code="400">Ошибка API</response>
        [HttpGet("GetCouriers"), Authorize(Roles = "admin")]
        public ActionResult<IEnumerable<User>> GetCouriers()
        {
            return Ok(_iUserRepository.GetCouriers());
        }

        #endregion

        #region POST

        /// <summary>
        /// Добавить пользователя (Токен обязателен, Админ)
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     {
        ///        "Name": string,
        ///        "Surname": string,
        ///        "Lastname": string,
        ///        "Email": string,
        ///        "PhoneNumber": string(MAX_LENGTH(11)),
        ///        "RoleId": int,
        ///        "Password": string,
        ///     }
        ///
        /// </remarks>
        /// <param name="user">Пользователь</param>
        /// <returns></returns>
        /// <response code="200">Успешное выполнение</response>
        /// <response code="400">Ошибка API</response>
        [HttpPost("Add"), Authorize(Roles = "admin")]
        public IActionResult Add([FromBody] CreateUserDTO user) 
        {
            try
            {
                return Ok(_iUserRepository.Add(user));
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
