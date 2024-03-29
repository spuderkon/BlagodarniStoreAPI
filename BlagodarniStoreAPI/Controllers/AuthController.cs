﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlagodarniStoreAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using BlagodarniStoreAPI.Models;
using BlagodarniStoreAPI.Tools;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using BlagodarniStoreAPI.ModelsDTO.GET;
using BlagodarniStoreAPI.ModelsDTO.POST;

namespace BlagodarniStoreAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _iAuthRepository;

        public AuthController(IAuthRepository iAuthRepository)
        {
            _iAuthRepository = iAuthRepository;
        }

        #region GET

        /// <summary>
        /// Проверка авторизации (Токен обяазателен)
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Успешное выполнение</response>
        /// <response code="400">Ошибка API</response>
        [HttpGet("IsAuth"), Authorize]
        public IActionResult IsAuth()
        {
            return Ok();
        }
        /*[HttpGet("Test")]
        public IActionResult Test()
        {
            return Ok("qwe");
        }*/

        #endregion

        #region POST

        /// <summary>
        /// Авторизация
        /// </summary>
        /// <param name="phoneNumber">Номер телефона</param>
        /// <param name="password">Пароль</param>
        /// <returns></returns>
        /// <response code="200">Успешное выполнение</response>
        /// <response code="400">Ошибка API</response>
        [HttpPost("Authorize")]
        public IActionResult Authorize(string phoneNumber, string password)
        {
            try
            {
                return Ok(_iAuthRepository.Authorize(phoneNumber, password));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Регистрация
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///     
        ///     {
        ///        "Name": string,
        ///        "Surname": string,
        ///        "Lastname": string,
        ///        "Email": string,
        ///        "PhoneNumber": string(MAX_LENGTH(11)),
        ///        "Password": string
        ///     }
        ///
        /// </remarks>
        /// <param name="user">User</param>
        /// <returns></returns>
        /// <response code="200">Успешное выполнение</response>
        /// <response code="400">Ошибка API</response>
        [HttpPost("Register")]
        public IActionResult Register([FromBody] CreateUserDTO user)
        {
            try
            {
                string token = _iAuthRepository.Register(user)!;
                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Установка нового пароля (Токен обязателен)
        /// </summary>
        /// <param name="phoneNumber">Номер телефона</param>
        /// <param name="newPassword">Новый пароль</param>
        /// <returns></returns>
        /// <response code="200">Успешное выполнение</response>
        /// <response code="400">Ошибка API</response>
        [HttpPost("SetNewPassword"), Authorize]
        public IActionResult SetNewPassword(string phoneNumber, string newPassword)
        { 
            if (_iAuthRepository.SetNewPassword(
                phoneNumber, 
                newPassword,
                int.Parse(HttpContext.User.Claims.First(x => x.Type == "id").Value))) 
                return Ok();
            else return BadRequest();
        }

        #endregion

        #region PUT



        #endregion

        #region DELETE



        #endregion

    }
}
