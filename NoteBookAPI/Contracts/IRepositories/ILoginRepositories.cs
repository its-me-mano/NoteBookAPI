using NoteBookAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBookAPI.Contracts
{
    public interface ILoginRepositories
    {
        ///<summary>
        /// Get the email id of the user
        ///</summary>
        ///<param name="email"></param>
        Guid EmailIdOfUser(string email);
        ///<summary>
        /// Get the particular user  
        ///</summary>
        ///<param name="id"></param>
        User GetUser(Guid id);
    }
}
