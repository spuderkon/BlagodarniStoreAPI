using BlagodarniStoreAPI.Interfaces;
using BlagodarniStoreAPI.Models;
using BlagodarniStoreAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlagodarniStoreAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        IUnitRepository _iUnitRepository;

        public UnitController(IUnitRepository iUnitRepository)
        {
            _iUnitRepository = iUnitRepository;
        }

        #region GET

        /// <summary>
        /// Получить все виды измерения продукта (Токен обязателен, Админ)
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Успешное выполнение</response>
        /// <response code="400">Ошибка API</response>
        [HttpGet("GetAll"), Authorize(Roles = "admin")]
        public ActionResult<IEnumerable<Unit>> GetAll()
        {
            return Ok(_iUnitRepository.GetAll());
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
