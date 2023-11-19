using BlagodarniStoreAPI.Interfaces;
using BlagodarniStoreAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlagodarniStoreAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryRepository _iCategoryRepository;

        public CategoryController(ICategoryRepository iCategoryRepository)
        {
            _iCategoryRepository = iCategoryRepository;
        }

        #region GET

        /// <summary>
        /// Получить все категории (Токен обязателен, Admin)
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Успешное выполнение</response>
        /// <response code="400">Ошибка API</response>
        [HttpGet("GetAll"), Authorize(Roles = "admin")]
        public ActionResult<IEnumerable<Category>> GetAll()
        {
            return _iCategoryRepository.GetAll();
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
