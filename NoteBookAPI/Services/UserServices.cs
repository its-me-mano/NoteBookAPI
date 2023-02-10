using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NoteBookAPI.Entities;
using NoteBookAPI.Entities.Dto;
using NoteBookAPI.Helper;
using NoteBookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
namespace NoteBookAPI.Services
{
    public class UserServices : IUserServices

    {
        private readonly IUserDetailRepositories userDetailRepository;
        private readonly IMapper mapper;
        private readonly ILogger logger;
        public UserServices(IUserDetailRepositories _userDetailRepository,IMapper _mapper,ILogger _logger)
        {
            userDetailRepository = _userDetailRepository ?? throw new ArgumentNullException(nameof(_userDetailRepository));
            mapper = _mapper ?? throw new ArgumentNullException(nameof(_mapper));
            logger = _logger;
        }

        ///<summary>
        ///Adding the appdning the values email,address
        ///</summary>
        /// <param name="userId"></param>
        /// <param name="userFromRepo"></param>
        public void AppendingValueForUpdate(User userFromRepo,Guid userId,UserUpdatingDto user,Guid userLogin) {
            List<Address> addressess = userDetailRepository.GetAddressIds(userId).ToList();
            userFromRepo.Address.Select((value, index) => value.Id = addressess[index].Id);
            List<Email> emails = userDetailRepository.GetEmailIds(userId).ToList();
            userFromRepo.Emails.Select((value, index) => value.Id = emails[index].Id);
            List<Phone> phones = userDetailRepository.GetPhoneIds(userId).ToList();
            userFromRepo.Phones.Select((value, index) => value.Id = phones[index].Id);
            mapper.Map(user, userFromRepo);
            userFromRepo.DateUpdated = DateTime.Now;
            userFromRepo.UpdateBy = userLogin;
            userDetailRepository.UpdateUser(userFromRepo, userId);
            userDetailRepository.Save();
        }

        ///<summary>
        ///get the logged user 
        ///</summary>
        ///<param name="user"></param>
        public string GetLoggedId(ClaimsPrincipal User) {
            string loggedUserId=String.Empty;
             if (!String.IsNullOrEmpty(ClaimTypes.NameIdentifier))
                 loggedUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
             return loggedUserId;
        }
        /// <summary>
        /// Get the count of the users
        /// </summary>
        public int GetCount() {
            return userDetailRepository.GetCount();
        }
        /// <summary>
        /// Get the users
        /// </summary>
        /// <param name="userResourceParameter"></param>
        public PageList<User> GetUsers(UserResourceParameter userResourceParameter) {
            return userDetailRepository.GetUsers(userResourceParameter);
        }
        /// <summary>
        /// Get the particular user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public User GetUser(Guid userId)
        {
            return userDetailRepository.GetUser(userId); 
        }
        /// <summary>
        /// Delete the particular user
        /// </summary>
        /// <param name="userFromRepo"></param>
        public void DeleteUser(User userFromRepo) {
            userDetailRepository.DeleteUser(userFromRepo);
            userDetailRepository.Save();
        }
        /// <summary>
        /// SavetheCreateDto user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public UserDto SaveCreateUser(UserCreatingDto user,Guid loginUserId) {
            User userEntity = mapper.Map<User>(user);
            userEntity.CreateBy = loginUserId;
            userEntity.DateCreated = DateTime.Now;
            userEntity.Address.Select(a => a.CreateBy = loginUserId);
            userEntity.Address.Select(a => a.DateCreated = DateTime.Now);
            userEntity.Phones.Select(a => a.CreateBy = loginUserId);
            userEntity.Phones.Select(a => a.DateCreated = DateTime.Now);
            userEntity.Emails.Select(a => a.CreateBy = loginUserId);
            userEntity.Emails.Select(a => a.DateCreated = DateTime.Now);
            userDetailRepository.AddUser(userEntity);
            userDetailRepository.Save();      
            return mapper.Map<UserDto>(userEntity);
        }

