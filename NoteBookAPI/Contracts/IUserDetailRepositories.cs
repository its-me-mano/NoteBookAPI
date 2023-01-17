using NoteBookAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NoteBookAPI.Helper;
using NoteBookAPI.Models;

namespace NoteBookAPI.Services
{
    public interface IUserDetailRepositories
    {
        ///<summary>
        /// find the type of the Refset
        ///</summary>
        /// <param name="type"></param>
        RefTerm TypeFinder(string type);
        ///<summary>
        /// check meta data exist or not
        ///</summary>
        ///<param name="type"></param>
        bool metaExist(string type);
        ///<summary>
        ///get the asset by userid
        ///</summary>
        ///<param name="userId"></param>
        Guid getAssetId(Guid userId);
        ///<summary>
        ///check mail exist or not
        ///</summary>
        ///<param name="email"></param>
        bool EmailExist(string email);
        ///<summary>
        ///Get the user by pagelist
        ///</summary>
        ///<param name="userResourceParameter"></param>
        PageList<User> GetUsers(UserResourceParameter userResourceParameter);
        ///<summary>
        ///get the count of the users
        ///</summary>
        int GetCount();
        ///<summary>
        ///delete the user
        ///</summary>
        ///<param name="user"></param>
        void DeleteUser(User user);
        ///<summary>
        ///get the pariticular user
        ///</summary>
        ///<param name="id"></param>
        User GetUser(Guid id);
        ///<summary>
        ///get the list of emails
        ///</summary>
        IEnumerable<Email> GetEmails();
        ///<summary>
        ///get the list of users
        ///</summary>
        IEnumerable<User> GetAllUsers();
        ///<summary>
        ///add the users
        ///</summary>
        ///<param name="user"></param>
        void AddUser(User user);
        ///<summary>
        /// get the list of emails by id
        ///</summary>
        ///<param name="id"></param>
        IEnumerable<Email> GetEmailIds(Guid id);
        ///<summary>
        ///get the list of address by id
        ///</summary>
        ///<param name="id"></param>
        IEnumerable<Address> GetAddressIds(Guid id);
        ///<summary>
        ///get the list of phones by id
        ///</summary>
        ///<param name="id"></param>
        IEnumerable<Phone> GetPhoneIds(Guid id);
        ///<summary>
        /// update the user
        ///</summary>
        ///<param name="user"></param>
        ///<param name="userId"></param>
        void UpdateUser(User user,Guid userId);
        ///<summary>
        ///check the user exist or not
        ///</summary>
        ///<param name="userId"></param>
        bool UserExits(Guid userId);
        ///<summary>
        /// get the list of assets by id
        ///</summary>
        ///<param name="id"></param>
        public IEnumerable<Asset> GetAssetIds(Guid id);
        ///<summary>
        ///check the asset exist or not
        ///</summary>
        ///<param name="id"></param>
        public bool CheckAsset(Guid id);
        ///<summary>
        ///add the asset
        ///</summary>
        ///<param name="assetDto"></param>
        public void AddAsset(Asset assetDto);
        ///<summary>
        /// update the asset
        ///</summary>
        ///<param name="assetDto"></param>
        public void UpdateAsset(Asset assetDto);
        ///<summary>
        ///get the asset by id
        ///</summary>
        ///<param name="id"></param>
        public Asset GetAssetById(Guid id);
        ///<summary>
        ///save the context
        ///</summary>
        bool Save();
    }
}
