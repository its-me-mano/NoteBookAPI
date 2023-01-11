using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using NoteBookAPI.Entities;
using NoteBookAPI.Helper;
using NoteBookAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;

namespace NoteBookAPI.Services
{
    public interface IService

    {
        string GetLoggedId(ClaimsPrincipal user);
        metaDataDto MetaData(string search);
        metaDataDto FetchMetaData(string search);
        string ImageToString( IFormFile file);

        byte[] StringToImage(String assetId);

        bool checkPageNumberLimit(int PageSize,int PageNo);
        PageList<User> AppendingValues(PageList<User> items);
        User AppendingValueForUser(Guid userId);
        string GenerateJSONWebToken(User userInfo,IConfiguration _config);

        public bool AuthenticateUser(User login, LoginCredentialsDto input);

        bool emailValidation(EmailCreatingDto email);

        string RefTermKeyToGuidString(string type);
        bool IsPasswordValid(string password);
    }
}
