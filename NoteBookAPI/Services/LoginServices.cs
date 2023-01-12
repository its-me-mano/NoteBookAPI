using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NoteBookAPI.Contracts;
using NoteBookAPI.Entities;
using NoteBookAPI.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace NoteBookAPI.Services
{
    public class LoginServices : ILoginServices
    {
        private readonly ILoginRepositories loginRepository;
        private IConfiguration configuration;
        private readonly IMapper mapper;
        public LoginServices(ILoginRepositories _loginRepository, IMapper _mapper, IConfiguration _configuration)
        {
            loginRepository = _loginRepository ?? throw new ArgumentNullException(nameof(_loginRepository));
            mapper = _mapper ?? throw new ArgumentNullException(nameof(_mapper));
            configuration = _configuration ?? throw new ArgumentNullException(nameof(_configuration));
        }
        ///<summary>
        /// Generate webtoken
        ///</summary>
        ///<param name="userInfo"></param>
        ///<param name="_config"></param>
        public string GenerateJSONWebToken(User userInfo, IConfiguration _config) 
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            Claim[] claims = new[] {
            new Claim(JwtRegisteredClaimNames.Sub, userInfo.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Sub, userInfo.LastName),
            new Claim(JwtRegisteredClaimNames.Sub, userInfo.password),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            JwtSecurityToken token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        ///<summary>
        /// Validated the user
        ///</summary>
        ///<param name="input"></param>
        public bool AuthenticateUser(User login, LoginCredentialsDto input)
        {
            //Validate the User Credentials    
            return login.password == input.password;
        }
    }
}
