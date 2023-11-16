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
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _iAuthRepository;
        private readonly IConfiguration _iConfiguration;

        public AuthController(IAuthRepository iAuthRepository, IConfiguration iConfiguration)
        {
            _iAuthRepository = iAuthRepository;
            _iConfiguration = iConfiguration;
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
                User? user = _iAuthRepository.ValidUser(phoneNumber, password);
                if (user is not null)
                {
                    var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.MobilePhone, user.PhoneNumber),
                    new Claim(ClaimTypes.Role, user.Role.Name),
                    new Claim("Id",user.Id.ToString())
                });
                    string Token = JwtTools.GenerateJwtToken(identity, _iConfiguration["JwtSettings:Key"]!, _iConfiguration["JwtSettings:Issuer"]!, _iConfiguration["JwtSettings:Audience"]!);
                return Ok(Token);
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
            {
                User newUser = _iAuthRepository.Register(user)!;
                var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.MobilePhone, newUser.PhoneNumber),
                    new Claim(ClaimTypes.Role, newUser.Role!.Name),
                    new Claim("Id",newUser.Id.ToString())
                });
                string Token = JwtTools.GenerateJwtToken(identity, _iConfiguration["JwtSettings:Key"]!, _iConfiguration["JwtSettings:Issuer"]!, _iConfiguration["JwtSettings:Audience"]!);
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
            bool result = _iAuthRepository.SetNewPassword(phoneNumber, password);
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
