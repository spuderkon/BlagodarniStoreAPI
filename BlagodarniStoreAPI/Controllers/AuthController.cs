using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlagodarniStoreAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using BlagodarniStoreAPI.Models;
using BlagodarniStoreAPI.Tools;
using BlagodarniStoreAPI.ModelsDTO;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;

namespace BlagodarniStoreAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthRepository _IAuthRepository;
        private readonly IConfiguration _IConfiguration;
        private IUserRepository _IUserRepository;


        public AuthController(IAuthRepository iAuthRepository, IConfiguration iConfiguration, IUserRepository iUserRepository)
        {
            _IAuthRepository = iAuthRepository;
            _IConfiguration = iConfiguration;
            _IUserRepository = iUserRepository;
        }

        #region GET

        /*[HttpGet("IsAuth"), Authorize]
        public IActionResult IsAuth()
        {
            return Ok();
        }*/

        #endregion

        #region POST

        [HttpPost("Authorize")]
        public IActionResult Authorize(string phoneNumber, string password)
        {
            try
            {
                User? user = _IAuthRepository.ValidUser(phoneNumber, password);
                if (user is not null)
                {
                    var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.MobilePhone, user.PhoneNumber),
                    new Claim(ClaimTypes.Role, user.Role.Name),
                    new Claim("Id",user.Id.ToString())
                });

                return Ok(new { Token = JwtTools.GenerateJwtToken(identity, _IConfiguration["JwtSettings:Key"]!, _IConfiguration["JwtSettings:Issuer"]!, _IConfiguration["JwtSettings:Audience"]!) });
                }
                return Unauthorized();
            }
            catch (Exception ex)
            {
                return BadRequest(ErrorTools.GetInfo(ex));
            }
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] User user)
        {
            try
            {//рмоа
                User newUser = _IAuthRepository.Register(user)!;
                var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.MobilePhone, newUser.PhoneNumber),
                    new Claim(ClaimTypes.Role, newUser.Role!.Name),
                    new Claim("Id",newUser.Id.ToString())
                });
                string Token = JwtTools.GenerateJwtToken(identity, _IConfiguration["JwtSettings:Key"]!, _IConfiguration["JwtSettings:Issuer"]!, _IConfiguration["JwtSettings:Audience"]!);
                return Ok( Token );
            }
            catch (Exception ex)
            {
                return BadRequest(ErrorTools.GetInfo(ex));
            }
        }

        [HttpPost("SetNewPassword")]
        public IActionResult SetNewPassword(string phoneNumber, string password)
        {
            bool result = _IAuthRepository.SetNewPassword(phoneNumber, password);
            if (result) return Ok();
            else return BadRequest();
        }

        #endregion

        #region PUT



        #endregion

        #region DELETE



        #endregion

    }
}
