using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using NoteBookAPI.Entities;
using NoteBookAPI.Helper;
using NoteBookAPI.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
namespace NoteBookAPI.Services
{
    public class UserServices : IUserServices

    {
        private readonly IUserDetailRepositories userDetailRepository;
        private IConfiguration configuration;
        private readonly IMapper mapper;
        private readonly ILogger logger;
        public UserServices(IUserDetailRepositories _userDetailRepository,IMapper _mapper,IConfiguration _configuration,ILogger _logger)
        {
            userDetailRepository = _userDetailRepository ?? throw new ArgumentNullException(nameof(_userDetailRepository));
            mapper = _mapper ?? throw new ArgumentNullException(nameof(_mapper));
            configuration = _configuration ?? throw new ArgumentNullException(nameof(_configuration));
            logger = _logger;
        }

        ///<summary>
        ///get the logged user 
        ///</summary>
        ///<param name="user"></param>
        public string GetLoggedId(ClaimsPrincipal User) {
            string LoggedUserId=String.Empty;
             if (!String.IsNullOrEmpty(ClaimTypes.NameIdentifier))
                 LoggedUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
             return LoggedUserId;
        }
        ///<summary>
        ///Update the userdetails  in the address,email,phone
        ///</summary>
        /// <param name="user"></param>
        /// <param name="LoggedUserId"></param>
        public ReturnCreateStatus CreateTheUser(UserCreatingDto user, Guid LoggedUserId) {
            ReturnCreateStatus returnCreate = new ReturnCreateStatus();
            foreach (EmailCreatingDto item in user.Emails)
            {
                if (!userDetailRepository.metaExist(item.type))
                {
                    logger.LogError("Email type is not exist");
                    returnCreate.status = 404;
                    returnCreate.description = "Email type is not exist";
                    returnCreate.user = user;
                    return returnCreate;
                }
                if (userDetailRepository.EmailExist(item.EmailAddress))
                {
                    logger.LogError("Email is already exist");
                    returnCreate.status = 409;
                    returnCreate.description = "Email is already exist";
                    returnCreate.user = user;
                    return returnCreate;
                    
                }
                item.type = RefTermKeyToGuidString(item.type);
                item.CreateBy = LoggedUserId;
                item.DateCreated = DateTime.Now;
            }
            foreach (PhoneCreatingDto item in user.Phones)
            {
                if (!userDetailRepository.metaExist(item.type))
                {
                    logger.LogError("Phone number type is not exist");
                    returnCreate.status = 404;
                    returnCreate.description = "phone number type is not exist";
                    returnCreate.user = user;
                    return returnCreate;
                }
                item.type = RefTermKeyToGuidString(item.type);
                item.CreateBy = LoggedUserId;
                item.DateCreated = DateTime.Now;
            }
            foreach (AddressCreatingDto item in user.Address)
            {
                if (!userDetailRepository.metaExist(item.Country))
                {
                    logger.LogError($"Countrytype is not exist{item.Country}");
                    returnCreate.status = 404;
                    returnCreate.description = "Country  type is not exist";
                    returnCreate.user = user;
                    return returnCreate;
                }
                if (!userDetailRepository.metaExist(item.Type))
                {
                    logger.LogError("Addresstype is not exist");
                    returnCreate.status = 404;
                    returnCreate.description = "Addresstype is not exist";
                    returnCreate.user = user;
                    return returnCreate;
                    
                }
                item.Type = RefTermKeyToGuidString(item.Type);
                item.Country =RefTermKeyToGuidString(item.Country);
                item.CreateBy = LoggedUserId;
                item.DateCreated = DateTime.Now;
            }
            returnCreate.user = user;
            returnCreate.status = 200;
            returnCreate.description = "Created Successfully";
            return returnCreate;
        }


