using NoteBookAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using NoteBookAPI.DbContexts;
using NoteBookAPI.Helper;
using NoteBookAPI.Models;

namespace NoteBookAPI.Services
{
    public class UserDetailRepositary : IUserDetailRepositary
    {
        private readonly UserDetailsContext _context;
        public PageList<User> GetUsers(UserResourceParameter userResourceParameter)
        {
            if (userResourceParameter == null)
            {
                throw new ArgumentNullException(nameof(userResourceParameter));
            }

            var Collection = _context.Users as IQueryable<User>;
            if (!string.IsNullOrWhiteSpace(userResourceParameter.FirstName))
            {
                var Query = userResourceParameter.FirstName;
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


        public UserDetailRepositary(UserDetailsContext context)
        {
            _context = context ?? throw new ArgumentException(nameof(context));
        }

        public RefSet TypeFinder(string type)
        {
            return _context.RefSets.FirstOrDefault(b => b.Name == type);
        }

        public bool EmailExist(string email)
        {
            return _context.Emails.Any(a => a.email == email);
        }

        public bool metaExist(string type)
        {
            return _context.RefSets.Any(a => a.Name == type);
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
            return _context.Users.Where(a=>a.UserId==id).FirstOrDefault();
        }

        public void UpdateUser(User user,Guid userId)
        {
            var Data = _context.Users.Where(a => a.UserId == userId).FirstOrDefault();
            _context.SaveChanges();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public int GetCount()
        {
            var All = _context.Users.ToList();
            return All.Count;
        }

        public IEnumerable<Email> GetEmails()
        {
            return _context.Emails.ToList();
        }
        public IEnumerable<Email> GetEmailIds(Guid id)
        {
            return _context.Emails.Where(a => a.UserId == id);
        }

        public Guid EmailIdOfUser(string email)
        {
            var Collection = _context.Emails as IQueryable<Email>;
            if (!string.IsNullOrWhiteSpace(email))
            {
                email = email.Trim();
                Collection = Collection.Where(a => a.email == email);
            }
            var item = Collection.FirstOrDefault();
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
            return _context.Users.Any(a => a.UserId == userId);
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
            foreach (var item in _context.SetRefTerms)
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

            return _context.RefSets.Where(a => items.Contains(a.TypeId));
        }
        public RefTerm getRefTerm(string name)
        {
            return (_context.RetTerms.FirstOrDefault(a => a.Types == name));
        }
        public bool IsPasswordValid(string password)
        {
            if (password.Length > 8)
            {
                bool upper = false;
                bool Number = false;
                bool lower = false;

                foreach (char str in password)
                {
                    if (Char.IsUpper(str))
                    {
                        upper = true;
                    }
                    if (Char.IsDigit(str))
                        Number = true;
                    if (Char.IsLower(str))
                        lower = true;

                }
                if (upper && Number && lower)
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<Address> GetAddressIds(Guid id)
        {
            return _context.Addresses.Where(a => a.UserId == id);
        }

        public IEnumerable<Phone> GetPhoneIds(Guid id)
        {
            return _context.PhNumbers.Where(a => a.UserId == id);
        }

        public Guid getAssetId(Guid userId) {
            return _context.ImageStores.Where(e => e.UserId == userId).FirstOrDefault().FileId;
        }


        public void uploadImage(ImageStore img)
        {
            if (img == null)
            {
                throw new ArgumentNullException(nameof(img));
            }
            _context.ImageStores.Add(img);
        }
        public ImageStore GetImage(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }
            var img = _context.ImageStores.FirstOrDefault(b => b.FileId == id);
            if (img == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            return img;

        }
        public void UpdateAsset(AssetDto assetDto)
        {

        }
        public void AddAsset(AssetDto assetDto)
        {
            _context.AssetDtos.Add(assetDto);
        }
        public bool CheckAsset(Guid id)
        {
            return _context.AssetDtos.Any(a => a.UserId == id);
        }
        public AssetDto GetAssetById(Guid id)
        {
            return _context.AssetDtos.FirstOrDefault(a => a.UserId.Equals(id));
        }
        public IEnumerable<AssetDto> GetAssetIds(Guid id)
        {
            return _context.AssetDtos.Where(a => a.UserId == id);
        }

        

    }
}
