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

        /// <summary>
        /// Получить пользователя по Id
        /// </summary>
        /// <param name="id">Id пользователя</param>
        /// <returns></returns>
        /// <response code="200">Успешное выполнение</response>
        /// <response code="400">Ошибка API</response>
        [HttpGet("Get/{id}")]
        public ActionResult<User> Get(int id)
        {
            return _iUserRepository.Get(id);
        }

        [HttpGet("GetMy"), Authorize]
        public ActionResult<User> Get() 
        { 
            return _iUserRepository.GetMy(int.Parse(HttpContext.User.Claims.First(x => x.Type == "Id").Value))!;
        }

        [HttpGet("GetCouriers"), Authorize(Roles = "admin")]
        public ActionResult<IEnumerable<User>> GetCouriers()
        {
            return _iUserRepository.GetCouriers();
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
