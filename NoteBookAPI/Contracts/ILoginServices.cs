using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NoteBookAPI.Entities;
using NoteBookAPI.Models;


namespace NoteBookAPI.Contracts
{
    public interface ILoginServices
    {
        ///<summary>
        /// Generate webtoken
        ///</summary>
        ///<param name="userInfo"></param>
        ///<param name="_config"></param>
        string GenerateJSONWebToken(User userInfo, IConfiguration _config);
        ///<summary>
        /// Validated the user
        ///</summary>
        ///<param name="input"></param>
        bool AuthenticateUser(User login, LoginCredentialsDto input);

        

    }
}
