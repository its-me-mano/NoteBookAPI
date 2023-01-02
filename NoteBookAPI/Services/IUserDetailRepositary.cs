using NoteBookAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NoteBookAPI.Helper;
using NoteBookAPI.Models;

namespace NoteBookAPI.Services
{
    public interface IUserDetailRepositary
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
       // void AddImage(SaveImage saveImage);
        void AddUser(User user);
        IEnumerable<Email> GetEmailIds(Guid id);
        IEnumerable<Address> GetAddressIds(Guid id);
        IEnumerable<Phone> GetPhoneIds(Guid id);


        void UpdateUser(User user,Guid userId);
   
        bool UserExits(Guid userId);
        Guid EmailIdOfUser(string email);
      //  SaveImage GetImage(Guid id);
        bool IsEmailValid(string email);
        bool IsPasswordValid(string password);
        bool Save();
        RefTerm getRefTerm(string name);
        public IEnumerable<Guid> getRefSetGroup(Guid id);
        public IEnumerable<RefSet> getRefSet(IEnumerable<Guid> items);

        public void uploadImage(ImageStore img);
        public ImageStore GetImage(Guid id);
        public IEnumerable<AssetDto> GetAssetIds(Guid id);
        public bool CheckAsset(Guid id);
        public void AddAsset(AssetDto assetDto);
        public void UpdateAsset(AssetDto assetDto);
        public AssetDto GetAssetById(Guid id);

      



    }
}
