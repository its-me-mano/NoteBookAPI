using NoteBookAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using NoteBookAPI.DbContexts;
using NoteBookAPI.Helper;
using NoteBookAPI.Models;

namespace NoteBookAPI.Services
{
    public class UserDetailsRepositories : IUserDetailRepositories
    {
        private readonly UserDetailsContext _context;
        public UserDetailsRepositories(UserDetailsContext context)
        {
            _context = context ?? throw new ArgumentException(nameof(context));
        }
        ///<summary>
        ///Get the user by pagelist
        ///</summary>
        ///<param name="userResourceParameter"></param>
        public PageList<User> GetUsers(UserResourceParameter userResourceParameter)
        {
            if (userResourceParameter == null)
            {
                throw new ArgumentNullException(nameof(userResourceParameter));
            }
            IQueryable<User> Collection = _context.Users as IQueryable<User>;
            if (!string.IsNullOrWhiteSpace(userResourceParameter.FirstName))
            {
                string Query = userResourceParameter.FirstName;
                Collection = Collection.Where(a => a.FirstName.Contains(Query));
            }
            if (userResourceParameter.OrderType != null)
            {
                if (userResourceParameter.OrderType.Equals("DESC"))
                {
                    Collection = Collection.OrderByDescending(a => userResourceParameter.OrderBy.Equals("FirstName") ? a.FirstName : a.LastName);
                }
                else 
                {
                    Collection = Collection.OrderBy(a => userResourceParameter.OrderBy.Equals("FirstName") ? a.FirstName : a.LastName);
                }
            }
            return PageList<User>.Create(Collection, userResourceParameter.PageNo, userResourceParameter.PageSize);
        }
        ///<summary>
        /// check meta data exist or not
        ///</summary>
        ///<param name="type"></param>
        public bool metaExist(string type)
        {
            return _context.RefTerms.Any(a => a.Key == type);
        }
        ///<summary>
        /// find the type of the Refset
        ///</summary>
        /// <param name="type"></param>
        public RefTerm TypeFinder(string type)
        {
            return _context.RefTerms.FirstOrDefault(b => b.Key == type);
        }
        ///<summary>
        ///delete the user
        ///</summary>
        ///<param name="user"></param>
        public void DeleteUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            _context.Users.Remove(user);
        }
        ///<summary>
        ///check mail exist or not
        ///</summary>
        ///<param name="email"></param>
        public bool EmailExist(string email)
        {
            return _context.Emails.Any(a => a.EmailAddress == email);
        }
        ///<summary>
        ///add the users
        ///</summary>
        ///<param name="user"></param>
        public void AddUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            _context.Users.Add(user);
        }

        ///<summary>
        ///get the users
        ///</summary>
        ///<param name="id"></param>

        public User GetUser(Guid id) 
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }
            return _context.Users.Where(a=>a.Id==id).FirstOrDefault();
        }
        ///<summary>
        ///update the users
        ///</summary>
        ///<param name="userId"></param>
        ///<param name="user"></param>
        public void UpdateUser(User user,Guid userId)
        {
            User Data = _context.Users.Where(a => a.Id == userId).FirstOrDefault();
            _context.SaveChanges();
        }
        ///<summary>
        ///get the list of users
        ///</summary>
       
        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }
        ///<summary>
        ///count of the users
        ///</summary>
        public int GetCount()
        {
            List<User> All = _context.Users.ToList();
            return All.Count;
        }
        ///<summary>
        ///lis of email of the users
        ///</summary>
        public IEnumerable<Email> GetEmails()
        {
            return _context.Emails.ToList();
        }
        ///<summary>
        ///save the users
        ///</summary>
        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
        ///<summary>
        ///check the user exist ot ot
        ///</summary>
        ///<param name="userId"></param>
        public bool UserExits(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(userId));
            }
            return _context.Users.Any(a => a.Id == userId);
        }

        ///<summary>
        ///get the address ids 
        ///</summary>
        ///<param name="id"></param>
        public IEnumerable<Address> GetAddressIds(Guid id)
        {
            return _context.Addresses.Where(a => a.UserId == id);
        }
        ///<summary>
        ///get the phone number by id
        ///</summary>
        ///<param name="id"></param>
        public IEnumerable<Phone> GetPhoneIds(Guid id)
        {
            return _context.PhNumbers.Where(a => a.UserId == id);
        }
        public IEnumerable<Email> GetEmailIds(Guid id)
        {
            return _context.Emails.Where(a => a.UserId == id);
        }

        ///<summary>
        ///cget the asset
        ///</summary>
        ///<param name="userId"></param>
        public Guid getAssetId(Guid userId)
        {
            return _context.Assets.Where(a => a.UserId.Equals(userId)).FirstOrDefault().Id;

        }

        ///<summary>
        ///update the asset
        ///</summary>
        ///<param name="assetDto"></param>
        public void UpdateAsset(Asset assetDto)
        {

        }
        ///<summary>
        ///add the asset
        ///</summary>
        ///<param name="assetDto"></param>
        public void AddAsset(Asset assetDto)
        {
            _context.Assets.Add(assetDto);
        }
        ///<summary>
        ///check the asset exist or not
        ///</summary>
        ///<param name="id"></param>
        public bool CheckAsset(Guid id)
        {
            return _context.Assets.Any(a => a.UserId == id);
        }
        ///<summary>
        ///get the assetId  by id
        ///</summary>
        ///<param name="id"></param>
        public Asset GetAssetById(Guid id)
        {
            return _context.Assets.FirstOrDefault(a => a.UserId.Equals(id));
        }
        ///<summary>
        ///get the assetId 
        ///</summary>
        ///<param name="id"></param>
        public IEnumerable<Asset> GetAssetIds(Guid id)
        {
            return _context.Assets.Where(a => a.UserId == id);
        }

        

    }
}
