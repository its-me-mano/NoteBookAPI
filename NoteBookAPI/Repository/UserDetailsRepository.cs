using NoteBookAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using NoteBookAPI.DbContexts;
using NoteBookAPI.Helper;
using NoteBookAPI.Models;

namespace NoteBookAPI.Services
{
    public class UserDetailsRepository : IUserDetailRepository
    {
        private readonly UserDetailsContext _context;
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
        public void DeleteUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            _context.Users.Remove(user);
        }


        public UserDetailsRepository(UserDetailsContext context)
        {
            _context = context ?? throw new ArgumentException(nameof(context));
        }

        public RefSet TypeFinder(string type)
        {
            return _context.RefSets.FirstOrDefault(b => b.Key == type);
        }

        public bool EmailExist(string email)
        {
            return _context.Emails.Any(a => a.EmailAddress == email);
        }

        public bool metaExist(string type)
        {
            return _context.RefSets.Any(a => a.Key == type);
        }



        public void AddUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            _context.Users.Add(user);
        }



        public User GetUser(Guid id) 
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }
            return _context.Users.Where(a=>a.Id==id).FirstOrDefault();
        }

        public void UpdateUser(User user,Guid userId)
        {
            User Data = _context.Users.Where(a => a.Id == userId).FirstOrDefault();
            _context.SaveChanges();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public int GetCount()
        {
            List<User> All = _context.Users.ToList();
            return All.Count;
        }

        public IEnumerable<Email> GetEmails()
        {
            return _context.Emails.ToList();
        }
        

        public Guid EmailIdOfUser(string email)
        {
            IQueryable<Email> Collection = _context.Emails as IQueryable<Email>;
            if (!string.IsNullOrWhiteSpace(email))
            {
                email = email.Trim();
                Collection = Collection.Where(a => a.EmailAddress == email);
            }
            Email item = Collection.FirstOrDefault();
            if (item == null)
                throw new ArgumentNullException(nameof(email));
            return item.UserId;
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public bool UserExits(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(userId));
            }
            return _context.Users.Any(a => a.Id == userId);
        }


        public bool IsEmailValid(string email)
        {
            if (email.Contains(".") && email.Contains("@"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<Guid> getRefSetGroup(Guid id)
        {
            List<Guid> Group = new List<Guid>();
            foreach (SetRefTerm item in _context.SetRefTerms)
            {
                if (item.ReftermId.Equals(id))
                {

                    Group.Add(item.RefSetid);
                }
            }
            return Group;
        }
        public IEnumerable<RefSet> getRefSet(IEnumerable<Guid> items)
        {

            return _context.RefSets.Where(a => items.Contains(a.Id));
        }
        public RefTerm getRefTerm(string name)
        {
            return (_context.RetTerms.FirstOrDefault(a => a.Key== name));
        }
   

        public IEnumerable<Address> GetAddressIds(Guid id)
        {
            return _context.Addresses.Where(a => a.UserId == id);
        }

        public IEnumerable<Phone> GetPhoneIds(Guid id)
        {
            return _context.PhNumbers.Where(a => a.UserId == id);
        }
        public IEnumerable<Email> GetEmailIds(Guid id)
        {
            return _context.Emails.Where(a => a.UserId == id);
        }

        public Guid getAssetId(Guid userId)
        {
            return _context.Assets.Where(a => a.UserId.Equals(userId)).FirstOrDefault().Id;

        }


        public void uploadImage(Asset img)
        {
            if (img == null)
            {
                throw new ArgumentNullException(nameof(img));
            }
            _context.Assets.Add(img);
        }
        public Asset GetImage(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }
            Asset img = _context.Assets.FirstOrDefault(b => b.Id == id);
            if (img == null)
            {
                throw new ArgumentNullException(nameof(img));
            }
            return img;

        }
        public void UpdateAsset(Asset assetDto)
        {

        }
        public void AddAsset(Asset assetDto)
        {
            _context.Assets.Add(assetDto);
        }
        public bool CheckAsset(Guid id)
        {
            return _context.Assets.Any(a => a.UserId == id);
        }
        public Asset GetAssetById(Guid id)
        {
            return _context.Assets.FirstOrDefault(a => a.UserId.Equals(id));
        }
        public IEnumerable<Asset> GetAssetIds(Guid id)
        {
            return _context.Assets.Where(a => a.UserId == id);
        }

        

    }
}
