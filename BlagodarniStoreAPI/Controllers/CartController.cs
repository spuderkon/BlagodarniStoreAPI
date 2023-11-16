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
    public class CartController : ControllerBase
    {
        ICartRepository _iCartRepository;

        public CartController(ICartRepository iCartRepository)
        {
            _iCartRepository = iCartRepository;
        }

        #region GET

        [HttpGet("GetMyCart"), Authorize]
        public ActionResult<IEnumerable<Cart>> GetMyCart() 
        {
            return _iCartRepository.GetMyCart(int.Parse(HttpContext.User.Claims.First(x => x.Type == "Id").Value));
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
