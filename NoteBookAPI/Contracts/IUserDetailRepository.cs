using NoteBookAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NoteBookAPI.Helper;
using NoteBookAPI.Models;

namespace NoteBookAPI.Services
{
    public interface IUserDetailRepository
    {
        Guid getAssetId(Guid userId);
        bool metaExist(string type);
        bool EmailExist(string email);
        PageList<User> GetUsers(UserResourceParameter userResourceParameter);
        RefSet TypeFinder(string type);
        int GetCount();
        void DeleteUser(User user);
        User GetUser(Guid id);
        IEnumerable<Email> GetEmails();
        IEnumerable<User> GetAllUsers();
        void AddUser(User user);
        IEnumerable<Email> GetEmailIds(Guid id);
        IEnumerable<Address> GetAddressIds(Guid id);
        IEnumerable<Phone> GetPhoneIds(Guid id);


        void UpdateUser(User user,Guid userId);
   
        bool UserExits(Guid userId);
        Guid EmailIdOfUser(string email);
      //  SaveImage GetImage(Guid id);
        bool IsEmailValid(string email);
       
        bool Save();
        RefTerm getRefTerm(string name);
        public IEnumerable<Guid> getRefSetGroup(Guid id);
        public IEnumerable<RefSet> getRefSet(IEnumerable<Guid> items);

        public void uploadImage(Asset img);
        public Asset GetImage(Guid id);
        public IEnumerable<Asset> GetAssetIds(Guid id);
        public bool CheckAsset(Guid id);
        public void AddAsset(Asset assetDto);
        public void UpdateAsset(Asset assetDto);
        public Asset GetAssetById(Guid id);

      



    }
}
