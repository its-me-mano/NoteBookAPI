using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NoteBookAPI.Entities;
using NoteBookAPI.Helper;
using NoteBookAPI.Models;
using NoteBookAPI.Services;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;


namespace NoteBookAPI.Controllers
{
    [ApiController]
    [Route("api/auth/signin")]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        private readonly IUserDetailRepository _userDetailRepositary;
        private readonly IMapper _mapper;
        private readonly IService _service;
        private readonly ILogger _logger;


        public LoginController(ILogger logger,IUserDetailRepository UserDetailRepositary, IMapper mapper, IConfiguration config, IService service)
        {
            _userDetailRepositary = UserDetailRepositary ?? throw new ArgumentNullException(nameof(UserDetailRepositary));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
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
                Guid GetUserId = _userDetailRepositary.EmailIdOfUser(loginCredentials.EmailAddress);
                User User = _userDetailRepositary.GetUser(GetUserId);
                IActionResult response = Unauthorized();
                bool check = _service.AuthenticateUser(User, loginCredentials);
                if (check)
                {
                    string tokenString = _service.GenerateJSONWebToken(User,_config);
                    LoginResult responseToReturn = new LoginResult();
                    responseToReturn.accessToken = tokenString;
                    _logger.LogError("Logged in successfully");
                    return new JsonResult(responseToReturn);
                }
                else
                {
                    _logger.LogError("LoginId and password is wrong");
                    return StatusCode(401, "Check your loginId and Password");
                }
            
            
        }
    }
}
