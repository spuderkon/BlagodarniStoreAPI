using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlagodarniStoreAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using BlagodarniStoreAPI.Models;
using BlagodarniStoreAPI.Tools;

namespace BlagodarniStoreAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthRepository _IAuthRepository;
        private readonly IConfiguration _Configuration;

        public AuthController(IAuthRepository iAuthRepository, IConfiguration configuration)
        {
            _IAuthRepository = iAuthRepository;
            _Configuration = configuration;
        }

        [HttpGet("IsAuth"), Authorize]
        public IActionResult IsAuth()
        {
            return Ok();
        }

        [HttpPost("Authorize")]
        public IActionResult Authorize(string email, string password)
        {
            try
            {
                User? user = _IAuthRepository.ValidUser(email, password);
                if (user is not null)
                {
                    var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Role.Name),
                    new Claim("Id",user.Id.ToString())
                });
                    return Ok(new { Token = JwtTools.GenerateJwtToken(identity, _Configuration["JwtSettings:Key"], _Configuration["JwtSettings:Issuer"], _Configuration["JwtSettings:Audience"]) });
                }
                return Unauthorized();
            }
            catch (Exception ex)
            {
                return BadRequest(ErrorTools.GetInfo(ex));
            }
        }
    }
}