        ///<summary>
        ///Update the userdetails  in the address,email,phone
        ///</summary>
        /// <param name="user"></param>
        /// <param name="LoggedUserId"></param>
        public ReturnUpdateStatus UpdateTheUser(UserUpdatingDto user,Guid LoggedUserId) {
            ReturnUpdateStatus errorReturn = new ReturnUpdateStatus();
            foreach (EmailUpdatingDto item in user.Emails)
            {
                if (userDetailRepository.EmailExist(item.EmailAddress))
                {
                    logger.LogError("Email is already existed");
                    errorReturn.status = 409;
                    errorReturn.description = "Email is already exist";
                    errorReturn.user = user;
                    return errorReturn;
                }
                if (!userDetailRepository.metaExist(item.type))
                {
                    logger.LogError("Email type is not existed");
                    errorReturn.status = 404;
                    errorReturn.description = "Email type is not exist";
                    errorReturn.user = user;
                    return errorReturn;
                }
                item.type = (userDetailRepository.TypeFinder(item.type)).Id.ToString();
                item.UpdateBy = LoggedUserId;
                item.DateUpdated = DateTime.Now;
            }
            foreach (PhoneUpdatingDto item in user.Phones)
            {
                if (!userDetailRepository.metaExist(item.type))
                {
                    logger.LogError("Phone number type  is not existed");
                    errorReturn.status = 404;
                    errorReturn.description = "Phone number type is not exist";
                    errorReturn.user = user;
                    return errorReturn;
                }
                item.type = (userDetailRepository.TypeFinder(item.type)).Id.ToString();
                item.UpdateBy = LoggedUserId;
                item.DateUpdated = DateTime.Now;
            }
            foreach (AddressUpdatingDto item in user.Address)
            {
                if (!userDetailRepository.metaExist(item.Country))
                {
                    logger.LogError($"Countrytype is not exist{item.Country}");
                    errorReturn.status = 404;
                    errorReturn.description = "CountryType  type is not exist";
                    errorReturn.user = user;
                    return errorReturn;  
                }
                if (!userDetailRepository.metaExist(item.Type))
                {
                    logger.LogError($"Addresstype is not exist");
                    errorReturn.status = 404;
                    errorReturn.description = "Address type is not exist";
                    errorReturn.user = user;
                    return errorReturn;
                }
                item.Type = (userDetailRepository.TypeFinder(item.Type)).Id.ToString();
                item.Country = (userDetailRepository.TypeFinder(item.Country)).Id.ToString();
                item.UpdateBy = LoggedUserId;
                item.DateUpdated = DateTime.Now;
            }
            errorReturn.user = user;
            errorReturn.status = 200;
            errorReturn.description = "updated successfullly";
            return errorReturn;
        }
        ///<summary>
        ///check the page number is exist or not
        ///</summary>
        /// <param name="PageSize"></param>
        /// <param name="PageNo"></param>
        public bool checkPageNumberLimit(int PageSize,int PageNo) {
            int CountBook = userDetailRepository.GetCount();
            double MaxPageNo = (double)CountBook / (double)(PageSize);
            int MaxiPage = Convert.ToInt32(Math.Ceiling(MaxPageNo));
            return MaxiPage < PageNo;
        }

        ///<summary>
        ///PageList append the items
        ///</summary>
        ///<param name="items"></param>
        public PageList<User> AppendingValues(PageList<User> items) {
            foreach (User user in items)
            {
                user.Emails = userDetailRepository.GetEmailIds(user.Id).ToList();
                user.Address = userDetailRepository.GetAddressIds(user.Id).ToList();
                user.Phones =userDetailRepository.GetPhoneIds(user.Id).ToList();
                user.Assets = userDetailRepository.GetAssetIds(user.Id).ToList();
            }
            return items;
        }

        ///<summary>
        ///Append the userid
        ///</summary>
        ///<param name="userId"></param>
        public User AppendingValueForUser(Guid userId) {
            User UserFromRepo = userDetailRepository.GetUser(userId);
            UserFromRepo.Emails = userDetailRepository.GetEmailIds(UserFromRepo.Id).ToList();
            UserFromRepo.Address = userDetailRepository.GetAddressIds(UserFromRepo.Id).ToList();
            UserFromRepo.Phones = userDetailRepository.GetPhoneIds(UserFromRepo.Id).ToList();
            UserFromRepo.Assets = userDetailRepository.GetAssetIds(UserFromRepo.Id).ToList();
            return UserFromRepo;
        }
        ///<summary>
        ///Convert type type to  reftermKey  guid as string
        ///</summary>
        ///<param name="type"></param>
        public string RefTermKeyToGuidString(string type) {
            return (userDetailRepository.TypeFinder(type)).Id.ToString();
        }

        


      

    }
}

