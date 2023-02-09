using NoteBookAPI.Contracts;
using NoteBookAPI.DbContexts;
using NoteBookAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBookAPI.Repositories
{
    public class LoginRepositories : ILoginRepositories
    {
        private readonly UserDetailsContext _context;
        public LoginRepositories(UserDetailsContext context)
        {
            _context = context ?? throw new ArgumentException(nameof(context));
        }
        ///<summary>
        /// Get the email id of the user
        ///</summary>
        ///<param name="email"></param>
        public User GetUser(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }
            return _context.Users.Where(a => a.Id == id).FirstOrDefault();
        }
        ///<summary>
        /// Get the particular user  
        ///</summary>
        ///<param name="id"></param>
        public Guid EmailIdOfUser(string email)
        {
            IQueryable<Email> collection = _context.Emails as IQueryable<Email>;
            if (!string.IsNullOrWhiteSpace(email))
            {
                email = email.Trim();
                collection = collection.Where(a => a.EmailAddress == email);
            }
            Email item = collection.FirstOrDefault();
            if (item == null)
                throw new ArgumentNullException(nameof(email));
            return item.UserId;
        }
    }
}
