using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NoteBookAPI.Entities;
using NoteBookAPI.Helper;
using NoteBookAPI.Models;
using NoteBookAPI.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NoteBookAPI.Controllers
{
    [ApiController]
    [Route("api/auth/signin")]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        private readonly IUserDetailRepositary _userDetailRepositary;
        private readonly IMapper _mapper;
   

        public LoginController(IUserDetailRepositary UserDetailRepositary, IMapper mapper, IConfiguration config)
        {
            _userDetailRepositary = UserDetailRepositary ?? throw new ArgumentNullException(nameof(UserDetailRepositary));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _config = config ?? throw new ArgumentNullException(nameof(config));
        
        }
/*

                                                   AUTHORIZATION SECTION

*/
        private string GenerateJSONWebToken(User userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
        new Claim(JwtRegisteredClaimNames.Sub, userInfo.FirstName),
         new Claim(JwtRegisteredClaimNames.Sub, userInfo.LastName),
         new Claim(JwtRegisteredClaimNames.Sub, userInfo.password),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private bool AuthenticateUser(User login,LoginCredentialsDto input)
        {
   

            //Validate the User Credentials    
           
            if (login.password == input.password )
            {
                return true;
            }
            else {
                return false;
            }
            
        }
/*
                                                  REST API SECTION



*/

        [AllowAnonymous]
        [HttpPost]
        public IActionResult UserLogin([FromBody] LoginCredentialsDto loginCredentials)
        {
            if (_userDetailRepositary.IsEmailValid(loginCredentials.email))
            {
                if (_userDetailRepositary.IsPasswordValid(loginCredentials.password))
                {
                    var GetUserId = _userDetailRepositary.EmailIdOfUser(loginCredentials.email);
                    var User = _userDetailRepositary.GetUser(GetUserId);
                    IActionResult response = Unauthorized();
                    bool check = AuthenticateUser(User, loginCredentials);
                    if (check)
                    {
                        var tokenString = GenerateJSONWebToken(User);
                        LoginResult responseToReturn = new LoginResult();
                        responseToReturn.accessToken = tokenString;
                        return new JsonResult(responseToReturn);
                    }
                    else
                    {
                        return StatusCode(401,"Check your loginId and Password");
                    }
                }
                else { 
                   // return NotFound("Password should Contains UpperCase,LowerCase,More than 8 Characters");
                    return StatusCode(401, "Password should Contains UpperCase,LowerCase,More than 8 Characters");
                }
            }
            else {
                // return NotFound("Emailspace should contains email Id");
                return StatusCode(401, "Emailspace should contains email Id");
            }


        }


    }
}
