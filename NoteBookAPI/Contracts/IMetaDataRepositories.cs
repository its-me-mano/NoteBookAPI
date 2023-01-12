using NoteBookAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBookAPI.Contracts
{
    public interface IMetaDataRepositories
    {
        ///<summary>
        /// get the refset
        ///</summary>
        ///<param name="type"></param>
        RefSet TypeFinder(string type);
        ///<summary>
        /// Guid list of RefSet
        ///</summary>
        ///<param name="id"></param>
        IEnumerable<Guid> getRefSetGroup(Guid id);
        ///<summary>
        /// Return the List of RefSet
        ///</summary>
        ///<param name="items"></param>
        IEnumerable<RefSet> getRefSet(IEnumerable<Guid> items);
        ///<summary>
        /// Get the RefTerm based on Refterm Name  
        ///</summary>
        ///<param name="name"></param>
        RefTerm getRefTerm(string name);
        ///<summary>
        /// check the metadata exist or not 
        ///</summary>
        ///<param name="type"></param>
        bool metaExist(string type);
    }
}
