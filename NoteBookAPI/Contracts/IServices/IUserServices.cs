using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using NoteBookAPI.Entities;
using NoteBookAPI.Entities.Dto;
using NoteBookAPI.Helper;
using NoteBookAPI.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace NoteBookAPI.Services
{
    public interface IUserServices
    {

        ///<summary>
        ///Adding the appdning the values email,address
        ///</summary>
        /// <param name="userFromRepo"></param>
        /// <param name="userId"></param>
        void AppendingValueForUpdate(User userFromRepo,Guid userId,UserUpdatingDto user,Guid userLogin);

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
        /// <summary>
        /// Get the count of the users
        /// </summary>
        int GetCount();
        /// <summary>
        /// Get the users
        /// </summary>
        /// <param name="userResourceParameter"></param>
        PageList<User> GetUsers(UserResourceParameter userResourceParameter);
        /// <summary>
        /// Get the particular user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        User GetUser(Guid userId);
        /// <summary>
        /// Delete the particular user
        /// </summary>
        /// <param name="userFromRepo"></param>
        void DeleteUser(User userFromRepo);
        /// <summary>
        /// Save the creating dto
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        UserDto SaveCreateUser(UserCreatingDto user,Guid loginId);
        /// <summary>
        /// Does the user exist or not
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        bool UserExists(Guid userId);
        ///<summary>
        ///check the page number is exist or not
        ///</summary>
        /// <param name="PageSize"></param>
        /// <param name="PageNo"></param>
        bool checkPageNumberLimit(int PageSize,int PageNo);
        ///<summary>
        ///Return Error in the format
        ///</summary>
        ///<param name="description"></param>
        ///<param name="statuscode"></param>
        ErrorDto ErrorToReturn(string statuscode, string description);
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
