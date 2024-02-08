using BlagodarniStoreAPI.Interfaces;
using BlagodarniStoreAPI.Models;
using BlagodarniStoreAPI.ModelsDTO.POST;
using BlagodarniStoreAPI.Repositories;
using BlagodarniStoreAPI.Tools;
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

        /// <summary>
        /// Добавить новую еденицу измерения (Токен обязателен, Админ)
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///     
        ///     {
        ///        "Measure": string,
        ///        "Name": string,
        ///     }
        ///
        /// </remarks>
        /// <param name="unit">Продукт</param>
        /// <returns></returns>
        /// <response code="200">Успешное выполнение</response>
        /// <response code="400">Ошибка API</response>
        [HttpPost("Add"), Authorize(Roles = "admin")]
        public IActionResult Add([FromBody] CreateUnitDTO unit)
        {
            try
            {
                return Ok(_iUnitRepository.Add(unit));
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
