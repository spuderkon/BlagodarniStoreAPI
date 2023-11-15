using BlagodarniStoreAPI.Interfaces;
using BlagodarniStoreAPI.Models;
using BlagodarniStoreAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BlagodarniStoreAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserRepository _IUserRepository;

        public UserController(IUserRepository iUserRepository) 
        {
            _IUserRepository = iUserRepository;
        }

        #region GET

        [HttpGet("Get/{id}")]
        public ActionResult<User> Get(int id)
        {
            User user = _IUserRepository.Get(id)!;
            return user is null ? NotFound() : user;
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
