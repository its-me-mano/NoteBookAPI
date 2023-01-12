using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using NoteBookAPI.Entities;
using NoteBookAPI.Helper;
using NoteBookAPI.Models;
using System;
using System.Security.Claims;

namespace NoteBookAPI.Services
{
    public interface IUserServices
    {

        ///<summary>
        ///Update the userdetails  in the address,email,phone
        ///</summary>
        /// <param name="user"></param>
        /// <param name="LoggedUserId"></param>
        ReturnUpdateStatus UpdateTheUser(UserUpdatingDto user, Guid LoggedUserId);
        ///<summary>
        ///Create the userdetails  in the address,email,phone
        ///</summary>
        /// <param name="user"></param>
        /// <param name="LoggedUserId"></param>
        ReturnCreateStatus CreateTheUser(UserCreatingDto user, Guid LoggedUserId);
        ///<summary>
        ///get the logged user 
        ///</summary>
        ///<param name="user"></param>
        string GetLoggedId(ClaimsPrincipal user);
        ///<summary>
        ///check the page number is exist or not
        ///</summary>
        /// <param name="PageSize"></param>
        /// <param name="PageNo"></param>
        bool checkPageNumberLimit(int PageSize,int PageNo);
        ///<summary>
        ///PageList append the items
        ///</summary>
        ///<param name="items"></param>
        PageList<User> AppendingValues(PageList<User> items);
        ///<summary>
        ///Append the userid
        ///</summary>
        ///<param name="userId"></param>
        User AppendingValueForUser(Guid userId);
        ///<summary>
        ///Convert type type to  reftermKey  guid as string
        ///</summary>
        ///<param name="type"></param>
        string RefTermKeyToGuidString(string type);
    }
}
