﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NoteBookAPI.Contracts;
using NoteBookAPI.Entities;
using NoteBookAPI.Helper;
using NoteBookAPI.Models;
using NoteBookAPI.Services;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Security.Claims;

namespace NoteBookAPI.Controllers
{
    [ApiController]
    [Route("api/auth/signin")]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        private readonly ILoginServices _service;
        private readonly ILogger _logger;
        public LoginController(ILogger logger,IConfiguration config, ILoginServices service)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _logger = logger ?? throw new ArgumentException(nameof(logger));
        }
        /// <summary>
        /// Login
        /// </summary>
        /// <remarks>To get access the address book</remarks>
        /// <param name="loginCredentials"></param>
        /// <response code="200">Success</response>
        /// <response code="401">The user input is not authorized.</response>
        /// <response code="500">Internal Server Error</response>
        [SwaggerOperation("UserLogin")]
        [SwaggerResponse(statusCode: 200, "Success!")]
        [SwaggerResponse(statusCode: 401, "The user is not authorized")]
        [SwaggerResponse(statusCode: 500, "Internal Server Error")]
        [AllowAnonymous]
        [HttpPost]
        public IActionResult UserLogin([Required][FromBody] LoginCredentialsDto loginCredentials)
        {
                _logger.LogInformation("Authentication Initiated"); 
                User User = _service.GetUserByEmail(loginCredentials.EmailAddress);
                bool check = _service.AuthenticateUser(User, loginCredentials);
                if (check)
                {
                    string tokenString = _service.GenerateJSONWebToken(User,_config);
                    LoginResult responseToReturn = new LoginResult();
                    responseToReturn.accessToken = tokenString;
                    _logger.LogInformation("Logged in successfully");
                    return new JsonResult(responseToReturn);
                }
                else
                {
                    _logger.LogError("EmailId and Password is wrong");
                    return StatusCode(401, _service.ErrorToReturn("401", "Check your email Id and password"));
            }   
        }
    }
}