        /// <summary>
        /// Does the user exist or not
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public bool UserExists(Guid userId) {
            return !userDetailRepository.UserExits(userId);
        }
        ///<summary>
        ///Return Error in the format
        ///</summary>
        ///<param name="description"></param>
        ///<param name="statuscode"></param>
        public ErrorDto ErrorToReturn(string statuscode, string description) {
            ErrorManage errorManage = new ErrorManage();
            return errorManage.ReturningError(statuscode, description);
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
                if (!userDetailRepository.MetaExist(item.type))
                {
                    logger.LogError("Email type does not exist");
                    returnCreate.status = 404;
                    returnCreate.description = "Email type does not exist";
                    returnCreate.user = user;
                    return returnCreate;
                }
                if (userDetailRepository.EmailExist(item.EmailAddress))
                {
                    logger.LogError("Email already exist");
                    returnCreate.status = 409;
                    returnCreate.description = "Email  already exist";
                    returnCreate.user = user;
                    return returnCreate;
                    
                }
                item.type = RefTermKeyToGuidString(item.type);
              
            }
            foreach (PhoneCreatingDto item in user.Phones)
            {
                if (!userDetailRepository.MetaExist(item.type))
                {
                    logger.LogError("Phone number type does not exist");
                    returnCreate.status = 404;
                    returnCreate.description = "phone number type does not exist";
                    returnCreate.user = user;
                    return returnCreate;
                }
                item.type = RefTermKeyToGuidString(item.type);
               
            }
            foreach (AddressCreatingDto item in user.Address)
            {
                if (!userDetailRepository.MetaExist(item.Country))
                {
                    logger.LogError($"Countrytype does not exist{item.Country}");
                    returnCreate.status = 404;
                    returnCreate.description = "Country  type does not exist";
                    returnCreate.user = user;
                    return returnCreate;
                }
                if (!userDetailRepository.MetaExist(item.Type))
                {
                    logger.LogError("Addresstype does not exist");
                    returnCreate.status = 404;
                    returnCreate.description = "Addresstype does not exist";
                    returnCreate.user = user;
                    return returnCreate;
                    
                }
                item.Type = RefTermKeyToGuidString(item.Type);
                item.Country =RefTermKeyToGuidString(item.Country);
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
                    logger.LogError("Email already existed");
                    errorReturn.status = 409;
                    errorReturn.description = "Email already exist";
                    errorReturn.user = user;
                    return (errorReturn);
                }
                if (!userDetailRepository.MetaExist(item.type))
                {
                    logger.LogError("Email type does not existed");
                    errorReturn.status = 404;
                    errorReturn.description = "Email type does not exist";
                    errorReturn.user = user;
                    return errorReturn;
                }
                item.type = (userDetailRepository.TypeFinder(item.type)).Id.ToString();
            }
            foreach (PhoneUpdatingDto item in user.Phones)
            {
                if (!userDetailRepository.MetaExist(item.type))
                {
                    logger.LogError("Phone number type  does not existed");
                    errorReturn.status = 404;
                    errorReturn.description = "Phone number type does not exist";
                    errorReturn.user = user;
                    return errorReturn;
                }
                item.type = (userDetailRepository.TypeFinder(item.type)).Id.ToString();
                
            }
            foreach (AddressUpdatingDto item in user.Address)
            {
                if (!userDetailRepository.MetaExist(item.Country))
                {
                    logger.LogError($"Countrytype does not exist{item.Country}");
                    errorReturn.status = 404;
                    errorReturn.description = "CountryType  type does not exist";
                    errorReturn.user = user;
                    return errorReturn;  
                }
                if (!userDetailRepository.MetaExist(item.Type))
                {
                    logger.LogError($"Addresstype does not exist");
                    errorReturn.status = 404;
                    errorReturn.description = "Address type does not exist";
                    errorReturn.user = user;
                    return errorReturn;
                }
                item.Type = (userDetailRepository.TypeFinder(item.Type)).Id.ToString();
                item.Country = (userDetailRepository.TypeFinder(item.Country)).Id.ToString();
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
            int countBook = userDetailRepository.GetCount();
            double maxPageNo = (double)countBook / (double)(PageSize);
            int maxiPage = Convert.ToInt32(Math.Ceiling(maxPageNo));
            return maxiPage < PageNo;
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
            User userFromRepo = userDetailRepository.GetUser(userId);
            userFromRepo.Emails = userDetailRepository.GetEmailIds(userFromRepo.Id).ToList();
            userFromRepo.Address = userDetailRepository.GetAddressIds(userFromRepo.Id).ToList();
            userFromRepo.Phones = userDetailRepository.GetPhoneIds(userFromRepo.Id).ToList();
            userFromRepo.Assets = userDetailRepository.GetAssetIds(userFromRepo.Id).ToList();
            return userFromRepo;
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

