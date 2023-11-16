﻿using BlagodarniStoreAPI.Interfaces;
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
        IUserRepository _iUserRepository;

        public UserController(IUserRepository iUserRepository) 
        {
            _iUserRepository = iUserRepository;
        }

        #region GET

        [HttpGet("Get/{id}")]
        public ActionResult<User> Get(int id)
        {
            User user = _iUserRepository.Get(id)!;
            return user;
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
