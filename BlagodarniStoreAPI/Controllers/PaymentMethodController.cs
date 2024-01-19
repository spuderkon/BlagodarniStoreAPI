using BlagodarniStoreAPI.Interfaces;
using BlagodarniStoreAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlagodarniStoreAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PaymentMethodController : ControllerBase
    {
        IPaymentMethodRepository _iPaymentMethodRepository;

        public PaymentMethodController(IPaymentMethodRepository iPaymentMethodRepository)
        {
            _iPaymentMethodRepository = iPaymentMethodRepository;
        }

        /// <summary>
        /// Получить все способы оплаты (Токен обязателен)
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Успешное выполнение</response>
        /// <response code="400">Ошибка API</response>
        [HttpGet("GetAll"), Authorize]
        public ActionResult<IEnumerable<PaymentMethod>> GetAll()
        {
            return Ok(_iPaymentMethodRepository.GetAll());
        }
    }
}
