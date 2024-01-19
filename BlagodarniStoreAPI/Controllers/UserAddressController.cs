using BlagodarniStoreAPI.Interfaces;
using BlagodarniStoreAPI.Models;
using BlagodarniStoreAPI.ModelsDTO;
using BlagodarniStoreAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlagodarniStoreAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserAddressController : ControllerBase
    {
        IUserAddressRepository _iUserAddressRepository;

        public UserAddressController(IUserAddressRepository iUserAddressRepository)
        {
            _iUserAddressRepository = iUserAddressRepository;
        }

        #region GET

        /// <summary>
        /// Получить адреса покупателя (Токен обязателен, Админ или Покупатель)
        /// </summary>
        /// <param name="id">Id пользователя</param>
        /// <returns></returns>
        /// <response code="200">Успешное выполнение</response>
        /// <response code="400">Ошибка API</response>
        [HttpGet("GetUserAddresses/{Id}"), Authorize(Roles = "admin,customer")]
        public ActionResult<IEnumerable<UserAddress>> GetUserAddresses(int id) 
        {
            return Ok(_iUserAddressRepository.GetUserAddresses(id));
        }


        #endregion

        #region POST

        /// <summary>
        /// Добавить адрес (Токен обязателен)
        /// </summary>
        /// <param name="address">Адрес</param>
        /// <returns></returns>
        /// <response code="200">Успешное выполнение</response>
        /// <response code="400">Ошибка API</response>
        [HttpPost("AddMy/{address}"), Authorize]
        public IActionResult AddMy(string address)
        {
            try
            {
                return Ok(_iUserAddressRepository.Add(int.Parse(HttpContext.User.Claims.First(x => x.Type == "id").Value), address));
            }
            catch (Exception ex) 
            { 
                return BadRequest(ex.Message);
            }
        }

        #endregion
    }
}
