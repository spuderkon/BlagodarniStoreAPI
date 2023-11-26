using BlagodarniStoreAPI.Interfaces;
using BlagodarniStoreAPI.Models;
using BlagodarniStoreAPI.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlagodarniStoreAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        IRoleRepository _iRoleRepository;

        public RoleController(IRoleRepository iRoleRepository)
        {
            _iRoleRepository = iRoleRepository;
        }

        #region GET

        /// <summary>
        /// Получить все роли (Токен обязателен, Админ)
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Успешное выполнение</response>
        /// <response code="400">Ошибка API</response>
        [HttpGet("GetAll"), Authorize(Roles = "admin")]
        public ActionResult<IEnumerable<Role>> GetAll()
        {
            return _iRoleRepository.GetAll();
        }

        #endregion

        #region POST


        #endregion

        #region PUT



        #endregion

        #region DELETE



        #endregion
    }
}
